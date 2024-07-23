using Alegeus.Hackaton.PlanAssistance;
using Microsoft.AspNetCore.SignalR.Client;

namespace TestChatClient;

public class ClientHub
{
    private static readonly HubConnection _hub = new HubConnectionBuilder()
        .WithUrl("http://localhost:5239/chatHub")
        .Build();

    public async Task ConnectAsync()
    {
        await _hub.StartAsync();
    }

    public async Task SendAsync(string message)
    {
        await _hub.InvokeAsync(nameof(ChatHub.SendMessage), message);
    }
}
