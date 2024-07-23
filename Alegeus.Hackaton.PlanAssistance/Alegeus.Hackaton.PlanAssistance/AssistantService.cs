namespace Alegeus.Hackaton.PlanAssistance;

using Azure;
using Azure.AI.OpenAI.Assistants;
using Microsoft.Extensions.Caching.Memory;
using OpenAI.Files;

public class AssistantService(IMemoryCache cache)
{
    private const string CachePrefix = "PlanAssistant-";
    public const string HardcodedAdministratorId = "tpa001";

    public async Task<IList<string>> ChatWithAssistant(string product, string administratorId, string query, string planJson)
    {
        var result = new List<string>();

        //query = $"{planJson} {query}";

        var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ?? throw new ArgumentNullException("AZURE_OPENAI_ENDPOINT");
        var key = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY") ?? throw new ArgumentNullException("AZURE_OPENAI_API_KEY");
        var assistantID = Environment.GetEnvironmentVariable("AZURE_OPENAI_ASSISTANT_ID") ?? throw new ArgumentNullException("AZURE_OPENAI_ASSISTANT_ID");
        var client = new AssistantsClient(new Uri(endpoint), new AzureKeyCredential(key));

        var threadId = cache.Get<string>(this.GetSessionId(product, administratorId));
        var thread = !string.IsNullOrWhiteSpace(threadId) ? await client.GetThreadAsync(threadId) : null;
        thread = thread?.Value != null ? thread : await client.CreateThreadAsync();
        threadId = thread.Value.Id;
        cache.Set(this.GetSessionId(product, administratorId), threadId);

        // Add a user question to the thread
        var message = await client.CreateMessageAsync(
            threadId,
            MessageRole.User,
            query);

        // Run the thread
        ThreadRun run = await client.CreateRunAsync(
            threadId,
            new CreateRunOptions(assistantID)
        );

        // Wait for the assistant to respond
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await client.GetRunAsync(threadId, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);

        if (run.Status == RunStatus.Failed)
        {
            result.Add($"Execution failed. {run.LastError.Code}: {run.LastError.Message}");
            return result;
        }

        // Get the messages
        PageableList<ThreadMessage> messagesPage = client.GetMessages(threadId);
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

                if (contentItem is MessageImageFileContent imageFileContent)
                {
                    var imageInfo = await client.GetFileAsync(imageFileContent.FileId);
                    BinaryData imageBytes = await client.GetFileContentAsync(imageFileContent.FileId);
                    using FileStream stream = File.OpenWrite($"{imageInfo.Value.Filename}.png");
                    imageBytes.ToStream().CopyTo(stream);
                    result.Add($"<image: {imageInfo.Value.Filename}.png>");
                    Console.WriteLine($"<image: {imageInfo.Value.Filename}.png>");
                }

                Console.WriteLine();
                result.Add("\r\n");
            }
        }

        return result;
    }

    public void ClearSession(string product, string administratorId)
    {
        cache.Remove(this.GetSessionId(product, administratorId));
    }

    private string GetSessionId(string product, string administratorId)
    {
        return $"{CachePrefix}{product}-{administratorId}";
    }
}
