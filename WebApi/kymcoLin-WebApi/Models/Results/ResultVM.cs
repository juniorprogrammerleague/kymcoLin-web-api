using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kymcoLin_WebApi.Models.Results
{
    public class ResultVM
    {
        /// <summary>
        /// 回傳代碼
        /// </summary>
        public string ReturnCode { get; set; }

        /// <summary>
        /// 結果總數
        /// </summary>
        public int? TotalCount { get; set; }

        /// <summary>
        /// 回傳結果
        /// </summary>
        public dynamic Result { get; set; }
    }
}
