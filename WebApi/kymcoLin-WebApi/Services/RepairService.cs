using kymcoLin_Entities.DBModels;
using kymcoLin_WebApi.Interfaces;
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



    }
}
