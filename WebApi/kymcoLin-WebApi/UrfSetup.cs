using kymcoLin_Entities.DBModels;
using kymcoLin_WebApi.Interfaces;
using kymcoLin_WebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URF.Core.Abstractions;
using URF.Core.Abstractions.Trackable;
using URF.Core.EF;
using URF.Core.EF.Trackable;

namespace kymcoLin_WebApi
{
    public static class UrfSetup
    {
        /// <summary>
        /// Set up dependency-injection for services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        public static void Setup(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<kymcolinContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectoinString")));

            services.AddScoped<DbContext, kymcolinContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITrackableRepository<RepairDetail>, TrackableRepository<RepairDetail>>();
            services.AddScoped<ITrackableRepository<LicensePlate>, TrackableRepository<LicensePlate>>();
            services.AddScoped<ITrackableRepository<Repair>, TrackableRepository<Repair>>();
            services.AddScoped<IRepairHistoryService, RepairHistoryService>();
            
        }
    }
}
