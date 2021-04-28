using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutiAssist_MobileApp.Models
{
    public class Doctor
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("specialization")]
        public string Specialization { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("nic")]
        public string NIC { get; set; }

        [JsonProperty("slmcRegNo")]
        public string SlmcRegNo { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
