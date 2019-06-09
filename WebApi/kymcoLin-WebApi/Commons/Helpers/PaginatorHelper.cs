using kymcoLin_WebApi.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kymcoLin_WebApi.Commons.Helpers
{
    public static class PaginatorHelper
    {
        public static IQueryable<T> PageQuery<T>(this IQueryable<T> query, TableBase model) where T : class
        {
            if (model.PageIndex != null && model.PageSize != null)
            {
                query = query
                    .Skip(model.PageSize.GetValueOrDefault() * model.PageIndex.GetValueOrDefault())
                    .Take(model.PageSize.GetValueOrDefault());
            }

            return query;
        }
    }
}
