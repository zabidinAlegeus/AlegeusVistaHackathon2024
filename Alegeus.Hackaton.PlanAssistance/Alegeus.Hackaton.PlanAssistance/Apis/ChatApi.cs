namespace Alegeus.Hackaton.PlanAssistance.Apis;

using Microsoft.AspNetCore.Mvc;

public static class ChatApi
{
    public static void AddChat(this WebApplication app)
    {
        app.MapPost("/chat", async ([FromBody]string query) =>
        {
            var assistantService = new AssistantService();
            var result = await assistantService.ChatWithAssistant(query);
            return result;
        })
            .WithName("Chat")
            .WithOpenApi();
    }
}
