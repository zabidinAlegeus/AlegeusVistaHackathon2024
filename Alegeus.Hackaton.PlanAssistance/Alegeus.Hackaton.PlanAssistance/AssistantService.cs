namespace Alegeus.Hackaton.PlanAssistance;

using Azure;
using Azure.AI.OpenAI.Assistants;

public class AssistantService
{
    public async Task<IList<string>> ChatWithAssistant(string query, string planJson)
    {
        var result = new List<string>();

        query = $"{planJson} {query}";

        var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ?? throw new ArgumentNullException("AZURE_OPENAI_ENDPOINT");
        var key = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY") ?? throw new ArgumentNullException("AZURE_OPENAI_API_KEY");
        var assistantID = Environment.GetEnvironmentVariable("AZURE_OPENAI_ASSISTANT_ID") ?? throw new ArgumentNullException("AZURE_OPENAI_ASSISTANT_ID");
        var client = new AssistantsClient(new Uri(endpoint), new AzureKeyCredential(key));

        var thread = await client.CreateThreadAsync();

        // Add a user question to the thread
        var message = await client.CreateMessageAsync(
            thread.Value.Id,
            MessageRole.User,
            query);


        // Run the thread
        ThreadRun run = await client.CreateRunAsync(
            thread.Value.Id,
            new CreateRunOptions(assistantID)
        );

        // Wait for the assistant to respond
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await client.GetRunAsync(thread.Value.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);

        // Get the messages
        PageableList<ThreadMessage> messagesPage = await client.GetMessagesAsync(thread.Value.Id);
        IReadOnlyList<ThreadMessage> messages = messagesPage.Data;

        // Note: messages iterate from newest to oldest, with the messages[0] being the most recent
        foreach (ThreadMessage threadMessage in messages.Reverse())
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (var contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    Console.Write(textItem.Text);
                    result.Add(textItem.Text);
                }
                Console.WriteLine();
                result.Add("\r\n");
            }
        }

        return result;
    }
}
