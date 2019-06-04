using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kymcoLin_WebApi.Interfaces;
using kymcoLin_WebApi.Models.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URF.Core.Abstractions;

namespace kymcoLin_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairHistoryController : ControllerBase
    {
        private readonly IRepairHistoryService _repairService;
        private readonly IUnitOfWork _unitOfWork;

        public RepairHistoryController(IRepairHistoryService repairService, IUnitOfWork unitOfWork)
        {
            this._repairService = repairService;
            this._unitOfWork = unitOfWork;
        }

        // POST: api/Search
        [HttpPost("[action]")]
        public async Task<dynamic> Search([FromBody]RepairHistorySM model) // TODO: RequestModel
        {
            var repair =await _repairService.Search(model);

            if (repair == null)
            {
                return NotFound();
            }

            return repair;
        }
    }
}