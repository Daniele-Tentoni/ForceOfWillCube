using Xamarin.Forms;

namespace ForceOfWillCube.Views.AboutViews
{
    public class AboutPage : ContentPage
    {
        public AboutPage()
        {
            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Padding = new Thickness(10, 5, 10, 5),
                    Children = {
                        new WhiteLabel { Text = "Hi, this is an about page." },
                        new WhiteLabel { Text = "You can use this app to manage your Force of Will Cube collections." },
                        new WhiteLabel { Text = "Don't forget to support the developer with an high rating on the store!" }
                    }
                }
            };
        }

        public class WhiteLabel : Label
        {
            public WhiteLabel()
            {
                this.TextColor = Color.White;
                this.FontSize = 24;
            }
        }
    }
}