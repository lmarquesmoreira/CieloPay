using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CieloPay.ClientApp.App
{
	public class ItemsOrderPage : ContentPage
	{
		public ItemsOrderPage(List<Items> Items, MyOrdersViewModel Order)
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
			foreach (var cartItem in Items)
			{
				grid.RowDefinitions.Add(new RowDefinition
				{
					Height = GridLength.Auto,
				});

				grid.Children.Add(new Label
				{
					Text = cartItem.Name
				}, 0, i);

				grid.Children.Add(new Label
				{
					Text = cartItem.Quantity.ToString()
				}, 1, i);

				grid.Children.Add(new Label
				{
					Text = "R$ " + (cartItem.Unit_price/100).ToString()
				}, 2, i);

				i++;
			}

			grid.Children.Add(new Label { Text = "Total", FontSize = 18 }, 0, i);
			grid.Children.Add(new Label { Text = "R$ " + Order.Price.ToString(), FontSize = 18 }, 2, i);

			var closeButton = new PurpleButton
			{
				Text = "Voltar"
			};



			layout.Children.Add(titleLabel);
			layout.Children.Add(grid);


			layout.Children.Add(closeButton);

			this.Content = layout;

			closeButton.Clicked += (sender, args) =>
			{
				this.Navigation.PopModalAsync();
			};
		}
	}
}
