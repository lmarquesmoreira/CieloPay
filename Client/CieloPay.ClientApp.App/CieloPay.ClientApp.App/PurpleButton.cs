using Xamarin.Forms;

namespace CieloPay.ClientApp.App
{
    public class PurpleButton : Button
    {
        public PurpleButton()
        {
            BorderRadius = 180;
            BorderWidth = 30;
            BackgroundColor = Color.FromHex("#6534AD");
            TextColor = Color.White;
        }
    }
}
