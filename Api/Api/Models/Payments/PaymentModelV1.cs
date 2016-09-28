using System;
using System.Collections.Generic;
using Cielo.Api.CustomAttributes.Validation;
using Cielo.Api.JsonConverter;
using Cielo.Api.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Cielo.Api.Models.CieloV1.Payments
{
    [JsonConverter(typeof(PaymentConverterCieloV1))]
    public abstract class PaymentModelV1
    {
        protected PaymentModelV1()
        {
            Country = "BRA";
            Currency = "BRL";
        }

        public Guid? PaymentId { get; set; }

        [RequiredWithErrorCode(ApiErrorEnum.TypeIsRequired)]
        [RegularExpressionWithErrorCode("[a-zA-Z]+", ApiErrorEnum.TypeCanOnlyContainLetters)]
        public string Type { get; protected set; }

        [RangeWithErrorCode(0, long.MaxValue, ApiErrorEnum.AmountMustBeGreaterThanOrEqualToZero)]
        public long Amount { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? ReceivedDate { get; set; }

        public long? CapturedAmount { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? CapturedDate { get; set; }

        public long? VoidedAmount { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? VoidedDate { get; set; }

        [RequiredWithErrorCode(ApiErrorEnum.CurrencyIsRequired)]
        [RegularExpressionWithErrorCode("[a-zA-Z]{3}", ApiErrorEnum.CurrencyInvalid)]
        public string Currency { get; set; }

        [RequiredWithErrorCode(ApiErrorEnum.CountryIsRequired)]
        [RegularExpressionWithErrorCode("[a-zA-Z]{3}", ApiErrorEnum.CountryInvalid)]
        public string Country { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public virtual ProviderEnum Provider { get; set; }

        [RequiredIf(@"Type == ""EletronicTransfer"" || Type == ""DebitCard""", ApiErrorEnum.ReturnUrlIsRequired)]
        public virtual string ReturnUrl { get; set; }

        [UniqueKeyInCollectionValidation(ApiErrorEnum.ExtraDataNameDuplicated)]
        public List<ExtraDataModelV1> ExtraDataCollection { get; set; }

        public string ReturnCode { get; set; }

        public string ReturnMessage { get; set; }

        public byte Status { get; set; }

        public RecurrentPaymentModelV1 RecurrentPayment { get; set; }

        public List<LinkModelCieloV1> Links { get; set; }
    }
}