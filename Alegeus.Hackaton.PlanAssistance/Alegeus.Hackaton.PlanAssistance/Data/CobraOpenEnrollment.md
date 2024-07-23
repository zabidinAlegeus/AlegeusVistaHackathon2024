# CobraOpenEnrollment Class

## Description
The `CobraOpenEnrollment` class contains information about a participant's COBRA or Direct Billing Benefit Account, as well as plans that are available to them during open enrollment. The Coverage includes details about which participants are enrolled on what plans at what times.

## Fields
- `PlanId`: A guid representing the unique identifier for the COBRA Plan.

// TODO: Write markdown for these dtos.
public record OpenEnrollmentDto(
    List<PlanDto> AvailablePlans,
    CoverageDto Coverage);

public record CoverageDto(
    CobraDetailsDto? Cobra,
    DirectBillDetailsDto? DirectBill,
    PrimaryParticipantDto PrimaryParticipant,
    List<CoverageWindowDto> CoverageWindows,
    List<DependentDto> Dependents,
    List<InitialElectablePlanDto> InitialElectablePlan,
    List<ElectedPlanDto> ElectedPlanDto);

public record CobraDetailsDto(QualifyingEventTypeDto QualifyingEventType);
public record DirectBillDetailsDto(DirectBillTypeDto Type);
public record PrimaryParticipantDto(DemographicsDto Demographics, RelationshipToEmployeeEnum RelationshipToEmployee);

public record CoverageWindowDto(
    DateTime LossOfEmployeeCoverageDate,
    DateTime FirstDayOfCoverage,
    DateTime LastPossibleDateOfCoverage);

public record DependentDto(Guid DependentId, DemographicsDto Demographics, bool IsActive);

public record InitialElectablePlanDto(
    PremiumFactorsDto PremiumFactors,
    bool DoesCoverPrimaryParticipant,
    List<Guid> CoveredDependentIds);

public record PremiumFactorsDto(
    decimal Contribution,
    string Location,
    SmokingEnum? Smoking,
    decimal CoverageAmount);

public record ElectedPlanDto(
    DateTime StartDate,
    DateTime EndDate,
    Guid PlanId,
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