using Alegeus.Models;

namespace Alegeus.Hackaton.PlanAssistance.Models;

public record OpenEnrollmentDto(
    List<AvailablePlanDto> AvailablePlans,
    CoverageDto Coverage);

public record CoverageDto(
    CobraDetailsDto? Cobra,
    DirectBillDetailsDto? DirectBill,
    PrimaryParticipantDto PrimaryParticipant,
    List<CoverageWindowDto> CoverageWindows,
    List<DependentDto> Dependents,
    List<InitialElectablePlanDto> InitialElectablePlans,
    List<ElectedPlanDto> ElectedPlans);

public record CobraDetailsDto(QualifyingEventTypeDto QualifyingEventType);
public record DirectBillDetailsDto(DirectBillTypeDto Type);
public record PrimaryParticipantDto(DemographicsDto Demographics, RelationshipToEmployeeEnum RelationshipToEmployee);

public record CoverageWindowDto(
    BenefitType BenefitType,
    DateTime LossOfEmployeeCoverageDate,
    DateTime FirstDayOfCoverage,
    DateTime LastPossibleDateOfCoverage);

public record DependentDto(Guid DependentId, DemographicsDto Demographics, bool IsActive);

public record InitialElectablePlanDto(
    PlanDto Plan,
    PremiumFactorsDto PremiumFactors,
    bool DoesCoverPrimaryParticipant,
    List<Guid> CoveredDependentIds);

public record PremiumFactorsDto(
    decimal Contribution,
    string Location,
    SmokingEnum? Smoking,
    decimal CoverageAmount);

public record ElectedPlanDto(
    PlanDto Plan,
    DateTime StartDate,
    DateTime EndDate,
    PremiumFactorsDto PremiumFactors,
    bool DoesCoverPrimaryParticipant,
    List<Guid> CoveredDependentIds);

public record DemographicsDto(
    string LastName,
    string FirstName,
    string Ssn,
    string NamePrefix,
    string Initial,
    DateTime? DateOfBirth,
    GenderEnum? Gender,
    bool? IsTobaccoUser);