using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutiAssist_MobileApp.Models
{
    public class Patient
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("guardianName")]
        public string GuardianName { get; set; }

        [JsonProperty("assignedDoctor")]
        public string AssignedDoctor { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
