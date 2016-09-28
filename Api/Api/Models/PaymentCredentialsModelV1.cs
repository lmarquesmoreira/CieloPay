using Cielo.Api.CustomAttributes.Validation;
using Cielo.Api.Models.Enums;

namespace Cielo.Api.Models.CieloV1
{
    public class PaymentCredentialsModelV1
    {
        [RequiredWithErrorCode(ApiErrorEnum.CredentialCodeIsRequired)]
        public string Code { get; set; }
        public string Key { get; set; }
        public string Password { get; set; }
        public string Signature { get; set; }
        public string Username { get; set; }
    }
}