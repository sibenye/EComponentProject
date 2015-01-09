using System.Collections.Generic;
using EComponent.Services.Requests;
using EComponent.Services.Responses;

namespace EComponent.Services
{
    public interface IProductCategoryService
    {
        ProductCategoryGetResponse GetProductCategories();
        ProductCategoryGetResponse GetProductCategory(ProductCategoryGetRequest request);
        ProductCategoryPostResponse PostProductCategory(ProductCategoryPostRequest request);
    }
}
