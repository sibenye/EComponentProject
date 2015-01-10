using System.Collections.Generic;
using System.Linq;
using EComponent.Services.Repositories;
using EComponent.Services.Requests;
using EComponent.Services.Responses;

namespace EComponent.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public ProductCategoryGetResponse Get(ProductCategoryGetRequest request)
        {
            var response = _productCategoryRepository.Get(request);

            return new ProductCategoryGetResponse { ProductCategories = response.ToArray() };
        }

        public ProductCategoryPostResponse Post(ProductCategoryPostRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
