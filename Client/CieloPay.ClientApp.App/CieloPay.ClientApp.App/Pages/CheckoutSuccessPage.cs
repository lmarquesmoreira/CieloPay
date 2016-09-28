using Xamarin.Forms;

namespace CieloPay.ClientApp.App.Pages
{
    public class CheckoutSuccessPage : ContentPage
    {
        public CheckoutSuccessPage(string lioId, bool highRisk)
        {
            var layout = new StackLayout();
            layout.Padding = 10;
            layout.Spacing = 10;

            var titleLabel = new Label
            {
                FontSize = 28,
                Text = "Pedido realizado com sucesso",
                TextColor = Color.FromHex("#6534AD"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var lioIdLabel = new Label
            {
                FontSize = 18,
                Text = "Lio ID: " + lioId,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            layout.Children.Add(titleLabel);
            layout.Children.Add(lioIdLabel);

            if (highRisk)
            {
                layout.Children.Add(new Label
                {
                    Text = "Para sua segurança, será necessária a digitação da senha no momento da entrega do produto."
                });
            }

            this.Content = layout;
        }
    }
}
