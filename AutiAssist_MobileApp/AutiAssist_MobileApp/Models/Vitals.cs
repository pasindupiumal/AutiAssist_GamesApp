using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutiAssist_MobileApp.Models
{
    public class Vitals
    {
        [JsonProperty("haertBeat")]
        public string HaertBeat { get; set; }

        [JsonProperty("testField1")]
        public string TestField1 { get; set; }

        [JsonProperty("testField2")]
        public string TestField2 { get; set; }
    }
}
