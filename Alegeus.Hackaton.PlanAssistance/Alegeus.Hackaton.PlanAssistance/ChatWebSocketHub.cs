using Microsoft.AspNetCore.SignalR;

namespace Alegeus.Hackaton.PlanAssistance;

public static class ChatWebSocketHub
{
    public static void AddChatHub(this WebApplication app)
    {
        app.MapHub<ChatHub>("/chatHub");
    }
}

public class ChatHub : Hub
{
    private readonly AssistantService _assistant;

    public ChatHub(AssistantService assistant)
    {
        _assistant = assistant;
    }

    public async Task SendMessage(string message)
    {
        var aiResponse = await _assistant.ChatWithAssistant(AssistantService.HardcodedAdministratorId, message);
        await Clients.All.SendAsync("ReceiveMessage", aiResponse);
    }
}
