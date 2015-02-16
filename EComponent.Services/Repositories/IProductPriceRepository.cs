using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComponent.Services.Responses;
using EComponent.Services.Requests;

namespace EComponent.Services.Repositories
{
    public interface IProductPriceRepository
    {
        IEnumerable<ProductPriceResponse> Get(ProductPriceGetRequest request, bool includeDeleted = false);

        int Upsert(ProductPricePostRequest request);
    }
}
