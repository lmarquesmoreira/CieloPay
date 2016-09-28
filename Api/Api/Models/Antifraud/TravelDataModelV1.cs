using System;
using System.Collections.Generic;
using Cielo.Api.CustomAttributes.Validation;
using Cielo.Api.Models.Enums;

namespace Cielo.Api.Models.CieloV1.Antifraud
{
    public class TravelDataModelV1
    {
        [StringLengthWitErrorCode(255, ApiErrorEnum.TravelDataRouteMaxLengthIsInvalid)]
        public string Route { get; set; }
        public DateTime? DepartureTime { get; set; }

        [StringLengthWitErrorCode(32, ApiErrorEnum.TravelDataJourneyTypeMaxLengthIsInvalid)]
        public string JourneyType { get; set; }

        public List<TravelLegDataModelV1> Legs { get; set; }
    }
}