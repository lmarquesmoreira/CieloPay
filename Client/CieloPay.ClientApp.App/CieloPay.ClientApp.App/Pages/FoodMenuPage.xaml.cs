using System.Collections.Generic;
using CieloPay.ClientApp.App.ViewModel;
using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Themes;

namespace CieloPay.ClientApp.App.Pages
{
    public partial class FoodMenuPage : ContentPage
    {
        public List<CartItem> Cart;
        public List<ViewCell> currentCell;

        public FoodMenuPage()
        {
            this.Cart = new List<CartItem>();
            var restService = new RestService();

            InitializeComponent();

            var stackLayout = new StackLayout();

            var cart = new StackLayout();
            var closeButton = new PurpleButton()
            {
                Text = "Fechar pedido"
            };

            cart.Children.Add(closeButton);

            var items = restService.RefreshFoodMenu();
            
            var list = new ListView
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(FoddMenuCell)),
                ItemsSource = items,
                SeparatorColor = Color.Gray,
                Behaviors = { }
            };

            list.ItemTapped += (sender, args) =>
            {
                var addToCartPage = new AddToCartPage(Cart, args.Item as FoodMenuItemViewModel);

                this.Navigation.PushModalAsync(addToCartPage);
            };

            stackLayout.Children.Add(list);
            stackLayout.Children.Add(cart);

            closeButton.Clicked += (sender, args) =>
            {
                var checkoutPage = new CheckoutPage(this.Cart);
                this.Navigation.PushModalAsync(checkoutPage);
            };

            this.Content = stackLayout;
        }
    }

    public class FoddMenuCell : ViewCell
    {
        public FoddMenuCell()
        {
            var vetProfileImage = new CircleImage
            {
                BorderColor = Color.FromRgb(4, 175, 240),
                BorderThickness = 2,
                HeightRequest = 50,
                WidthRequest = 50,
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            vetProfileImage.SetBinding(Image.SourceProperty, "Image");

            var nameLabel = new Label()
            {
                FontFamily = "HelveticaNeue-Medium",
                FontSize = 18,
                TextColor = Color.Black
            };
            nameLabel.SetBinding(Label.TextProperty, "Name");

            var descriptionLabel = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 12,
                TextColor = Color.FromHex("#666")
            };
            descriptionLabel.SetBinding(Label.TextProperty, new Binding("Description"));

            var starLabel = new Label()
            {
                FontSize = 12,
                TextColor = Color.Gray
            };
            starLabel.SetBinding(Label.TextProperty, "Rate");

            var priceLabel = new Label()
            {
                FontSize = 14,
                TextColor = Color.Black
            };
            priceLabel.SetBinding(Label.TextProperty, "Price", stringFormat: " - R$  {0}");

            var starImage = new Image()
            {
                Source = "star.png",
                HeightRequest = 12,
                WidthRequest = 12
            };

            var ratingStack = new StackLayout()
            {
                Spacing = 3,
                Orientation = StackOrientation.Horizontal,
                Children = { starImage, starLabel, priceLabel }
            };

            var statusLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { descriptionLabel }
            };

            var vetDetailsLayout = new StackLayout
            {
                Padding = new Thickness(10, 0, 0, 0),
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { nameLabel, statusLayout, ratingStack }
            };

            var cellLayout = new StackLayout
            {
                Spacing = 0,
                Padding = new Thickness(10, 5, 10, 5),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { vetProfileImage, vetDetailsLayout }
            };

            this.View = cellLayout;

            this.Tapped += (sender, args) =>
            {
                this.View.BackgroundColor = Color.White;
            };
        }
    }
}