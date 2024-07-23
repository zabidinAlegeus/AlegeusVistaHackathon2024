namespace Alegeus.Hackaton.PlanAssistance.Apis;

using Microsoft.AspNetCore.Mvc;

public static class ChatApi
{
    public static void AddChat(this WebApplication app)
    {
        app.MapPost("/chat", ([FromBody]string query) =>
        {
            var result = "hi!";
            return result;
        })
            .WithName("Chat")
            .WithOpenApi();
    }
}
