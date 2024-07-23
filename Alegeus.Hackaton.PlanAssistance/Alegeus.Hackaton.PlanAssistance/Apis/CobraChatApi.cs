using Alegeus.Hackaton.PlanAssistance.Models;
using Alegeus.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Alegeus.Hackaton.PlanAssistance.Apis;

public static class CobraChatApi
{
    private const string ProductName = "Cobra";

    public static async Task AddCobraChats(this WebApplication app)
    {
        //var testPlan = new PlanDto(
        //    Guid.NewGuid(),
        //    new("Walmart"),
        //    "Aetna",
        //    "Standard",
        //    BenefitType.Medical,
        //    0m,
        //    0m,
        //    0m,
        //    0m,
        //    0m,
        //    2m,
        //    0m,
        //    0m,
        //    1,
        //    12,
        //    0m,
        //    2m,
        //    LossOfCoverageDetermination.EndOfMonth,
        //    ProrationDeterminationEnum.NumberOfDaysInMonth,
        //    new DateTime(2020, 1, 1),
        //    null,
        //    true,
        //    [],
        //    [
        //        new(
        //            RateTableTypeEnum.Composite,
        //            new DateTime(2023, 12, 1),
        //            new DateTime(2024, 11, 30),
        //            true,
        //            UnitDemographicTypeEnum.Member,
        //            [
        //                new("", CoverageTierEnum.Ee, null, null, null, 663.00m, null, null, null, null),
        //                new("", CoverageTierEnum.EePlusSpouse, null, null, null, 1312.75m, null, null, null, null),
        //                new("", CoverageTierEnum.EePlusChildren, null, null, null, 1253.08m, null, null, null, null),
        //                new("", CoverageTierEnum.EePlusFamily, null, null, null, 1902.83m, null, null, null, null),
        //            ])
        //    ]);

        //var guid1 = Guid.NewGuid();
        //var guid2 = Guid.NewGuid();
        //var openEnrollment = new OpenEnrollmentDto(
        //    [],
        //    new(
        //        new(new("Termination - Voluntary", null, null, QualifyingBeneficiaryUnit.EmployeeSpouseAndDependents)),
        //        null,
        //        new(
        //            new("Benson", "Cody", "342332423", "", "", new(1975, 8, 13), GenderEnum.Male, null),
        //            RelationshipToEmployeeEnum.Employee),
        //        [
        //            new(BenefitType.Medical, new(2024, 7, 31), new(2024, 8, 1), new(2026, 1, 31))
        //        ],
        //        new(){
        //            new(guid1, new("Benson", "Marsha", "", "", "", new(1980, 1, 23), GenderEnum.Female, null), true),
        //            new(guid2, new("Benson", "Sammy", "", "", "", new(2015, 1, 5), GenderEnum.Male, null), true)
        //        },
        //        [
        //            new(new(0m, "", null, 0m), true, [guid1, guid2])
        //        ],
        //        new()));

        //var json2 = JsonSerializer.Serialize(openEnrollment,
        //    new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } });
        //var json1 = JsonSerializer.Serialize(testPlan,
        //    new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } });

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
