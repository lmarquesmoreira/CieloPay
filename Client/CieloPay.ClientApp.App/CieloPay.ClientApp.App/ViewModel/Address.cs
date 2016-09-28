using System;
namespace CieloPay.ClientApp.App
{
	public class Address
	{
		public Address()
		{
		}
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Street { get; set; }
		public string Number { get; set; }
		public string ZipCode { get; set; }
		public string Neighborhood { get; set; }
		public string State { get; set; }
		public User User { get; set; }
	}
}
