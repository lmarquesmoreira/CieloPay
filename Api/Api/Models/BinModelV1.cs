namespace Api.Models
{
    public class BinModelV1
    {
        public string BinNumber { get; set; }
        public string Status { get; set; }
        public string Provider { get; set; }
        public string Issuer { get; set; }
        public string CardType { get; set; }
        public bool ForeignCard { get; set; }
    }
}