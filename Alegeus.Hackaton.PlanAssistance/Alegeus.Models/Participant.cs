using System;
using System.Collections.Generic;
using System.Text;

namespace Alegeus.Models
{
    public class Participant
    {
        public string TpaId { get; set; }
        public string EmprId { get; set; }
        public int CardholderKey { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SocSecNum { get; set; }
        public string NamePrefix { get; set; }
        public string Initial { get; set; }
        public int CardholderTypeCde { get; set; }
        public string CardNum { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
