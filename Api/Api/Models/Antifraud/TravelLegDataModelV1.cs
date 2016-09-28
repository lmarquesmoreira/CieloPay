using Cielo.Api.CustomAttributes.Validation;
using Cielo.Api.Models.Enums;

namespace Cielo.Api.Models.CieloV1.Antifraud
{
    public class TravelLegDataModelV1
    {
        [StringLengthWitErrorCode(3, ApiErrorEnum.TravelLegDataDestinationMaxLengthIsInvalid)]
        public string Destination { get; set; }

        [StringLengthWitErrorCode(3, ApiErrorEnum.TravelLegDataOriginMaxLengthIsInvalid)]
        public string Origin { get; set; }
    }
}