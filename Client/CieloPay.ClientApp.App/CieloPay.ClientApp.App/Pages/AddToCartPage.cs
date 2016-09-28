using System;
using System.Collections.Generic;
using System.Linq;
using CieloPay.ClientApp.App.ViewModel;
using Xamarin.Forms;

namespace CieloPay.ClientApp.App.Pages
{
    public class AddToCartPage : ContentPage
    {
        public AddToCartPage(List<CartItem> cart, FoodMenuItemViewModel product)
        {
            var layout = new StackLayout();

            var image = new Image
            {
                Source = ImageSource.FromUri(new Uri(product.Image)),
                HeightRequest = 250,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var titleLabel = new Label
            {
                Text = product.Name,
                FontSize = 24,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var descriptionLabel = new Label
            {
                Text = product.Description,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var priceLabel = new Label
            {
                Text = "R$ " + product.Price.ToString("N2"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var quantityText = new Picker
            {
                Items = { "1", "2", "3", "4", "5", "6", "7", "8", "9" }
            };

            quantityText.SelectedIndex = 0;

            var buttonAdd = new Button
            {
                BorderRadius = 80,
                BorderWidth = 10,
                BackgroundColor = Color.FromHex("#6534AD"),
                TextColor = Color.White,
                Text = "Adicionar"
            };

            buttonAdd.Clicked += (sender, args) =>
            {
                var ci = cart.FirstOrDefault(c => c.Product == product);

                if (ci != null)
                    ci.Quantity = ci.Quantity + quantityText.SelectedIndex + 1;
                else
                {
                    cart.Add(new CartItem { Product = product, Quantity = quantityText.SelectedIndex + 1 });
                }

                Navigation.PopModalAsync();
            };

            layout.Children.Add(image);
            layout.Children.Add(titleLabel);
            layout.Children.Add(descriptionLabel);
            layout.Children.Add(priceLabel);
            layout.Children.Add(quantityText);
            layout.Children.Add(buttonAdd);

            layout.Spacing = 8;
            layout.Padding = 10;

            Content = layout;
        }
    }
}
