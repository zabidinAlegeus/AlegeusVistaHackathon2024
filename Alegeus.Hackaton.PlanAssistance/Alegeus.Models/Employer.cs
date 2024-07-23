using System;
using System.Collections.Generic;
using System.Text;

namespace Alegeus.Models
{
    public class Employer
    {
        public string AdminId { get; set; }
        public string EmployerId { get; set; }
        public string EmployerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<int> WCABenefitPlanKeys { get; set; }
    }

}
