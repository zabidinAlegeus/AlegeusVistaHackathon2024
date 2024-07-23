namespace Alegeus.Hackaton.PlanAssistance.Apis;

using Microsoft.AspNetCore.Mvc;

public static class ChatApi
{
    public record Dto(string Message);

    public static void AddChat(this WebApplication app)
    {
        app.MapPost("/chat", async (
                [FromServices] AssistantService assistant,
                [FromBody] Dto dto) =>
        {
            var result = await assistant.ChatWithAssistant(dto.Message);
            return result;
        })
        .WithName("Chat")
        .WithOpenApi();
    }
}
