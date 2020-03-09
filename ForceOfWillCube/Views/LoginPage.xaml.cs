namespace ForceOfWillCube.Views
{
    using ForceOfWillCube.ViewModels.AccountPages;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            this.InitializeComponent();
            this.BindingContext = new SignInViewModel();
        }
    }
}