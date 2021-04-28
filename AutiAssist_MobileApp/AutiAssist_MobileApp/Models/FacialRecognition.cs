using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutiAssist_MobileApp.Models
{
    public class FacialRecognition
    {
        [JsonProperty("noOfImagesProcessed")]
        public int NoOfImagesProcessed { get; set; }

        [JsonProperty("overallResult")]
        public string OverallResult { get; set; }
    }
}
