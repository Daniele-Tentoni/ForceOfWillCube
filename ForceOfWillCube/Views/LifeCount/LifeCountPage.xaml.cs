using System.Diagnostics;
using ForceOfWillCube.ViewModels.LifeCount;
using Xamarin.Forms;

namespace ForceOfWillCube.Views.LifeCount
{
    public partial class LifeCountPage : ContentPage
    {
        public LifeCountPage()
        {
            InitializeComponent();
            this.BindingContext = new LifeCountViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            /*
             * Prepared for the 2+ player mode.
             * string prompt1 = null, prompt2 = null;
            var player1 = Device.InvokeOnMainThreadAsync(async () =>
             {
                 prompt1 = await Application.Current.MainPage.DisplayPromptAsync(
                     "Lifecount",
                     "Name of player 1",
                     "Generate",
                     "Abort",
                     "2",
                     1,
                     Keyboard.Numeric,
                     "2");
                 prompt2 = await Application.Current.MainPage.DisplayPromptAsync(
                      "Lifecount",
                      "Name of player 2",
                      "Generate",
                      "Abort",
                      "2",
                      1,
                      Keyboard.Numeric,
                      "2");
             });
            await player1;
            */

            // Await the prompts to be showed and completed.
            var player1 = new PlayerView("Guest player 1");
            player1.RotateTo(180);
            this.PlayerGrid.Children.Add(player1, 0, 0);
            this.PlayerGrid.Children.Add(new PlayerView("Guest player 2"), 0, 1);
        }

        protected override bool OnBackButtonPressed()
        {
            Debug.WriteLine("Back button pressed in Life Count Page.");
            return base.OnBackButtonPressed();
        }
    }
}
