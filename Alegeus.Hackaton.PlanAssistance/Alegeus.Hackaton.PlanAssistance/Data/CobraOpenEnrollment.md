# Claim Class

## Description
The `Claim` class represents claims related to participant transactions within the Alegeus system. It includes various fields that provide information about the transaction, such as transaction date, service start date, service end date, and transaction type.

## Fields
- `TpaId`: A unique identifier used to identify your admin instance. ...
- `EmployerId`: Unique identifier for the employer. Note: WealthCare Admin assigns the 3-character prefix; ...
- `TransactionDate`: Date of the transaction.
- `ServiceStartDate`: Service Start Date for the claim.
- `ServiceEndDate`: Service End Date for the claim.
- `Type`: A code indicating the type of transaction:
- `TxnCde`: Transaction Code
- `TxnMsg`: Transaction Message
- `TxnAmtRefund`: Transaction Refund Amount
- `TxnOriginCde`: Transaction Origin Code: None = 0, POSCardSwipe = 1, POSKeyedIn = 2, ...
- `TxnOptions`: Transaction Options
- `CardHolderDisplay`: True if the claim the receipt is attached to should display to the participant. ...
- `ProviderId`: Provider Id on the claim
- `ProviderDesc`: Provider Description on the claim
- `FileKey`: A system generated ID used to identify the receipt just uploaded.
- `HasReceipt`: True if the claim has a receipt attached to it.
- `ReceiptExpired`: Returns true if the receipt has expired.
- `ReceiptsInfo`: Receipt Information
- `DisplayableFields`: Displayable Fields
- `AcctTypeCde`: The account type code for the benefit account the claim is processed under.
- `AcctTypeDesc`: The account type description for the benefit account the claim is processed under.
- `AccountKey`: A system-generated ID for the benefit account the claim is processed under.
- `PlanStartDate`: Plan Start Date for the account the claim is processed under.
- `PlanEndDate`: Plan End Date for the account the claim is processed under.
- `Status`: Claim status
- `TxnAmt`: Transaction Amount
- `FlexAcctKey`: A system-generated ID for the benefit account the claim is processed under. Same value as AccountKey.
- `TxnAmtOrig`: Original Transaction Amount
- `TxnAmtDenied`: Transaction Denied Amount
- `TxnAmtPending`: Transaction Pending Amount
- `FileKey`: A system generated ID used to identify the receipt file.
- `DocId`: A system generated ID created when a file is submitted through a document queue instead of by a participant.
- `DocDisplayName`: Document Display Name
- `OriginalFileName`: Original File Name
- `UploadDate`: The date the receipt file was uploaded.

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