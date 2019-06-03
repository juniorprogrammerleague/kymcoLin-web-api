using System;
using System.Collections.Generic;

namespace kymcoLin_Entities.DBModels
{
    public partial class ProductType
    {
        public int ProductTypeNo { get; set; }
        public string ProuctTypeName { get; set; }
        public string InputName { get; set; }
        public DateTime? InputDate { get; set; }
        public string ModifyName { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
