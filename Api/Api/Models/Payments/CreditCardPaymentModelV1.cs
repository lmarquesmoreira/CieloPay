using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cielo.Api.CustomAttributes.Validation;
using Cielo.Api.Models.CieloV1.Antifraud;
using Cielo.Api.Models.Enums;

namespace Cielo.Api.Models.CieloV1.Payments
{
    public class CreditCardPaymentModelV1 : PaymentModelV1
    {
        public CreditCardPaymentModelV1()
        {
            this.Type = "CreditCard";
        }

        [RangeIf("Installments < 2", 0, 0, ApiErrorEnum.ServiceTaxCannotBeSentWithOneInstallment)]
        public long ServiceTaxAmount { get; set; }

        [RangeIf("RecurrentPayment != null", 1, 1, ApiErrorEnum.InstallmentsMustOneWhenUsingRecurrentPayments)]
        [RangeWithErrorCode(1, long.MaxValue, ApiErrorEnum.InstallmentsMustBeGreaterThanOrEqualToOne)]
        public short Installments { get; set; }

        [Required]
        public InterestTypeEnum Interest { get; set; }

        public bool Capture { get; set; }

        public bool Authenticate { get; set; }

        public bool Recurrent { get; set; }

        [NotBeNull(ApiErrorEnum.CardIsRequired)]
        public CardModelV1 CreditCard { get; set; }

        public string AuthenticationUrl { get; set; }

        public string Tid { get; set; }

        public string ProofOfSale { get; set; }

        public string AuthorizationCode { get; set; }

        [StringLengthWitErrorCode(13, ApiErrorEnum.SoftDescriptorLegthExceded)]
        public string SoftDescriptor { get; set; }

        [RequiredIf(@"Authenticate == true", ApiErrorEnum.ReturnUrlIsRequired)]
        [RegularExpressionWithErrorCode(@"^(https?):\/\/(\w+\.)+(\w{2,4})((\/\w*)?)*((\?.*)?)((\.\w+)?)$", ApiErrorEnum.ReturnUrlIsInvalid)]
        public override string ReturnUrl { get; set; }

        public override ProviderEnum Provider { get; set; }

        public string Eci { get; set; }

        public FraudAnalysisModelV1 FraudAnalysis { get; set; }

        public ExternalAuthenticationModelV1 ExternalAuthentication { get; set; }

        public CardModelV1 NewCard { get; set; }

        public List<SplitModelV1> Splits { get; set; }

        public WalletModelV1 Wallet { get; set; }

        public PaymentCredentialsModelV1 Credentials { get; set; }

        public VelocityAnalysisModelV1 VelocityAnalysis { get; set; }
    }
}