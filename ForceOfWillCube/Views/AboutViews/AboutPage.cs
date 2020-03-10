using System;

using Xamarin.Forms;

namespace ForceOfWillCube.Views.AboutViews
{
    public class AboutPage : ContentPage
    {
        public AboutPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

