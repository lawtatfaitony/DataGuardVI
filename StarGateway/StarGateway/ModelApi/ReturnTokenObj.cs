using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGateway.ModelApi
{
    public class ReturnTokenObj
    { 
        [JsonProperty("Roles")]
        public string Roles { get; set; }

        [JsonProperty("ContractorID")]
        public string ContractorId { get; set; }

        [JsonProperty("Token")]
        public string Token { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("AccountID")]
        public string AccountId { get; set; }

        [JsonProperty("TokenExpiryDate")]
        public DateTime TokenExpiryDate { get; set; } 
    }
}
