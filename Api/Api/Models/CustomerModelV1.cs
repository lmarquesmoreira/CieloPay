using System;

namespace Api.Models
{
    public class CustomerModelV1
    {
        public string Name { get; set; }
        public string Identity { get; set; }
        public string IdentityType { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public AddressModelV1 Address { get; set; }
        public AddressModelV1 DeliveryAddress { get; set; }
        public string IpAddress { get; set; }
    }
}