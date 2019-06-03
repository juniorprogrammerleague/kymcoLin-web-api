using System;
using System.Collections.Generic;

namespace kymcoLin_Entities.DBModels
{
    public partial class Account
    {
        public int No { get; set; }
        public string Account1 { get; set; }
        public string Passord { get; set; }
        public string Permission { get; set; }
        public int? UserId { get; set; }
        public DateTime? InputDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
