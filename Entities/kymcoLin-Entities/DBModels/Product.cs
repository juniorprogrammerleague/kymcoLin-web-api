using System;
using System.Collections.Generic;

namespace kymcoLin_Entities.DBModels
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int? ProductTypeNo { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string InputName { get; set; }
        public DateTime? InputDate { get; set; }
        public string ModifyName { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
