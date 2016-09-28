using System;
using Xamarin.Forms;

namespace CieloPay.ClientApp.App.Pages
{
	public partial class OffersPage : ContentPage
	{
		public OffersPage()
		{
			InitializeComponent();
			var restService = new RestService();
			var items = restService.Orders();

			var stackLayout = new StackLayout();

			var list = new ListView
			{
				HasUnevenRows = true,
				ItemTemplate = new DataTemplate(typeof(OffersMenuCell)),
				ItemsSource = items,
				SeparatorColor = Color.Gray,
				Behaviors = { }
			};
			list.ItemTapped += (sender, args) =>
			{
				var ItemsOrderPage = new ItemsOrderPage((args.Item as MyOrdersViewModel).Items, args.Item as MyOrdersViewModel);
				this.Navigation.PushModalAsync(ItemsOrderPage);
			};
			stackLayout.Children.Add(list);
			this.Content = stackLayout;
		}

		public class OffersMenuCell : ViewCell
		{
			public OffersMenuCell()
			{
				var nameLabel = new Label()
				{
					FontFamily = "HelveticaNeue-Medium",
					FontSize = 18,
					TextColor = Color.Black
				};

				nameLabel.SetBinding(Label.TextProperty, "Reference", stringFormat: "Pedido: {0}");


				var starLabel = new Label()
				{
					FontSize = 12,
					TextColor = Color.Black
				};
				starLabel.SetBinding(Label.TextProperty, "Quantity");

				var priceLabel = new Label()
				{
					FontSize = 14,
					TextColor = Color.Black
				};

				priceLabel.SetBinding(Label.TextProperty, "Price", stringFormat: " Total : R$  {0}");


				var ratingStack = new StackLayout()
				{
					Spacing = 3,
					Orientation = StackOrientation.Horizontal,
					Children = { starLabel, priceLabel }
				};


				var vetDetailsLayout = new StackLayout
				{
					Padding = new Thickness(10, 0, 0, 0),
					Spacing = 0,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					Children = { nameLabel, ratingStack }
				};

				var cellLayout = new StackLayout
				{
					Spacing = 0,
					Padding = new Thickness(10, 5, 10, 5),
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					Children = { vetDetailsLayout }
				};

				this.View = cellLayout;

				this.Tapped += (sender, args) =>
				{
					this.View.BackgroundColor = Color.White;
				};
			}
		}
	}
}
