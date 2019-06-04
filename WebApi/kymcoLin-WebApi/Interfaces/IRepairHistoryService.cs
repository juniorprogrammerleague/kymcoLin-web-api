using kymcoLin_Entities.DBModels;
using kymcoLin_WebApi.Models.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URF.Core.Abstractions.Services;

namespace kymcoLin_WebApi.Interfaces
{
    public interface IRepairHistoryService : IService<Repair>
    {
        Task<dynamic> Search(RepairHistorySM searchModel);
    }
}
