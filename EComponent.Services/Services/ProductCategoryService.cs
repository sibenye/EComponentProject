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

        public ProductCategoryGetResponse GetProductCategories()
        {
            var response = _productCategoryRepository.GetProductCategories();

            if (!response.Any())
            {
                //TODO: throw not found exception
            }
            return new ProductCategoryGetResponse {ProductCategories = response.ToArray()};
        }

        public ProductCategoryGetResponse GetProductCategory(ProductCategoryGetRequest request)
        {
            var response = _productCategoryRepository.GetProductCategory(request);

            if (response == null)
            {
                //TODO: throw not found exception
            }
            return new ProductCategoryGetResponse { ProductCategories = new[]{response} };
        }

        public ProductCategoryPostResponse PostProductCategory(ProductCategoryPostRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
