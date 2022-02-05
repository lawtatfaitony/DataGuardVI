using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGateway.ModelApi
{
    public class RefreshToken
    {
        /// <summary>
        /// Token
        /// </summary>
        [JsonProperty("Token")]
        public string Token { get; set; }

        /// <summary>
        /// TokenExpiryDate
        /// </summary>
        [JsonProperty("TokenExpiryDate")]
        public DateTime TokenExpiryDate { get; set; }
    }
}
