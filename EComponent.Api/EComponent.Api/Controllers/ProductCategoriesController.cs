using System;
using System.Web.Http;
using System.Web.Http.Description;
using EComponent.Services;
using EComponent.Services.Requests;
using EComponent.Services.Responses;

namespace EComponent.Api.Controllers
{
    public class ProductCategoriesController : ApiController
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoriesController(IProductCategoryService productCategoryService)
        {
            if (productCategoryService == null)
            {
                throw new ArgumentNullException("productCategoryService");
            }

            _productCategoryService = productCategoryService;
        }

        // GET: api/ProductCategories
        [Route("api/ProductCategories")]
        [ResponseType(typeof(ProductCategoryGetResponse))]
        public IHttpActionResult Get()
        {
            var response = _productCategoryService.GetProductCategories();

            return Ok(response);
        }

        // GET: api/ProductCategories/5
        [Route("api/ProductCategories/{id:long}")]
        [Route("api/ProductCategories/{name}")]
        [ResponseType(typeof(ProductCategoryGetResponse))]
        public IHttpActionResult Get([FromUri] ProductCategoryGetRequest request)
        {
            var response = _productCategoryService.GetProductCategory(request);

            return Ok(response);
        }

        // POST: api/ProductCategories
        [Route("api/ProductCategories")]
        [ResponseType(typeof(ProductCategoryPostResponse))]
        public IHttpActionResult Post([FromBody]ProductCategoryPostRequest request)
        {
            var response = _productCategoryService.PostProductCategory(request);

            return Ok(response);
        }

        // DELETE: api/ProductCategories/5
        public void Delete(int id)
        {
        }
    }
}
