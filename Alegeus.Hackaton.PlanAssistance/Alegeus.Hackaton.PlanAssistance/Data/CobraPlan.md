# CobraPlan Class

## Description
The `CobraPlan` class contains the plan settings and rates for COBRA and Direct Billing Benefit Administration. It includes information about the plan fees, the who is eligible for a plan and what rates are offered.

## Fields
- `PlanId`: A guid representing the unique identifier for the COBRA Plan.
- `Employer`: Contains information about the employer that sponsors the plan.
- `CarrierName`: The carrier that provides the plan.
- `PlanName`: The name of the plan offered by the carrier.
- `BenefitType`: The type of benefit the plan covers.
- `CarrierAdminFeePercentage`: The percentage of the premium that the carrier takes in fees every billing cycle.
- `CarrierAdminFee`: A fixed amount that the carrier takes in fees every billing cycle.
- `DisabilityExtensionCarrierAdminFee`: A fixed amount that the carrier takes in fees every billing cycle for disability extensions.
- `DisabilityExtensionCarrierAdminFeePercentage`: The percentage of the premium that the carrier takes in fees every billing cycle for disability extensions.
- `DisabilityExtensionEmployerAdminFee`: A fixed amount that the employer takes in fees every billing cycle for disability extensions.
- `DisabilityExtensionTpaAdminFeePercentage`: The percentage of the premium that the TPA takes in fees every billing cycle for disability extensions.
- `EmployerAdminFee`: A fixed amount that the employer takes in fees every billing cycle.
- `EmployerAdminFeePercentage`: The percentage of the premium that the employer takes in fees every billing cycle.
- `StartOfPlanYearDay`: When day of the month does the plan year start. This is typically 1/1, but doesn't have to be.
- `StartOfPlanYearMonth`: When month of the year does the plan year start. This is typically 1/1, but doesn't have to be.
- `TpaAdminFee`: A fixed amount that the tpa takes in fees every billing cycle.
- `TpaAdminFeePercentage`: The percentage of the premium that the tpa takes in fees every billing cycle.
- `LossOfCoverageDetermination`: todo.
- `ProrationDetermination`: todo.
- `EffectiveStartDate`: The earliest date this plan can be enrolled in.
- `EffectiveEndDate`: The latest date this plan can be enrolled in.
- `IsCobraPlan`: Specifies whether this plan is available to COBRA accounts.
- `DirectBillTypes`: Describess what direct billing types this plan supports. Direct Bill Types supports the following fields:
    - `Name`: The name of the direct billing type.
    - `BillingPeriodFrequency`: Always monthly. Describes how long a billing cycle lasts.
    - `Active`: Whether the direct bill type can be used for new benefit accounts.
    - `GracePeriod`: How long participants have to pay past their due date.
    - `InitialPaymentPeriod`: The amount of time participants have to submit their first payment to enroll.
    - `ElectionPeriod`: The amount of time participants have to declare their intent to elect in the plan.
    - `PremiumDetermination`: Whether premiums are calculated together as a group or different per person.
    - `UsePlanAdministrationFees`: Whether to apply the fees as described by the parent plan.
- `RateTableSets`: Groups plan rates together by different dates and rate table types. Rate Table Sets supports the following fields:
    - `RateTableType`: What type of rate table this is.
    - `EffectiveStartDate`: The earliest date with which a participant could get these rate.
    - `EffectiveEndDate`: The latest date with which a participant could get these rate.
    - `Approved`: Whether the rate has been approved for participants to get these rate.
    - `DemographicToUse`: Whether the primary participant's demographic information is supposed to be used to determine rates, or it should use the actual enrolling participant's demographic information.
    - `RateTableItems`: Describes a single row in a rate table for a specific premium given a set of criteria about an enrollee. Rate Table Items supports the following fields:
        - `Location`: The location with which this rate applies.
        - `CoverageTier`: The coverage tier this rate applies.
        - `Smoking`: The participant's smoking habits this rate applies to.
        - `Gender`: What genders this rate applies to.
        - `Relationship`: What relationship to the primary participant can get this rate.
        - `Premium`: What is the rate.
        - `AgeMinimum`: The youngest a participant can be for this rate.
        - `AgeMaximum`: The oldest a participant can be for this rate.
        - `SpouseAgeMinimum`: The youngest a spouse can be for this rate.
        - `SpouseAgeMaximum`: The oldest a spouse can be for this rate.