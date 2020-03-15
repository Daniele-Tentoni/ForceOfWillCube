using ForceOfWillCube.Views;
using ForceOfWillCube.Views.LifeCount;
using Xamarin.Forms;

namespace ForceOfWillCube.ViewModels.LifeCount
{
    public class LifeCountViewModel : BaseViewModel
    {
        public Command ShowLog { get; }

        public LifeCountViewModel()
        {
            this.Title = "Lifecount";

            this.ShowLog = new Command(
                () => this.ExecuteShowLog(),
                () => this.IsBusy);
        }

        private void ExecuteShowLog()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var mainPage = (DrawerPage)Application.Current.MainPage;
                var detail = (NavigationPage)mainPage.Detail;
                await detail.PushAsync(new LogChangesPage());
            });
        }
    }
}
