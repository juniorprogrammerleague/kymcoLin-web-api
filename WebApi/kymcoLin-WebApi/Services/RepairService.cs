using kymcoLin_Entities.DBModels;
using kymcoLin_WebApi.Commons.Helpers;
using kymcoLin_WebApi.Interfaces;
using kymcoLin_WebApi.Models.Requests;
using kymcoLin_WebApi.Models.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URF.Core.Abstractions;
using URF.Core.Abstractions.Trackable;
using URF.Core.Services;

namespace kymcoLin_WebApi.Services
{
    public class RepairService : Service<Repair>, IRepairService
    {
        private readonly IRepository<RepairDetail> detailRepo;
        private readonly ITrackableRepository<LicensePlate> licensePlateRepo;

        public RepairService(ITrackableRepository<Repair> repairRepo,
            ITrackableRepository<RepairDetail> detailRepo,
            ITrackableRepository<LicensePlate> licensePlateRepo) : base(repairRepo)
        {
            this.detailRepo = detailRepo;
            this.licensePlateRepo = licensePlateRepo;
        }

        public async Task<ResultVM> GetByLicensePlateNoAsync(RepairCommon model)
        {
            var result = new ResultVM();
            var query = this.Repository.Queryable();
            if (!string.IsNullOrWhiteSpace(model.LicensePlateNo))
            {
                query = query.Where(x => x.LicensePlateNo == model.LicensePlateNo);
            }

            result.TotalCount = await query.CountAsync();

            query = query.PageQuery<Repair>(model);
            result.Result = await query.ToListAsync();

            return result;
        }
    }
}
