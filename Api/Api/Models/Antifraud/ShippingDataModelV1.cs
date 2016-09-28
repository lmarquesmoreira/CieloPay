using Braspag.CommonTypes.Enums;

namespace Cielo.Api.Models.CieloV1.Antifraud
{
    public class ShippingDataModelV1
    {
        public string Addressee { get; set; }
        public string Phone { get; set; }
        public ShippingMethodEnum Method { get; set; }
    }
}