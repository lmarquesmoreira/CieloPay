using Newtonsoft.Json;

namespace Api.Models
{
    public class ZeroAuthModelV1
    {
        public bool Valid { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        [JsonIgnore]
        public byte ReturnType { get; set; }
    }
}