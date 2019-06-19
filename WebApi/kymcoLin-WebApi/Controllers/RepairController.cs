using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kymcoLin_Entities.DBModels;
using kymcoLin_WebApi.Interfaces;
using URF.Core.Abstractions;
using kymcoLin_WebApi.Services;
using kymcoLin_WebApi.Models.Requests;
using kymcoLin_WebApi.Models.Results;
using kymcoLin_WebApi.Models.Searches;

namespace kymcoLin_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        // private readonly kymcolinContext _context;
        private readonly IRepairService _repairService;
        private readonly IUnitOfWork _unitOfWork;

        public RepairController(IRepairService repairService, IUnitOfWork unitOfWork)
        {
            this._repairService = repairService;
            this._unitOfWork = unitOfWork;
        }

       

        // GET: api/GetById/0000005
        [HttpPost("[action]")]
        public async Task<ActionResult<ResultVM>> GetByLicensePlateNo([FromBody]RepairTable model)
        {
            var result = await _repairService.GetByLicensePlateNoAsync(model);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ResultVM>> GetBySearchTerm([FromBody]RepairSM model)
        {
            var result = await _repairService.SearchByTerm(model.SearchTerm);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        //// GET: api/Get
        //[HttpGet]
        //[Route("[action]")]
        //public async Task<ActionResult<IEnumerable<Repair>>> Get()
        //{
        //    return await _repairService.Queryable().ToListAsync();
        //}

        // POST: api/Search
        //[HttpPost("[action]")]
        //public async Task<dynamic> Search([FromBody]RepairSM model) // TODO: RequestModel
        //{
        //    var repair = await _repairService.Search(model);

        //    if (repair == null)
        //    {
        //        return NotFound();
        //    }

        //    return repair;
        //}

        // PUT: api/Repair/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRepair(string id, Repair repair)
        //{
        //    if (id != repair.RepairId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(repair).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RepairExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Repair
        //[HttpPost]
        //public async Task<ActionResult<Repair>> PostRepair(Repair repair)
        //{
        //    _context.Repair.Add(repair);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (RepairExists(repair.RepairId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetRepair", new { id = repair.RepairId }, repair);
        //}

        //// DELETE: api/Repair/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Repair>> DeleteRepair(string id)
        //{
        //    var repair = await _context.Repair.FindAsync(id);
        //    if (repair == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Repair.Remove(repair);
        //    await _context.SaveChangesAsync();

        //    return repair;
        //}

        //private bool RepairExists(string id)
        //{
        //    return _context.Repair.Any(e => e.RepairId == id);
        //}
    }
}
