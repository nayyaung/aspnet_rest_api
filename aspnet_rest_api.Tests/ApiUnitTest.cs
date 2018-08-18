using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using aspnet_rest_api.Configurations;
using aspnet_rest_api.Controllers;
using aspnet_rest_api.data.Dao;
using aspnet_rest_api.data.Model;
using aspnet_rest_api.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace aspnet_rest_api.Tests
{
    [TestClass]
    [TestCategory("General")]
    public class ApiUnitTest
    {
        [ClassInitialize()]
        public static void Initialize(TestContext testContext)
        {
            AutoMapperConfig.Initialize();
        }
         
        [TestMethod]
        public void GetIndividualProduct()
        {
            var mockRepository = new Mock<ProductRepository>();
            mockRepository.Setup(mock => mock.FindById(1))
                .ReturnsAsync(new Product { Id = 1, Name = "test", Quantity = 1, SalesAmount = 2 });

            OkNegotiatedContentResult<ProductDetailsResponse> response = null;
            Task.Run(() =>
            {
                var controller = new ProductApiController(mockRepository.Object)
                {
                    Request = new HttpRequestMessage(),
                    Configuration = new HttpConfiguration()
                };

                response = controller.Details(1).GetAwaiter().GetResult() as OkNegotiatedContentResult<ProductDetailsResponse>;
            }
                ).GetAwaiter().GetResult();

            mockRepository.Verify(mock => mock.FindById(1), Times.Once());
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Content.Product.Id);
            Assert.AreEqual("test", response.Content.Product.Name);
        }

        [TestMethod]
        public void SaveProducts()
        {
            var mockRepository = new Mock<ProductRepository>();
            mockRepository.Setup(mock => mock.SaveAsync(It.IsAny<List<Product>>()))
                .Returns(Task.CompletedTask);

            List<ProductDto> dtoList = new List<ProductDto>();
            dtoList.Add(new ProductDto { Name = "test", Quantity = 1, SalesAmount = 2 });
            dtoList.Add(new ProductDto { Name = "test2", Quantity = 2, SalesAmount = 20 });

            OkNegotiatedContentResult<RestResponse> response = null;
            Task.Run(() =>
            {
                var controller = new ProductApiController(mockRepository.Object)
                {
                    Request = new HttpRequestMessage(),
                    Configuration = new HttpConfiguration()
                };

                response = controller.Save(dtoList).GetAwaiter().GetResult() as OkNegotiatedContentResult<RestResponse>;
            }
                ).GetAwaiter().GetResult();

            mockRepository.Verify(mock => mock.SaveAsync(It.IsAny<List<Product>>()), Times.Once());
            Assert.IsNotNull(response);
            Assert.IsFalse(String.IsNullOrWhiteSpace(response.Content.Id));
            Assert.IsTrue(response.Content.Timestamp > 0);
        }

        [TestMethod]
        public void GetAllProductIds()
        {
            var mockRepository = new Mock<ProductRepository>();
            var listIds = new List<long>();
            listIds.Add(1);
            listIds.Add(2);
            mockRepository.Setup(mock => mock.GetAllIds()).Returns(listIds);

            OkNegotiatedContentResult<AllProductsRestResponse> response = null;
            var controller = new ProductApiController(mockRepository.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            controller.Request.RequestUri = new Uri("http://localhost/fake-api");
            response = controller.GetProducts() as OkNegotiatedContentResult<AllProductsRestResponse>;


            mockRepository.Verify(mock => mock.GetAllIds(), Times.Once());
            Assert.AreEqual(2, response.Content.Products.Count);
            var firstProduct = response.Content.Products.Find(a => a.Id == 1);
            var secondProduct = response.Content.Products.Find(a => a.Id == 2);
            Assert.IsNotNull(firstProduct);
            Assert.IsNotNull(secondProduct);
            Assert.IsTrue(firstProduct.DetailsUrl.Equals(controller.Request.RequestUri + "/1", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(secondProduct.DetailsUrl.Equals(controller.Request.RequestUri + "/2", StringComparison.OrdinalIgnoreCase));
        }
    }
}
