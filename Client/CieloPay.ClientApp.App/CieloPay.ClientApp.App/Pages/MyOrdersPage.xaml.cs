using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace CieloPay.ClientApp.App.Pages
{
	public partial class MyOrdersPage : ContentPage
	{

		public MyOrdersPage()
		{
			InitializeComponent();
			RestService restService = new RestService();
			var user = restService.User();
			var stackLayout = new StackLayout();
			var img = new StackLayout();
			img.Padding = 40;

			var vetProfileImage = new CircleImage
			{
				BorderColor = Color.FromRgb(4, 175, 240),
				BorderThickness = 2,
				HeightRequest = 100,
				WidthRequest = 100,
				Aspect = Aspect.AspectFill,
				VerticalOptions = LayoutOptions.Center,
			};

			vetProfileImage.Source = user.ImagemUrl;

		
			var descriptionLabel = new Label
			{
				Text = user.Name,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			var emailLabel = new Label
			{
				Text = user.Email,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			var addressLabel = new Label
			{
				Text = user.Addresses[0].Street + " - " + user.Addresses[0].State + " - " + user.Addresses[0].ZipCode,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			img.Children.Add(vetProfileImage);
			stackLayout.Children.Add(img);
			stackLayout.Children.Add(descriptionLabel);
			stackLayout.Children.Add(emailLabel);
			stackLayout.Children.Add(addressLabel);

			this.Content = stackLayout;


		}
	}
}

