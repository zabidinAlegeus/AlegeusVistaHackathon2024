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
    - `InitialElectablePlan`: The plans the primary participant had access to at the time of their qualifying event. References DependentId via CoveredDependentIds property.
    - `ElectedPlans`: The plans with which participants have elections. References DependentId via CoveredDependentIds property.