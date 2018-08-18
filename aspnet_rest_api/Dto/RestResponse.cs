using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_rest_api.Dto
{
    public class RestResponse
    {
        public RestResponse()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }

        [JsonProperty("id")]
        public string Id { get; }
        [JsonProperty("timestamp")]
        public long Timestamp { get;  }
    }
}