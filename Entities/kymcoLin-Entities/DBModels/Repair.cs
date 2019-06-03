using System;
using System.Collections.Generic;

namespace kymcoLin_Entities.DBModels
{
    public partial class Repair
    {
        public string RepairId { get; set; }
        public DateTime? RepairDate { get; set; }
        public string LicensePlateNo { get; set; }
        public string EngineerId { get; set; }
        public int? Mile { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string RepairMemo { get; set; }
        public string InputName { get; set; }
        public DateTime? InputDate { get; set; }
        public string ModifyName { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
