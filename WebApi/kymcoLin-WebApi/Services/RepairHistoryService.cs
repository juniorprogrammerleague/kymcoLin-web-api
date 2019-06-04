using kymcoLin_Entities.DBModels;
using kymcoLin_WebApi.Interfaces;
using kymcoLin_WebApi.Models.Searches;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URF.Core.Abstractions;
using URF.Core.Abstractions.Trackable;
using URF.Core.EF;
using URF.Core.Services;

namespace kymcoLin_WebApi.Services
{
    public class RepairHistoryService : Service<Repair>, IRepairHistoryService
    {
        private readonly IRepository<RepairDetail> detailRepo;
        private readonly ITrackableRepository<LicensePlate> licensePlateRepo;

        public RepairHistoryService(ITrackableRepository<Repair> repairRepo,
            ITrackableRepository<RepairDetail> detailRepo,
            ITrackableRepository<LicensePlate> licensePlateRepo) : base(repairRepo)
        {
            this.detailRepo = detailRepo;
            this.licensePlateRepo = licensePlateRepo;
        }


        public async Task<dynamic> Search(RepairHistorySM searchModel)
        {
            var query = from r in Repository.Queryable()
                        join l in this.licensePlateRepo.Queryable() on r.LicensePlateNo equals l.LicensePlateNo
                        select new { repair = r, license = l };

            if (searchModel.StartDate != null)
            {
                query = query.Where(x => x.repair.InputDate > searchModel.StartDate);
            }

            if (searchModel.EndDate != null)
            {
                query = query.Where(x => x.repair.InputDate < searchModel.EndDate);
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(x => x.license.Name.Contains(searchModel.Name));
            }

            var result = await query.Select(x => new
            {
                x.repair.InputDate,
                x.repair.LicensePlateNo,
                x.license.Name,
                x.repair.TotalPrice,
                x.repair.DiscountPrice,
                x.repair.RepairMemo
            }).ToListAsync();

            return result;
        }
    }
}
