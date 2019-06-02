using DevCodeCamp.Api.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevCodeCamp.Api.Models
{
    public class InstructorApiRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonConverter(typeof(Base64FileJsonConverter))]
        public byte[] Image { get; set; }
    }
}