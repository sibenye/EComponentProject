using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EComponent.Services.Requests;
using EComponent.Services.Responses;

namespace EComponent.Services.Services
{
    public interface IProductService
    {
        ProductGetResponse Get(ProductGetRequest request);
        ProductPostResponse Post(ProductPostRequest request);
    }
}
