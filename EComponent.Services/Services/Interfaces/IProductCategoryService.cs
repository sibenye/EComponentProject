using System.Collections.Generic;
using EComponent.Services.Requests;
using EComponent.Services.Responses;

namespace EComponent.Services.Services
{
    public interface IProductCategoryService
    {
        ProductCategoryGetResponse Get(ProductCategoryGetRequest request);
        ProductCategoryPostResponse Post(ProductCategoryPostRequest request);
    }
}
