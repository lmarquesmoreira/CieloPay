using System;
using System.Collections.Generic;

namespace CieloPay.ClientApp.App
{
	public class MyOrdersViewModel
	{
		public string Id
		{
			get;
			set;
		}
		public string Number
		{
			get;
			set;
		}
		public string Reference
		{
			get;
			set;
		}
		public string Status
		{
			get;
			set;
		}
		public string Created_at
		{
			get;
			set;
		}
		public string Updated_at
		{
			get;
			set;
		}
		public List<Items> Items { get; set;}

		public string Notes
		{
			get;
			set;
		}
		public List<Transaction> Transaction
		{
			get;
			set;
		}
		private decimal _price;
		public decimal Price
		{
			get { return _price / 100; }
			set { _price = value;}
		}
		public decimal Remaining
		{
			get;
			set;
		}

	}
}
