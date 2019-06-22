using kymcoLin_Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URF.Core.Abstractions.Services;

namespace kymcoLin_WebApi.Interfaces
{
    public interface IProductService : IService<Product>
    {
        Task<dynamic> GetAll();
        Task<dynamic> GetByProductTypeNoAsync (int ProductTypeNo);
    }
}
