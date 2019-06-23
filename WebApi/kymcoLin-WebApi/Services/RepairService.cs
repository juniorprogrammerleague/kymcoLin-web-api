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
using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;

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

        public async Task<ResultVM> GetRepairRecordAsync(RepairTable model)
        {
            var result = new ResultVM();
            var query = this.Repository.Queryable();
            if (!string.IsNullOrWhiteSpace(model.LicensePlateNo))
            {
                query = query.Where(x => x.LicensePlateNo == model.LicensePlateNo);
            }

            result.TotalCount = await query.CountAsync();

            var term = PaginatorHelper.GetSortTerm("");
            query = query.OrderBy(!string.IsNullOrWhiteSpace(term)? term: "RepairDate desc")
                    .Skip(model.PageSize.GetValueOrDefault() * model.PageIndex.GetValueOrDefault())
                    .Take(model.PageSize.GetValueOrDefault());
            result.Result = await query.ToListAsync();

            return result;
        }

        public async Task<dynamic> SearchByTermAsync(string searchTerm)
        {
            var isChinese = new Regex("^[\u4E00-\u9FFF]+$").IsMatch(searchTerm);
            var isAllNum = new Regex("^\\d+$").IsMatch(searchTerm);

            if (isChinese)
            {
                return await this.licensePlateRepo.Queryable()
                    .Where(x => x.Name.StartsWith(searchTerm))
                    .Select(x => new { licenseNo = x.LicensePlateNo, text = x.Name })
                    .Union(
                        this.licensePlateRepo.Queryable()
                        .Where(x => x.LicenseMemo.Contains(searchTerm))
                        .Select(x => new { licenseNo = x.LicensePlateNo, text = x.LicenseMemo }))
                        .ToListAsync();                
            }
            else
            {
                return await this.licensePlateRepo.Queryable()
                    .Where(x => x.LicensePlateNo.StartsWith(searchTerm))
                    .Select(x => new { licenseNo = x.LicensePlateNo, text = x.LicensePlateNo })

                .Union(this.licensePlateRepo.Queryable()
                    .Where(x => x.Phone.StartsWith(searchTerm))
                    .Select(x => new { licenseNo = x.LicensePlateNo, text = x.Phone }))
                    .Union(
                        this.licensePlateRepo.Queryable()
                        .Where(x => x.Tel.StartsWith(searchTerm))
                        .Select(x => new { licenseNo = x.LicensePlateNo, text = x.Tel }))
                        .ToListAsync();
            }
        }

        public async Task<dynamic> GetRepairDetailAsync(string licensePlateNo)
        {
            var query = await this.Repository.Queryable()
                 .Where(x => x.LicensePlateNo == licensePlateNo)
                 .ToListAsync();

            return query.OrderByDescending(x => x.RepairDate)
                 .Select(x => new { x.LicensePlateNo, LastMile = x.Mile })
                 .FirstOrDefault();
        }

        //public async Task<dynamic> GetScooterDetail(string LicensePlateNo)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<dynamic> GetRepairRecord(string LicensePlateNo)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
