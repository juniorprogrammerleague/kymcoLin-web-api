using System;
using System.Collections.Generic;

namespace kymcoLin_Entities.DBModels
{
    public partial class LicensePlate
    {
        public string LicensePlateNo { get; set; }
        public int? VenNo { get; set; }
        public int? Displacement { get; set; }
        public string EngineNo { get; set; }
        public string BodyNo { get; set; }
        public int? Cycle { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? LicenseDate { get; set; }
        public string Color { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public string IdNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Tel { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public string LicenseMemo { get; set; }
        public string InputName { get; set; }
        public DateTime? InputDate { get; set; }
        public string ModifyName { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
