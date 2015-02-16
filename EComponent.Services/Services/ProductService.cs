using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using EComponent.Services.Repositories;
using EComponent.Services.Requests;
using EComponent.Services.Responses;


namespace EComponent.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductPriceRepository _productPriceRepository;

        public ProductService(IProductCategoryRepository productCategoryRepository,
            IProductRepository productRepository,
            IProductPriceRepository productPriceRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
            _productPriceRepository = productPriceRepository;
        }

        public ProductGetResponse Get(ProductGetRequest request) 
        {
            var products = _productRepository.Get(request);

            if (!products.Any())
            {
                //TODO: throw exception
            }

            foreach (var product in products)
            {
                product.Pricing = _productPriceRepository.Get(new ProductPriceGetRequest { ProductId = product.Id }).ToList();
            }

            return new ProductGetResponse {Products = products.ToArray()};
        }

        public ProductPostResponse Post(ProductPostRequest request) 
        {
            throw new NotImplementedException();
        }
    }
}
