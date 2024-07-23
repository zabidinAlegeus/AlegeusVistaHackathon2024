using System;

namespace Alegeus.Models
{
    public class WcaBenefitPlan
    {
        public string AdminId { get; set; } = "";
        public string PlanKey { get; set; } = "";
        public string PlanId { get; set; } = "";
        public string EmployerId { get; set; } = "";
        public string AccountType { get; set; } = "";
        public string PlanStartDate { get; set; } = "";
        public string PlanEndDate { get; set; } = "";
        public string ByPassAutoDeposit { get; set; } = "";
        public string MaxTransactionAmount { get; set; } = "";
        public string PlanDesingKey { get; set; } = "";
        public string Status { get; set; } = "";
        public string InsertDate { get; set; } = "";
        public string InsertUserId { get; set; } = "";
        public string UpdateDate { get; set; } = "";
        public string UpdateUserId { get; set; } = "";
        public string ExtensionDate { get; set; } = "";
        public string PlanOptions { get; set; } = "";
    }
}
