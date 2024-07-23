namespace Alegeus.Hackaton.PlanAssistance.Apis;

using Microsoft.AspNetCore.Mvc;

public record ChatDto(string Message);

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
            var result = await assistant.ChatWithAssistant(ProductName, AssistantService.HardcodedAdministratorId, dto.Message, planJson, participantJson, employerJson);
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
}
