namespace ForceOfWillCube.Views
{
    using ForceOfWillCube.ViewModels.MainPage;
    using System.ComponentModel;
    using Xamarin.Forms;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel viewModel;
        public MainPage()
        {
            this.InitializeComponent();
            this.BindingContext = this.viewModel = new MainPageViewModel();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
        }
    }
}
