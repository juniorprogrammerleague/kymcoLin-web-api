using kymcoLin_Entities.DBModels;
using kymcoLin_WebApi.Interfaces;
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
    public class ProductService : Service<Product>, IProductService
    {
        ITrackableRepository<ProductType> _productTypeRepo;
        public ProductService(ITrackableRepository<Product> productRepo,
            ITrackableRepository<ProductType> productTypeRepo) : base(productRepo)
        {
            this._productTypeRepo = productTypeRepo;
        }

        public async Task<dynamic> GetAll()
        {
            return await this.Repository.Queryable().ToListAsync();
        }

        public async Task<dynamic> GetByProductTypeNoAsync (int ProductTypeNo)
        {
            return await this.Repository.Queryable().Join(_productTypeRepo.Queryable(),
                x => x.ProductTypeNo,
                y => y.ProductTypeNo,
                (x, y) => new
                {
                    x.ProductId,
                    y.ProuctTypeName,
                    x.ProductName,
                    x.ProductPrice,
                    x.InputDate,
                    x.InputName,
                    x.ModifyDate,
                    x.ModifyName,
                }).ToListAsync();
        }
    }
}
