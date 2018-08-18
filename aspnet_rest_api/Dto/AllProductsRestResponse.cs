using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_rest_api.Dto
{
    public class AllProductsRestResponse : RestResponse
    {

        public AllProductsRestResponse(List<long> ids, String detailUrl)
        {
            ids.ForEach(d => this.Products.Add(new RestfulUrl { Id = d, DetailsUrl = detailUrl + "/" + d }));
        }
        List<RestfulUrl> products;

        [JsonProperty("products")]
        public List<RestfulUrl> Products
        {
            get
            {
                if (products == null) { products = new List<RestfulUrl>(); }
                return products;
            }

            set
            {
                products = value;
            }
        }
    }
}