using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGateway.ModelApi
{
    public class Contract
    { 
        [JsonProperty("RowID")]
        public string RowId { get; set; }
         
        [JsonProperty("Number")]
        public string Number { get; set; }
         
        [JsonProperty("ContractNo")]
        public string ContractNo { get; set; }
         
        [JsonProperty("ContractDesc")]
        public string ContractDesc { get; set; }
         
        [JsonProperty("StartDate")]
        public string StartDate { get; set; }
         
        [JsonProperty("EndDate")]
        public string EndDate { get; set; }
         
        [JsonProperty("ContractShortName")]
        public string ContractShortName { get; set; }
         
        [JsonProperty("Status")]
        public string Status { get; set; }
    }
}
