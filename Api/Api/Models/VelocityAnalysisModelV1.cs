using System.Collections.Generic;

namespace Cielo.Api.Models.CieloV1
{
    public class VelocityAnalysisModelV1
    {
        public string Id { get; set; }

        public string ResultMessage { get; set; }

        public int Score { get; set; }

        public List<VelocityRejectReasonModelV1> RejectReasons { get; set; }
    }
}