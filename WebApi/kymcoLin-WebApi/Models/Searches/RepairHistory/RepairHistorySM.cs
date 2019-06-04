using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kymcoLin_WebApi.Models.Searches
{
    public class RepairHistorySM
    {
        /// <summary>
        /// 維修日期區間:開始時間
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 維修日期區間:結束時間
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 車主姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 車籍備註
        /// </summary>
        public string RepairMemo { get; set; }
    }
}
