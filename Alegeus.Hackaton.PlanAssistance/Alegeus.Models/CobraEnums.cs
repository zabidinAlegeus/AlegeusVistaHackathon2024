namespace Alegeus.Models
{
    public enum RelationshipToEmployeeEnum
    {
        Spouse = 0,
        Child = 1,
        DomesticPartner = 2,
        Employee = 3
    }

    public enum BillingPeriodFrequencyEnum
    {
        Monthly = 0
    }

    public enum PremiumDeterminationEnum
    {
        DeterminedByPlan = 0,
        IndividuallyRated = 1
    }

    public enum AgeDeterminationType
    {
        StartOfPlanYear = 0,
        BillingDueDate = 1,
        NearestBirthdayOnDueDate = 2,
        NearestBirthdayOnStartOfPlanYear = 3,
        MonthOfBillingDueDate = 4
    }

    public enum LossOfCoverageDetermination
    {
        DateOfQualifyingEvent = 0,
        EndOfMonth = 1,
        EndOfPriorMonth = 2,
        RollRoll = 3,
        WashRoll = 4,
        EndOfNextMonth = 5
    }

    public enum RateTableTypeEnum
    {
        Composite = 0,
        MemberLevel = 1,
        UnitBased = 2
    }

    public enum CoverageTierEnum
    {
        Ee = 0,
        EePlusSpouse = 1,
        EePlusChild = 2,
        EePlusChildren = 3,
        EePlusChildOrChildren = 4,
        EePlusFamily = 5,
        EePlusOneDependent = 6,
        EePlusTwoDependents = 7,
        EePlusTwoOrMoreDependents = 8,
        EePlusThreeOrMoreDependents = 9,
        SpouseOnly = 10,
        SpousePlusChild = 11,
        SpousePlusChildren = 12,
        SpousePlusChildOrChildren = 13,
        ChildOnly = 14,
        ChildrenOnly = 15,
        ChildOrChildrenOnly = 16,
        OneOrMorePeople = 17,
        EePlusTwoChildren = 18,
        EePlusThreeChildren = 19,
        EePlusThreeDependents = 20,
        EePlusFourOrMoreDependents = 21,
        EePlusTwoOrMoreChildren = 22,
        EePlusThreeOrMoreChildren = 23,
        EePlusFourOrMoreChildren = 24,
        TwoChildren = 25,
        ThreeChildren = 26,
        TwoOrMoreChildren = 27,
        ThreeOrMoreChildren = 28,
        FourOrMoreChildren = 29,
        EePlusSpousePlusChild = 30,
        EePlusSpousePlusOneOrTwoChildren = 31,
        EePlusSpousePlusTwoChildren = 32,
        EePlusSpousePlusThreeChildren = 33,
        EePlusSpousePlusThreeOrMoreChildren = 34,
        EePlusSpousePlusFourOrMoreChildren = 35,
        SpousePlusOneOrTwoChildren = 36,
        SpousePlusTwoChildren = 37,
        SpousePlusThreeChildren = 38,
        SpousePlusThreeOrMoreChildren = 39,
        SpousePlusFourOrMoreChildren = 40
    }

    public enum SmokingEnum
    {
        NonSmoking = 0,
        Smoking = 1,
        OneSmoker = 2,
        TwoOrMoreSmoker = 3
    }

    public enum GenderEnum
    {
        Male = 0,
        Female = 1,
        SomethingElse = 2
    }

    public enum RelationshipEnum
    {
        Subscriber = 0,
        Spouse = 1,
        Child = 2,
        FirstChild = 3,
        SecondChild = 4,
        ThirdChild = 5,
        ThirdOrGreaterChild = 6,
        FourthOrGreaterChild = 7
    }

    public enum ProrationDeterminationEnum
    {
        NumberOfDaysInMonth = 0,
        ThirtyDaysInEachMonth = 1
    }

    public enum CommunicationTypeEnum
    {
        Email = 0,
        Edi834 = 1,
        Edi834AndEmail = 2,
        NoEnrollmentCommunicationsSent = 3
    }

    public enum PaidThroughDateInCommEnum
    {
        PaidThroughDateInCommEnumUseEmployerConfig = 0,
        PaidThroughDateInCommEnumForceInclude = 1,
        PaidThroughDateInCommEnumForceExclude = 2
    }

    public enum UnitDemographicTypeEnum
    {
        Member = 0,
        PrimaryParticipant = 1
    }

    public enum UnitDeterminationTypeEnum
    {
        Individual = 0,
        Increment = 1
    }

    public enum QualifyingBeneficiaryUnit
    {
        EmployeeSpouseAndDependents = 0,
        SpouseAndDependents = 1,
        OneDependentOnly = 2,
        RetireeSpouseAndDependents = 3
    }

    public enum BenefitType
    {
        Medical = 0,
        Dental = 1,
        Vision = 2,
        Fsa = 3,
        Hra = 4,
        Eap = 5,
        Rx = 6,
        AdAndD = 7,
        Ltd = 8,
        Life = 9,
        DependentLife = 10,
        DependentLife2 = 11,
        DependentLife3 = 12,
        VoluntaryLife = 13,
        Accident = 14,
        Benefit = 15,
        Cancer = 16,
        Chiropractic = 17,
        CriticalIllness = 18,
        Gap = 19,
        GroupLife = 20,
        Merp = 21,
        Msa = 22,
        Rider = 23,
        Rider2 = 24,
        Rider3 = 25,
        Std = 26,
        Veba = 27,
        Vision2 = 28,
        Vision3 = 29,
        Voluntary = 30,
        Retirement401K = 31,
        EnhancedRx = 32,
        FamilyPlanning = 33,
        Fertility = 34,
        Hsa = 35,
        MentalHealth = 36,
        Option1 = 37,
        Option2 = 38,
        Option3 = 39,
        Option4 = 40,
        Option5 = 41,
        Pba = 42
    }
}
