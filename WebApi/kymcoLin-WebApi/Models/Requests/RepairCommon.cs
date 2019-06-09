using kymcoLin_WebApi.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kymcoLin_WebApi.Models.Requests
{
    public class RepairCommon : TableBase
    {
        /// <summary>
        /// 車牌號碼
        /// </summary>
        public string LicensePlateNo { get; set; }
    }
}
