using Microsoft.AspNetCore.Mvc;

namespace Alegeus.Hackaton.PlanAssistance.Apis;

public static class CobraChatApi
{
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
                var result = await assistant.ChatWithAssistant(dto.Message, planJson);
                return string.Join(Environment.NewLine, result); // TODO: just last response
            })
            .WithName("COBRA Admin Plan Chat")
            .WithOpenApi();

        var openEnrollmentJson = await File.ReadAllTextAsync(".\\Data\\CobraOpenEnrollment.json");
        app.MapPost("/cobra-participant-open-enrollment-chat", async (
                [FromServices] AssistantService assistant,
                [FromBody] ChatDto dto) =>
            {
                var result = await assistant.ChatWithAssistant(dto.Message, openEnrollmentJson);
                return string.Join(Environment.NewLine, result); // TODO: just last response
            })
            .WithName("COBRA Participant Open Enrollment Chat")
            .WithOpenApi();
    }
}
