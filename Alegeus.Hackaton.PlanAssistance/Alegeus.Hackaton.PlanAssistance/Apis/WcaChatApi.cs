﻿namespace Alegeus.Hackaton.PlanAssistance.Apis;

using Microsoft.AspNetCore.Mvc;

public record ChatDto(string Message);

public static class WcaChatApi
{
    private const string ProductName = "WCA";

    public static async Task AddChat(this WebApplication app)
    {
        var planJson = await File.ReadAllTextAsync(".\\Data\\BenefitPlan.json");;

        app.MapPost("/wca-chat", async (
                [FromServices] AssistantService assistant,
                [FromBody] ChatDto dto) =>
        {
            var result = await assistant.ChatWithAssistant(ProductName, AssistantService.HardcodedAdministratorId, dto.Message, planJson);
            return string.Join(Environment.NewLine, result); // TODO: just last response
        })
        .WithName("WCA Chat")
        .WithOpenApi();
    }

    public static async Task AddClearChatSessionWca(this WebApplication app)
    {
        app.MapPost("/wca-chat-clear-session", async (
                [FromServices] AssistantService assistant) =>
        {
            assistant.ClearSession(ProductName, AssistantService.HardcodedAdministratorId);
        })
        .WithName("WCA Chat Clear Session")
        .WithOpenApi();
    }
}
