using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComponent.Services.Responses;
using EComponent.Services.Requests;

namespace EComponent.Services.Repositories
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategoryResponse> Get(ProductCategoryGetRequest request, bool includeDeleted = false);

        int Upsert(ProductCategoryPostRequest request);
    }
}
