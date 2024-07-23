using System;

namespace Alegeus.Models
{
    public class BenefitPlan
    {
        public string tpa_id { get; set; }
        public string plan_key { get; set; }
        public string plan_id { get; set; }
        public string empr_id { get; set; }
        public string acct_type_cde { get; set; }
        public string plan_yr_start_dte { get; set; }
        public string plan_yr_end_dte { get; set; }
        public string conv_fee_payor_cde { get; set; }
        public string pay_cycle_type_cde { get; set; }
        public string bypass_auto_deposit { get; set; }
        public string conv_fee_amt { get; set; }
        public string max_txn_amt { get; set; }
        public string max_total_txn_amt { get; set; }
        public string plan_design_key { get; set; }
        public string default_plan { get; set; }
        public string ndc_match_cde { get; set; }
        public string plan_status_cde { get; set; }
        public string insert_dte { get; set; }
        public string insert_user_id_key { get; set; }
        public string update_dte { get; set; }
        public string update_user_id_key { get; set; }
        public string trigger_delete { get; set; }
        public string interval_cde { get; set; }
        public string interval_tot_dep_amt { get; set; }
        public string interval_tot_txn_amt { get; set; }
        public string eff_dte { get; set; }
        public string hra_type { get; set; }
        public string plan_yr_ext_dte { get; set; }
        public string plan_options { get; set; }
        public string life_event_calc_method { get; set; }
        public string rollover_balance_max { get; set; }
        public string individual_balance_max { get; set; }
        public string coverage_tier_type_key { get; set; }
        public string default_coverage_tier_key { get; set; }
        public string default_deposit_calendar_key { get; set; }
        public string fixed_empr_funding_calendar_key { get; set; }
        public string manual_claim_percent_coverage { get; set; }
        public string internal_plan_options { get; set; }
        public string auto_deposit_start_dte { get; set; }
        public string auto_deposit_end_dte { get; set; }
        public string annual_elect_min { get; set; }
        public string annual_elect_max { get; set; }
        public string mcc_flags { get; set; }
        public string term_empe_run_out_days { get; set; }
        public string plan_options2 { get; set; }
        public string custom_description { get; set; }
        public string link_plan_key { get; set; }
    }

}
