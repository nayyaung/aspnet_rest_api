﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_rest_api.Dto
{
    public  class RestfulUrl
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }
        [JsonProperty("link")]
        public String DetailsUrl { get; set; }
    }
}