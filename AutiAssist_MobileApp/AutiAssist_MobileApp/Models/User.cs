using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutiAssist_MobileApp.Models
{

    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("salt")]
        public string Salt { get; set; }
                                                                        
        [JsonProperty("userType")]
        public string UserType { get; set; }

        [JsonProperty("doctorData")]
        public Doctor DoctorData { get; set; }

        [JsonProperty("patientData")]
        public Patient PatientData { get; set; }
    }
}
