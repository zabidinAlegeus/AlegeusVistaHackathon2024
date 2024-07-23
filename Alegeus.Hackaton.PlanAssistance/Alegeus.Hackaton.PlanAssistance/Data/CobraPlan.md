# CobraPlan Class

## Description
The `CobraPlan` class contains the plan settings and rates for COBRA and Direct Billing Benefit Administration. It includes information about the plan fees, the who is eligible for a plan and what rates are offered.

## Fields
- `PlanId`: A guid representing the unique identifier for the COBRA Plan.

// TODO: Write markdown for DTOs
using Alegeus.Models;

namespace Alegeus.Hackaton.PlanAssistance.Models;

public record PlanDto(
    Guid PlanId,
    EmployerDto Employer,
    string CarrierName,
    string PlanName,
    BenefitType BenefitType,
    decimal CarrierAdminFeePercentage,
    decimal CarrierAdminFee,
    decimal DisabilityExtensionCarrierAdminFee,
    decimal DisabilityExtensionCarrierAdminFeePercentage,
    decimal DisabilityExtensionEmployerAdminFee,
    decimal DisabilityExtensionTpaAdminFeePercentage,
    decimal EmployerAdminFee,
    decimal EmployerAdminFeePercentage,
    int StartOfPlanYearDay,
    int StartOfPlanYearMonth,
    decimal TpaAdminFee,
    decimal TpaAdminFeePercentage,
    LossOfCoverageDetermination LossOfCoverageDetermination,
    ProrationDeterminationEnum ProrationDetermination,
    DateTime EffectiveStartDate,
    DateTime EffectiveEndDate,
    bool IsCobraPlan,
    List<DirectBillTypeDto> DirectBillTypes,
    List<RateTableSetDto> RateTableSets);

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