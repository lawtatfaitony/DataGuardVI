using AttEnumCode;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AttApiViewModal
{
    public partial class ResponseModalX
    {
        public ResponseModalX()
        {
            _meta = new MetaModalX { Success = true, Message = "OK", ErrorCode = (int)GeneralReturnCode.SUCCESS };
            _data = null;
        }
        private MetaModalX _meta;
        [JsonProperty("meta")]
        public MetaModalX meta
        {
            get
            {
                return _meta;
            }
            set
            {
                _meta = value;
            }
        }
        private Object _data;
        [JsonProperty("data")]
        public Object data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public static implicit operator Task<object>(ResponseModalX v)
        {
            throw new NotImplementedException();
        }
    }
    public partial class MetaModalX
    {
        [JsonProperty("success")]
        public bool Success { get; set; } = true;

        [JsonProperty("message")]
        public string Message { get; set; } = "OK";

        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; } = (int)GeneralReturnCode.SUCCESS;
    }
}
