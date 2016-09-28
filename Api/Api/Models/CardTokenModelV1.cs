using System.ComponentModel.DataAnnotations;

namespace Cielo.Api.Models.CieloV1
{
    public class CardTokenModelV1
    {
        public string CardNumber { get; set; }
        
        [StringLength(50)]
        public string Holder { get; set; }
        
        public string CustomerName { get; set; }
        
        public string ExpirationDate { get; set; }
    }
}