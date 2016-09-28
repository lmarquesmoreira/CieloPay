using Braspag.CommonTypes.Enums;
using Cielo.Api.CustomAttributes.Validation;
using Cielo.Api.Models.Enums;

namespace Cielo.Api.Models.CieloV1.Antifraud
{
    public class ItemDataModelV1
    {
        public ProductTypeEnum Type { get; set; }

        [StringLengthWitErrorCode(255, ApiErrorEnum.ItemDataNameMaxLengthIsInvalid)]
        public string Name { get; set; }
        public HedgeEnum Risk { get; set; }

        [StringLengthWitErrorCode(255, ApiErrorEnum.ItemDataSkuMaxLengthIsInvalid)]
        public string Sku { get; set; }
        public long UnitPrice { get; set; }
        public int Quantity { get; set; }

        public HedgeEnum HostHedge { get; set; }
        public HedgeEnum NonSensicalHedge { get; set; }
        public HedgeEnum ObscenitiesHedge { get; set; }
        public HedgeEnum PhoneHedge { get; set; }
        public HedgeEnum TimeHedge { get; set; }
        public HedgeEnum VelocityHedge { get; set; }
        public GiftCategoryEnum GiftCategory { get; set; }

        public PassengerDataModelV1 Passenger { get; set; }
    }
}