using System.Collections.Generic;

namespace Cielo.Api.Models.CieloV1.Antifraud
{
    public class CartDataModelV1
    {
        public bool IsGift { get; set; }
        public bool ReturnsAccepted { get; set; }
        public List<ItemDataModelV1> Items { get; set; }
    }
}