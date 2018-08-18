using aspnet_rest_api.data.Dao;
using aspnet_rest_api.data.Model;
using aspnet_rest_api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace aspnet_rest_api.Controllers
{
    public class ProductApiController : ApiController
    {
        ProductRepository repos;
        public ProductApiController()
        {
            this.repos = new DbProductRepository();
        }


        // In real product, this should be using some IoC framework such as castle windsor or structuremap
        public ProductApiController(ProductRepository productRepository)
        {
            this.repos = productRepository;
        }

        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            var products = repos.GetAllIds();
            if (products == null || !products.Any())
            {
                return NotFound();
            }
            var res = new AllProductsRestResponse(products.ToList(), Request.RequestUri.ToString());
            return Ok(res);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Details(long id)
        {
            var product = await repos.FindById(id);
            if (product == null)
            {
                return NotFound();
            }
            var dto = AutoMapper.Mapper.Map<ProductDto>(product);
            var res = new ProductDetailsResponse { Product = dto };
            return Ok(res);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Save(List<ProductDto> products)
        {
            try
            {
                var dao = AutoMapper.Mapper.Map<List<Product>>(products);
                await repos.SaveAsync(dao);
                var res = new RestResponse { };
                return Ok(res);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
