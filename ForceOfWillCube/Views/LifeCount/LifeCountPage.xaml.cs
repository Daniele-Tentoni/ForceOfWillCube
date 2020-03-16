using System.Diagnostics;
using ForceOfWillCube.ViewModels.LifeCount;
using Xamarin.Forms;

namespace ForceOfWillCube.Views.LifeCount
{
    public partial class LifeCountPage : ContentPage
    {
        private readonly LifeCountViewModel viewModel;

        public LifeCountPage()
        {
            InitializeComponent();
            this.BindingContext = this.viewModel = new LifeCountViewModel();
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
            if (!this.viewModel.HasPlayers())
            {
                var player1 = this.viewModel.AddPlayer("Guest player 1");
                player1.RotateTo(180);
                this.PlayerGrid.Children.Add(player1, 0, 0);
                var player2 = this.viewModel.AddPlayer("Guest player 2");
                this.PlayerGrid.Children.Add(player2, 0, 1);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            Debug.WriteLine("Back button pressed in Life Count Page.");
            return base.OnBackButtonPressed();
        }
    }
}
