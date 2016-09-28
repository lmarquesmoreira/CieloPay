using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Api.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string ImagemUrl { get; set; }
        public string OauthToken { get; set; }
        public List<Card> Cards { get; set; }
        public List<Address> Addresses { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }

    public class Card
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MaskedCard { get; set; }
        public string Brand { get; set; }
        public Guid Token { get; set; }
        public bool Favorite { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public User User { get; set; }
    }

    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public User Cliente { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }
        public string Valor { get; set; }
    }

    public class ItemPedido
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Classificacao { get; set; }
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
        public string Valor { get; set; }
        public int Quantidade { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }

    public class LioOrder
    {
        public LioOrder()
        {
            id = Guid.NewGuid();
            updated_at = DateTime.Now.AddHours(-3).ToString("s");
        }
        public Guid id { get; set; }
        public Guid PaymentId { get; set; }
        public string number { get; set; }
        public string reference { get; set; }
        public string status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<LioOrderItem> items { get; set; }
        public string notes { get; set; }
        public decimal remaining { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal price { get; set; }
        public string LioResponseId { get; set; }
        public bool VelocityApproved { get; set; }
        public ICollection<LioOrderItem> OrderItens { get; set; }
    }

    public class LioOrderItem
    {
        public LioOrderItem()
        {
            Id = Guid.NewGuid();
            sku = "";
        }
        public Guid Id { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal unit_price { get; set; }
        public int quantity { get; set; }
        public string unit_of_measure { get; set; }
        public string details { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public Guid OrderId { get; set; }
        public string ImageUrl { get; set; }
        public LioOrder Order { get; set; }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }


}