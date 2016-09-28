namespace Cielo.Api.Models.CieloV1.Antifraud
{
    public class BrowserDataModelV1
    {
        public string HostName { get; set; }
        public bool CookiesAccepted { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string IpAddress { get; set; }
    }
}