using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutiAssist_MobileApp.Models
{
    public class Report
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userID")]
        public string UserID { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("sessionID")]
        public string SessionID { get; set; }

        [JsonProperty("activityID")]
        public string ActivityID { get; set; }

        [JsonProperty("timeStamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("activityResult")]
        public ActivityResult ActivityResult { get; set; }

        [JsonProperty("facialRecognitionResult")]
        public FacialRecognition FacialRecognitionResult { get; set; }

        [JsonProperty("vitalResult")]
        public Vitals VitalResult { get; set; }

        [JsonProperty("predictedAutismScore")]
        public string PredictedAutismScore { get; set; }

        [JsonProperty("predictedAutismLevel")]
        public string PredictedAutismLevel { get; set; }
    }
}
