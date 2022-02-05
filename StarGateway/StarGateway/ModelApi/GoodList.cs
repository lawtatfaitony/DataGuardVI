using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGateway.ModelApi
{
    public class GoodList
    {
        /// <summary>
        /// RowID
        /// </summary>
        [JsonProperty("RowID")]
        public string RowID { get; set; }

        /// <summary>
        /// StartDate
        /// </summary>
        [JsonProperty("StartDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>
        [JsonProperty("EndDate")]
        public string EndDate { get; set; }

        /// <summary>
        /// RegistrationDate
        /// </summary>
        [JsonProperty("RegistrationDate")]
        public string RegistrationDate { get; set; }

        /// <summary>
        /// CreateDate
        /// </summary>
        [JsonProperty("CreateDate")]
        public string CreateDate { get; set; }

        /// <summary>
        /// RemoveDate
        /// </summary>
        [JsonProperty("RemoveDate")]
        public string RemoveDate { get; set; }

        /// <summary>
        /// LastModifyDate
        /// </summary>
        [JsonProperty("LastModifyDate")]
        public string LastModifyDate { get; set; }

        /// <summary>
        /// CwrNo
        /// </summary>
        [JsonProperty("CwrNo")]
        public string CwrNo { get; set; }

        /// <summary>
        /// ContractID
        /// </summary>
        [JsonProperty("ContractID")]
        public string ContractID { get; set; }

        /// <summary>
        /// PractisingTrade
        /// </summary>
        [JsonProperty("PractisingTrade")]
        public string PractisingTrade { get; set; }

        /// <summary>
        /// BiometricTemplateIdentifier
        /// </summary>
        [JsonProperty("BiometricTemplateIdentifier")]
        public string BiometricTemplateIdentifier { get; set; }

        /// <summary>
        /// TechnologyType
        /// </summary>
        [JsonProperty("TechnologyType")]
        public string TechnologyType { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("Timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("NameChi")]
        public string NameChi { get; set; }

        [JsonProperty("NameEng")]
        public string NameEng { get; set; } 
        public virtual string IdNumber => string.Format("{0}", CwrNo).Trim();
    }
}
