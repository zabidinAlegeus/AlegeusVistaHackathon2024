# Claim Class

## Description
The `Claim` class represents claims related to participant transactions within the Alegeus system. It includes various fields that provide information about the transaction, such as transaction date, service start date, service end date, and transaction type.

## Fields
- `AdminId`: A unique identifier used to identify your admin instance. ...
- `EmployerId`: Unique identifier for the employer. Note: WealthCare Admin assigns the 3-character prefix; ...
- `TransactionDate`: Date of the transaction.
- `ServiceStartDate`: Service Start Date for the claim.
- `ServiceEndDate`: Service End Date for the claim.
- `Type`: A code indicating the type of transaction:
- `TxnCde`: Transaction Code
- `TxnMsg`: Transaction Message
- `TxnAmtRefund`: Transaction Refund Amount
- `TxnOriginCde`: Transaction Origin Code: None = 0, POSCardSwipe = 1, POSKeyedIn = 2, ...
- `CardHolderDisplay`: True if the claim the receipt is attached to should display to the participant. ...
- `ProviderId`: Provider Id on the claim
- `ProviderDesc`: Provider Description on the claim
- `HasReceipt`: True if the claim has a receipt attached to it.
- `ReceiptExpired`: Returns true if the receipt has expired.
- `ReceiptsInfo`: Receipt Information
- `AcctTypeCde`: The account type code for the benefit account the claim is processed under.
- `AcctTypeDesc`: The account type description for the benefit account the claim is processed under.
- `PlanStartDate`: Plan Start Date for the account the claim is processed under.
- `PlanEndDate`: Plan End Date for the account the claim is processed under.
- `Status`: Claim status
- `TxnAmt`: Transaction Amount
- `TxnAmtDenied`: Transaction Denied Amount
- `TxnAmtPending`: Transaction Pending Amount
- `DocId`: A system generated ID created when a file is submitted through a document queue instead of by a participant.
- `DocDisplayName`: Document Display Name
- `OriginalFileName`: Original File Name
- `UploadDate`: The date the receipt file was uploaded.