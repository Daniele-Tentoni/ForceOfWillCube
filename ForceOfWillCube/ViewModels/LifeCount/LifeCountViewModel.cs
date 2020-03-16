using System.Collections.Generic;
using ForceOfWillCube.Views;
using ForceOfWillCube.Views.LifeCount;
using Xamarin.Forms;

namespace ForceOfWillCube.ViewModels.LifeCount
{
    public class LifeCountViewModel : BaseViewModel
    {
        private readonly List<PlayerView> players;

        public Command ShowLogCommand { get; }
        public Command ResetPlayersCommand { get; }

        public LifeCountViewModel()
        {
            this.Title = "Lifecount";
            this.players = new List<PlayerView>();

            this.ShowLogCommand = new Command(
                () => this.ExecuteShowLog(),
                () => !this.IsBusy);

            this.ResetPlayersCommand = new Command(
                () => this.ExecuteResetPlayers(),
                () => !this.IsBusy);
        }

        public bool HasPlayers(int number = 2)
        {
            return this.players != null && this.players.Count >= number;
        }

        public PlayerView AddPlayer(string name)
        {
            var player = new PlayerView(name);
            this.players.Add(player);
            return player;
        }

        private void ExecuteShowLog()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var mainPage = (DrawerPage)Application.Current.MainPage;
                var detail = (NavigationPage)mainPage.Detail;
                await detail.PushAsync(new LifeLogPage(), true);
            });
        }

        private void ExecuteResetPlayers()
        {
            App.Local.ClearLifecountLogs();
            foreach (var player in this.players)
            {
                player.Reset();
            }
        }
    }
}
