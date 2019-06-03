using System;
using System.Collections.Generic;

namespace kymcoLin_Entities.DBModels
{
    public partial class RepairDetail
    {
        public int RepairDetailId { get; set; }
        public string RepairId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductQuantity { get; set; }
        public decimal? ProductPrice { get; set; }
        public string RepairDetailMemo { get; set; }
    }
}
