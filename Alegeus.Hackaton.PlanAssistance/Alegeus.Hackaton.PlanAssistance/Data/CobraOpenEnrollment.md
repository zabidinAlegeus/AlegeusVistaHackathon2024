# CobraOpenEnrollment Class

## Description
The `CobraOpenEnrollment` class contains information about a participant's COBRA or Direct Billing Benefit Account, as well as plans that are available to them during open enrollment. The Coverage includes details about which participants are enrolled on what plans at what times.

## Fields
- `AvailablePlans`: Contains information about plans being offered to the participant during open enrollment.
- `Coverage`: Contains information about the participant's benefit account. Includes information about which family members are on which plans and what times. The following fields are part of Coverage:
    - `Cobra`: Describes COBRA specific information about the account. This will be missing if this is a direct billing account.
    - `DirectBill`: Describes Direct Billing specific information about the account. This will be missing if this is a COBRA account.
    - `PrimaryParticipant`: Is the account holder. Includes demographic data about the participant.
    - `CoverageWindows`: Describes what periods of time different benefits are available to the participant.
    - `Dependent`: The primary participant's dependents. Includes demographic data about the participant. Dependents have a DependentId, which are reference by the plans to keep track of Elections.
    - `InitialElectablePlan`: The plans the primary participant had access to at the time of their qualifying event.
    - `ElectedPlans`

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
    List<InitialElectablePlanDto> InitialElectablePlans,
    List<ElectedPlanDto> ElectedPlans);

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