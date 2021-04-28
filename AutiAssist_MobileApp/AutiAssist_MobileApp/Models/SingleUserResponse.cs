using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutiAssist_MobileApp.Models
{
    public class SingleUserResponse
    {
        [JsonProperty("data")]
        public User Data { get; set; }

        [JsonProperty("message")]
        public dynamic Message { get; set; }
    }
}
