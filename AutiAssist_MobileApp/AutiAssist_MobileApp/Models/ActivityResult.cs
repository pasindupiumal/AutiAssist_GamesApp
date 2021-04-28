using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutiAssist_MobileApp.Models
{
    public class ActivityResult
    {
        [JsonProperty("activityID")]
        public string ActivityID { get; set; }

        [JsonProperty("overallScore")]
        public double OverallScore { get; set; }

        [JsonProperty("numberOfTries")]
        public int NumberOfTries { get; set; }

        [JsonProperty("levelReached")]
        public int LevelReached { get; set; }
    }
}
