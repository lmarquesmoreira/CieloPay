using Braspag.CommonTypes.Enums;
using Cielo.Api.CustomAttributes.Validation;
using Cielo.Api.Models.Enums;

namespace Cielo.Api.Models.CieloV1.Antifraud
{
    public class PassengerDataModelV1
    {
        [StringLengthWitErrorCode(120, ApiErrorEnum.PassengerDataNameMaxLengthIsInvalid)]
        public string Name { get; set; }

        public string Identity { get; set; }

        [StringLengthWitErrorCode(32, ApiErrorEnum.PassengerDataStatusMaxLengthIsInvalid)]
        public string Status { get; set; }

        public PassengerRatingEnum Rating { get; set; }

        [StringLengthWitErrorCode(255, ApiErrorEnum.PassengerDataEmailMaxLengthIsInvalid)]
        public string Email { get; set; }

        [StringLengthWitErrorCode(15, ApiErrorEnum.PassengerDataPhoneMaxLengthIsInvalid)]
        public string Phone { get; set; }
    }
}