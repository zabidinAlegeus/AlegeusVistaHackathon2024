using System;
using System.Collections.Generic;
using System.Text;

namespace Alegeus.Models
{
    public class Claim
    {
        public string AdminId { get; set; }
        public string EmployerId { get; set; }
        public string TransactionDate { get; set; }
        public string ServiceStartDate { get; set; }
        public string ServiceEndDate { get; set; }
        public string Type { get; set; }
        public string AcctTypeCde { get; set; }
        public string AcctTypeDesc { get; set; }
        public int AccountKey { get; set; }
        public string PlanStartDate { get; set; }
        public string PlanEndDate { get; set; }
        public string Status { get; set; }
        public int TxnAmt { get; set; }
        public int FlexAcctKey { get; set; }
        public int TxnAmtOrig { get; set; }
        public int TxnAmtDenied { get; set; }
        public int TxnAmtPending { get; set; }
        public int TxnCde { get; set; }
        public string TxnMsg { get; set; }
        public int TxnAmtRefund { get; set; }
        public int TxnOriginCde { get; set; }
        public int TxnOptions { get; set; }
        public bool CardHolderDisplay { get; set; }
        public string ProviderId { get; set; }
        public string ProviderDesc { get; set; }
        public int FileKey { get; set; }
        public bool HasReceipt { get; set; }
        public bool ReceiptExpired { get; set; }
        public List<ReceiptsInfo> ReceiptsInfo { get; set; }
        public List<DisplayableFields> DisplayableFields { get; set; }
        public string InsertDate { get; set; }
        public string UpdateDte { get; set; }
        public int InsertUserIdKey { get; set; }
        public int UpdateUserIdKey { get; set; }
        public int ExpenseKey { get; set; }
    }
    
    public class ReceiptsInfo
    {
        public string TpaId { get; set; }
        public int FileKey { get; set; }
        public string DocId { get; set; }
        public string DocDisplayName { get; set; }
        public string OriginalFileName { get; set; }
        public string UploadDate { get; set; }
    }

    public class DisplayableFields
    {
        public string OriginalFieldName { get; set; }
        public string AlternativeFieldName { get; set; }
        public int DisplayOptions { get; set; }
        public int DisplaySpecifications { get; set; }
    }
}
