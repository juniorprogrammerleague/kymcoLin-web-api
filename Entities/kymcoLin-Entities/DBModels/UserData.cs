using System;
using System.Collections.Generic;

namespace kymcoLin_Entities.DBModels
{
    public partial class UserData
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string IdNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string InputName { get; set; }
        public DateTime? InputDate { get; set; }
        public string ModifyName { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
