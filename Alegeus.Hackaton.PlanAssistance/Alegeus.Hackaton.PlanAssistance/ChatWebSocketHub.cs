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
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
