using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Api.Models
{
    public class CardModelV1
    {
        public string CardNumber { get; set; }
        
        public string Holder { get; set; }
        
        public string ExpirationDate { get; set; }
        
        public string SecurityCode { get; set; }

        public bool SaveCard { get; set; }

        public Guid? CardToken { get; set; }

        public string Alias { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public string Brand { get; set; }

        public AvsModelV1 Avs { get; set; }
    }
}