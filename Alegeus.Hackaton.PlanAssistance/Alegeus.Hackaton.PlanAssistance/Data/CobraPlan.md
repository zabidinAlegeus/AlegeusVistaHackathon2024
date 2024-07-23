# CobraPlan Class

## Description
The `CobraPlan` class contains the plan settings and rates for COBRA and Direct Billing Benefit Administration. It includes information about the plan fees, the who is eligible for a plan and what rates are offered.

## Fields
- `PlanId`: A guid representing the unique identifier for the COBRA Plan.
- `Employer`: Contains information about the employer that sponsors the plan.
- `CarrierName`: The carrier that provides the plan.
- `PlanName`: The name of the plan offered by the carrier.
- `BenefitType`: The type of benefit the plan covers.
- `CarrierAdminFeePercentage`: todo.
- `CarrierAdminFee`: todo.
- `DisabilityExtensionCarrierAdminFee`: todo.
- `DisabilityExtensionCarrierAdminFeePercentage`: todo.
- `DisabilityExtensionEmployerAdminFee`: todo.
- `DisabilityExtensionTpaAdminFeePercentage`: todo.
- `EmployerAdminFee`: todo.
- `EmployerAdminFeePercentage`: todo.
- `StartOfPlanYearDay`: todo.
- `StartOfPlanYearMonth`: todo.
- `TpaAdminFee`: todo.
- `TpaAdminFeePercentage`: todo.
- `LossOfCoverageDetermination`: todo.
- `ProrationDetermination`: todo.
- `EffectiveStartDate`: todo.
- `EffectiveEndDate`: todo.
- `IsCobraPlan`: todo.
- `DirectBillTypes`: todo.
- `RateTableSets`: todo.

// TODO: Write markdown for DTOs
using Alegeus.Models;

namespace Alegeus.Hackaton.PlanAssistance.Models;

public record DirectBillTypeDto(
    string Name,
    BillingPeriodFrequencyEnum BillingPeriodFrequency,
    bool Active,
    int GracePeriod,
    int InitialPaymentPeriod,
    int ElectionPeriod,
    PremiumDeterminationEnum PremiumDetermination,
    bool UsePlanAdministrationFees);

public record EmployerDto(string Name);

public record QualifyingEventTypeDto(
    string QualifyingEventName,
    DateTime EffectiveStartDate,
    DateTime EffectiveEndDate,
    QualifyingBeneficiaryUnit QualifyingBeneficiaryUnit);

public record RateTableSetDto(
    RateTableTypeEnum RateTableType,
    DateTime EffectiveStartDate,
    DateTime EffectiveEndDate,
    bool Approved,
    UnitDemographicTypeEnum DemographicToUse,
    List<RateTableItemDto> Rates);

public record RateTableItemDto(
    string Location,
    CoverageTierEnum? CoverageTier,
    SmokingEnum? Smoking,
    GenderEnum? Gender,
    RelationshipEnum? Relationship,
    decimal Premium,
    int? AgeMinimum,
    int? AgeMaximum,
    int? SpouseAgeMinimum,
    int? SpouseAgeMaximum);