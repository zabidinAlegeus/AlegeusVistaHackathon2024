using Microsoft.AspNetCore.Mvc;

namespace Alegeus.Hackaton.PlanAssistance.Apis;

public static class CobraChatApi
{
    private const string ProductName = "Cobra";

    public static async Task AddCobraChats(this WebApplication app)
    {
        //var plan = new Fixture().Create<PlanDto>();
        //var coverage = new Fixture().Create<CoverageDto>();

        //var json1 = JsonSerializer.Serialize(plan,
        //    new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } });

        //var json2 = JsonSerializer.Serialize(coverage,
        //    new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } });

        var planJson = await File.ReadAllTextAsync(".\\Data\\CobraPlan.json");
        app.MapPost("/cobra-admin-plan-chat", async (
                [FromServices] AssistantService assistant,
                [FromBody] ChatDto dto) =>
            {
                var result = await assistant.ChatWithAssistant(ProductName, AssistantService.HardcodedAdministratorId, dto.Message, planJson);
                return result.LastOrDefault(x => !string.IsNullOrWhiteSpace(x)) ?? "No response generated.";
            })
            .WithName("COBRA Admin Plan Chat")
            .WithOpenApi();

        var openEnrollmentJson = await File.ReadAllTextAsync(".\\Data\\CobraOpenEnrollment.json");
        app.MapPost("/cobra-participant-open-enrollment-chat", async (
                [FromServices] AssistantService assistant,
                [FromBody] ChatDto dto) =>
            {
                var result = await assistant.ChatWithAssistant(ProductName, AssistantService.HardcodedAdministratorId, dto.Message, openEnrollmentJson);
                return result.LastOrDefault(x => !string.IsNullOrWhiteSpace(x)) ?? "No response generated.";
            })
            .WithName("COBRA Participant Open Enrollment Chat")
            .WithOpenApi();
    }

    public static async Task AddClearChatSessionCobra(this WebApplication app)
    {
        app.MapPost("/cobra-chat-clear-session", async (
                [FromServices] AssistantService assistant) =>
        {
            assistant.ClearSession(ProductName, AssistantService.HardcodedAdministratorId);
        })
        .WithName("COBRA Chat Clear Session")
        .WithOpenApi();
    }
}
