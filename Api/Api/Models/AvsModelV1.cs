namespace Api.Models
{
    public class AvsModelV1
    {
        public string Cpf { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public byte? Status { get; set; }
        public string ReturnCode { get; set; }
    }
}