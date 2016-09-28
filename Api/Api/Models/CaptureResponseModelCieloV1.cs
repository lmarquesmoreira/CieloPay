namespace Api.Models
{
    using Cielo.Api.Models.CieloV1;
    using System.Collections.Generic;

    public class CaptureResponseModelCieloV1
    {
        public int Status { get; set; }
        public int ReasonCode { get; set; }
        public string ReasonMessage { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }

        public List<LinkModelCieloV1> Links { get; set; }
    }
}