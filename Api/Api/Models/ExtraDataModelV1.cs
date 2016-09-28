using Cielo.Api.CustomAttributes.Validation;
using Cielo.Api.Models.Enums;

namespace Cielo.Api.Models.CieloV1
{
    public class ExtraDataModelV1
    {
        [StringLengthWitErrorCode(50, ApiErrorEnum.ExtraDataNameMaxLengthIsInvalid)]
        public string Name { get; set; }
        [StringLengthWitErrorCode(1024, ApiErrorEnum.ExtraDataValueMaxLengthIsInvalid)]
        public string Value { get; set; }
    }
}