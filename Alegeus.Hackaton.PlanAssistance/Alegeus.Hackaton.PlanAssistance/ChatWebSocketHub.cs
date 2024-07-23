﻿using Microsoft.AspNetCore.SignalR;

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

    public Task SendMessage(string message)
    {
        return Task.CompletedTask;
    //    var aiResponse = await _assistant.ChatWithAssistant(message);
    //    await Clients.All.SendAsync("ReceiveMessage", aiResponse);
    }
}