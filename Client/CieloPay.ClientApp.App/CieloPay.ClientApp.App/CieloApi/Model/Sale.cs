using System;
using Xamarin.Forms.Pages;

namespace CieloPay.ClientApp.App.CieloApi.Model
{
    public class Sale
    {
        public string MerchantOrderId { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
    }

    public class Payment
    {
        public string Type => "CreditCard";
        public string Provider => "Simulado";
        public int Installments { get; set; }
        public long Amount { get; set; }
        public Card CreditCard { get; set; }
        public byte Status { get; set; }
        public string PaymentId { get; set; }
    }

    public class Card
    {
        public string Holder { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string Brand { get; set; }
        public bool SaveCard { get; set; }
        public Guid CardToken { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
    }
}
