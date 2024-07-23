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
        - `Contribution`: How much of a contribution to make for this plan.
        - `Location`: Locations of the participants for this plan.
        - `Smoking`: Smoking habit of the participants for this plan.
        - `CoverageAmount`: How much to cover for this plan.
        - `DoesCoverPrimaryParticipant`: If the primary participant is electing in the plan.
        - `CoveredDependentIds`: Describe what dependents have enrolled on this plan. This is an ID that references the DependentId property of the dependent.
    - `ElectedPlans`: The plans with which participants have elections. References DependentId via CoveredDependentIds property. 
        - `StartDate`: The first day the participant is electing in for this plan. Often 1/1.
        - `EndDate`: The last day the participant is electing in for this plan. Often 12/31.
        - `Contribution`: How much of a contribution to make for this plan.
        - `Location`: Locations of the participants for this plan.
        - `Smoking`: Smoking habit of the participants for this plan.
        - `CoverageAmount`: How much to cover for this plan.
        - `DoesCoverPrimaryParticipant`: If the primary participant is electing in the plan.
        - `CoveredDependentIds`: Describe what dependents have enrolled on this plan. This is an ID that references the DependentId property of the dependent.
