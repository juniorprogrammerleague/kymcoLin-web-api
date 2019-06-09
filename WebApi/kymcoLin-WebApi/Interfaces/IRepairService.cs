using kymcoLin_Entities.DBModels;
using kymcoLin_WebApi.Models.Requests;
using kymcoLin_WebApi.Models.Results;
using System.Threading.Tasks;
using URF.Core.Abstractions.Services;

namespace kymcoLin_WebApi.Interfaces
{
    public interface IRepairService : IService<Repair>
    {
        //Task<dynamic> Search(RepairSM searchModel);
        Task<ResultVM> GetByLicensePlateNoAsync(RepairCommon licensePlateNo);
    }
}
