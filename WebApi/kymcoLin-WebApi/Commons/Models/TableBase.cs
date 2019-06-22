using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kymcoLin_WebApi.Commons.Models
{
    public class TableBase
    {
        /// <summary>
        /// 頁數索引
        /// </summary>
        public int? PageIndex { get; set; }

        /// <summary>
        /// 資料比數
        /// </summary>
        public int? PageSize { get; set; }
    }
}
