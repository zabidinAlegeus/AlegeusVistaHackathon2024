namespace Alegeus.Hackaton.PlanAssistance.Apis;

using Alegeus.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ChatDto
{
    public string Message { get; set; }
}

public static class WcaChatApi
{
    private const string ProductName = "WCA";

    public static async Task AddChat(this WebApplication app)
    {
        var planJson = await File.ReadAllTextAsync(".\\Data\\WCABenefitPlan.json");
        var participantJson = await File.ReadAllTextAsync(".\\Data\\Participant.json");
        var employerJson = await File.ReadAllTextAsync(".\\Data\\Employer.json");

        app.MapPost("/wca-chat", async (
                [FromServices] AssistantService assistant,
                [FromBody] ChatDto dto) =>
        {
            IList<string> result;

            if (!dto.Message.StartsWith("Admin"))
            {
                var messageSplit = dto.Message.Split(":");
                if(messageSplit.Length == 2)
                {
                    var name = messageSplit.FirstOrDefault();
                    dto.Message = messageSplit.LastOrDefault();

                    result = await assistant.ChatWithAssistant(ProductName, AssistantService.HardcodedAdministratorId, dto.Message, GetParticipantInfo(name));
                    return result.LastOrDefault(x => !string.IsNullOrWhiteSpace(x)) ?? "No response generated.";
                }              
            }

            result = await assistant.ChatWithAssistant(ProductName, AssistantService.HardcodedAdministratorId, dto.Message, planJson, participantJson, employerJson);
            return result.LastOrDefault(x => !string.IsNullOrWhiteSpace(x)) ?? "No response generated.";
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

    public static string GetParticipantInfo(string name)
    {
        string jsonFilePath = ".\\Data\\Participant.json";
        string json = File.ReadAllText(jsonFilePath);
        JsonDocument document = JsonDocument.Parse(json);

        foreach (JsonElement rootElement in document.RootElement.EnumerateArray())
        {
            foreach (JsonElement participantElement in rootElement.GetProperty("Participant").EnumerateArray())
            {
                string firstName = participantElement.GetProperty("FirstName").GetString();
                string lastName = participantElement.GetProperty("LastName").GetString();
                if (firstName + lastName == name)
                {
                    return participantElement.ToString();
                }
            }
        }

        return string.Empty;
    }
}
