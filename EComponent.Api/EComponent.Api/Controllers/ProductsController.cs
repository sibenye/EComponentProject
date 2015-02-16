using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EComponent.Services.Services;
using EComponent.Services.Requests;
using EComponent.Services.Responses;

namespace EComponent.Api.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            if (productService == null)
            {
                throw new ArgumentNullException("productService");
            }

            _productService = productService;
        }

        // GET: api/Products/5
        [Route("api/Products/{id:int}")]
        //[Route("api/Products/{productCategoryId:int}")]
        [Route("api/Products/{productCode}")]
        [ResponseType(typeof(ProductGetResponse))]
        public IHttpActionResult Get([FromUri] ProductGetRequest request)
        {
            var response = _productService.Get(request);

            return Ok(response);
        }
    }
}
