using System;
using System.Collections.Generic;
using Braspag.CommonTypes.Enums;
using Cielo.Api.CustomAttributes.Validation;
using Cielo.Api.Models.Enums;

namespace Cielo.Api.Models.CieloV1.Antifraud
{
    public class FraudAnalysisModelV1
    {
        public AntifraudSequenceEnum Sequence { get; set; }

        public AntifraudSequenceCriteriaEnum SequenceCriteria { get; set; }

        [StringLengthWitErrorCode(50, ApiErrorEnum.FingerPrintIdMaxLengthIsInvalid)]
        public string FingerPrintId { get; set; }

        public List<MerchantDefinedFieldModelV1> MerchantDefinedFields { get; set; }

        public CartDataModelV1 Cart { get; set; }

        public TravelDataModelV1 Travel { get; set; }

        public BrowserDataModelV1 Browser { get; set; }

        public ShippingDataModelV1 Shipping { get; set; }

        public Guid? Id { get; set; }

        public byte Status { get; set; }

        public bool? CaptureOnLowRisk { get; set; }

        public bool? VoidOnHighRisk { get; set; }

        public int? FraudAnalysisReasonCode { get; set; }

        public ReplyDataModelCieloV1 ReplyData { get; set; }

        public List<string> InvalidFields { get; set; }
    }
}