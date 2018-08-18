using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_rest_api.Dto
{
    public class ProductDetailsResponse : RestResponse
    {
        [JsonProperty("product")]
        public ProductDto Product { get; set; }
    }
}