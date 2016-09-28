using Cielo.Api.CustomAttributes.Validation;
using Cielo.Api.Models.Enums;

namespace Cielo.Api.Models.CieloV1.Antifraud
{
    public class MerchantDefinedFieldModelV1
    {
        public byte Id { get; set; }
        [StringLengthWitErrorCode(255, ApiErrorEnum.MerchantDefinedFieldValueMaxLengthIsInvalid)]
        public string Value { get; set; }
    }
}