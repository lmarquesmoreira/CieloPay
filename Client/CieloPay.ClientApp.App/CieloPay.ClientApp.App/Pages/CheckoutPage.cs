using System;
using System.Collections.Generic;
using System.Linq;
using CieloPay.ClientApp.App.CieloApi;
using CieloPay.ClientApp.App.CieloApi.Model;
using CieloPay.ClientApp.App.ViewModel;
using Xamarin.Forms;

namespace CieloPay.ClientApp.App.Pages
{
    public class CheckoutPage : ContentPage
    {
        public CheckoutPage(List<CartItem> cart)
        {
            var layout = new StackLayout();
            layout.Padding = 10;
            layout.Spacing = 10;

            var titleLabel = new Label
            {
                Text = "Detalhes do pedido",
                FontSize = 24
            };

            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                }
            };

            grid.Children.Add(new Label { Text = "Item", FontSize = 18 }, 0, 0);
            grid.Children.Add(new Label { Text = "Qtd      ", FontSize = 18 }, 1, 0);
            grid.Children.Add(new Label { Text = "Valor", FontSize = 18 }, 2, 0);


            int i = 1;
            foreach (var cartItem in cart)
            {
                grid.RowDefinitions.Add(new RowDefinition
                {
                    Height = GridLength.Auto,
                });

                grid.Children.Add(new Label
                {
                    Text = cartItem.Product.Name
                }, 0, i);

                grid.Children.Add(new Label
                {
                    Text = cartItem.Quantity.ToString()
                }, 1, i);

                grid.Children.Add(new Label
                {
                    Text = "R$ " + (cartItem.Quantity * cartItem.Product.Price).ToString("N2")
                }, 2, i);

                i++;
            }

            grid.Children.Add(new Label { Text = "Total", FontSize = 18 }, 0, i);
            grid.Children.Add(new Label { Text = "R$ " + cart.Sum(x => x.Quantity * x.Product.Price).ToString("N2"), FontSize = 18 }, 2, i);

            var closeButton = new PurpleButton
            {
                Text = "Finalizar"
            };

            var shippingPicker = new Picker
            {
                Items =
                {
                    "Retirar na loja",
                    "Entrega + R$ 3,00"
                }
            };

            shippingPicker.SelectedIndex = 0;


            var cards = new Dictionary<Guid, string>
            {
                {Guid.Parse("df0f3a85-8633-475a-aea0-f052cf8058c0"), "476608******5300"},
                {Guid.Parse("813572bf-6524-4fca-8c51-235bbd93e9e2"), "516230******0400"}
            };

            var cardPicker = new Picker();

            foreach (var card in cards)
            {
                cardPicker.Items.Add(card.Value);
            }

            cardPicker.SelectedIndex = 0;

            layout.Children.Add(titleLabel);
            layout.Children.Add(grid);
            layout.Children.Add(new Label { Text = "Cartão:" });
            layout.Children.Add(shippingPicker);
            layout.Children.Add(cardPicker);
            layout.Children.Add(closeButton);

            this.Content = layout;

            closeButton.Clicked += (sender, args) =>
            {
                if(shippingPicker.SelectedIndex == 1)
                    cart.Add(new CartItem
                    {
                        Quantity = 1,
                        Product = new FoodMenuItemViewModel
                        {
                            Name = "Frete",
                            Description = "Frete",
                            Price = 3
                        }
                    });

                var cs = new CieloApiClient();

                var sale = new Sale
                {
                    MerchantOrderId = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                    Customer = new Customer
                    {
                        Name = "Paulo H S Fernandes"
                    },
                    Payment = new Payment
                    {
                        Amount = Convert.ToInt64(cart.Sum(x => x.Quantity * x.Product.Price) * 100),
                        Installments = 1,
                        CreditCard = new Card
                        {
                            CardToken =
                                cardPicker.SelectedIndex == 0
                                    ? Guid.Parse("df0f3a85-8633-475a-aea0-f052cf8058c0")
                                    : Guid.Parse("813572bf-6524-4fca-8c51-235bbd93e9e2")
                        }
                    }
                };

                var response = cs.PostSaleAsync(sale);

                if (response.Payment.Status == 1)
                {
                    var lioOrder = new LioOrder
                    {
                        Reference = "Pedido #" + DateTime.Now.ToString("ssfff"),
                        UserId = 1,
                        Status = "ENTERED",
                        PaymentId = Guid.Parse(response.Payment.PaymentId),
                        VelocityApproved = cardPicker.SelectedIndex == 0,
                        Items = cart.Select(x => new LioOrderItem
                        {
                            Name = x.Product.Name,
                            Description = x.Product.Description,
                            Quantity = x.Quantity,
                            Sku = DateTime.Now.ToString("HHmmssfff"),
                            Unit_Price = x.Product.Price,
                            ImageUrl = x.Product.Image
                        }).ToList()
                    };

                    var lr = cs.PostOrder(lioOrder);

                    cart.RemoveAll(x => x != null);

                    this.Navigation.PopModalAsync();
                    this.Navigation.PushModalAsync(new CheckoutSuccessPage(lr.LioResponseId, cardPicker.SelectedIndex == 1));
                }
            };
        }
    }
}
