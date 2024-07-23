namespace Alegeus.Hackaton.PlanAssistance.Apis;

using Microsoft.AspNetCore.Mvc;

public record ChatDto(string Message);

public static class WcaChatApi
{
    public static async Task AddChat(this WebApplication app)
    {
        var planJson = await File.ReadAllTextAsync(".\\Data\\BenefitPlan.json");;

        app.MapPost("/wca-chat", async (
                [FromServices] AssistantService assistant,
                [FromBody] ChatDto dto) =>
        {
            var result = await assistant.ChatWithAssistant(dto.Message, planJson);
            return result;
        })
        .WithName("WCA Chat")
        .WithOpenApi();
    }
}
