using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kymcoLin_WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URF.Core.Abstractions;

namespace kymcoLin_WebApi.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IProductService productService, IUnitOfWork unitOfWork)
        {
            this._productService = productService;
            this._unitOfWork = unitOfWork;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<dynamic>> Get()
        {
            var product = await _productService.GetAll();
            if (product == null)
            {
                return BadRequest();
            }

            return Ok(product);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetByProductTypeNo(int ProductTypeNo)
        {
            var product = await _productService.GetByProductTypeNoAsync(ProductTypeNo);

            if (product == null)
            {
                return BadRequest();
            }

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
