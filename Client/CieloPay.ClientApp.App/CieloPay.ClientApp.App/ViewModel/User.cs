using System;
using System.Collections.Generic;
using CieloPay.ClientApp.App.CieloApi.Model;

namespace CieloPay.ClientApp.App
{
	public class User
	{
		public User()
		{

		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Telefone { get; set; }
		public string ImagemUrl { get; set; }
		public string OauthToken { get; set; }
		public List<Card> Cards { get; set; }
		public List<Address> Addresses { get; set; }

	}
}
