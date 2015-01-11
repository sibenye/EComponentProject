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
            if (request.Id != null)
            {
                var getRequest = new ProductCategoryGetRequest { Id = request.Id };
                var getResponse = _productCategoryRepository.Get(getRequest).SingleOrDefault();
                if (getResponse == null)
                {
                    //TODO: throw NotFound Exception
                }
            }

            if (request.ParentId != null)
            {
                var getRequestByParentId = new ProductCategoryGetRequest { Id = request.ParentId };
                var getByParentResponse = _productCategoryRepository.Get(getRequestByParentId).SingleOrDefault();
                if (getByParentResponse == null)
                {
                    //TODO: throw NotFound Exception
                }
            }

            //ensure that the categoryName is unique
            var getRequestByName = new ProductCategoryGetRequest { CategoryName = request.CategoryName };
            var getByNameResponse = _productCategoryRepository.Get(getRequestByName, true).ToList();
            if (getByNameResponse.Any())
            {
                if (request.Id == null)
                {
                    //throw exception that name already exist
                }
                else if (getByNameResponse.Select(r => r.Id != request.Id).Any())
                {
                    //throw exception that name already exist
                }                
            }

            var upsertId = _productCategoryRepository.Upsert(request);
            var response = _productCategoryRepository.Get(new ProductCategoryGetRequest { Id = upsertId });

            return new ProductCategoryPostResponse { ProductCategory = response.Single() };
        }
    }
}
