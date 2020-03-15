namespace ForceOfWillCube.ViewModels.AccountPages
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xamarin.Forms;

    public class SignInViewModel: BaseViewModel
    {
        public string WelcomeString => "Welcome to Force of Will Cube";
        public string LoginUserString => "Use this page to signin to our servers.";

        public Command LoginWithFacebook { get; set; }

        public SignInViewModel()
        {
            this.Title = "Sign in Cube";
            this.LoginWithFacebook = new Command(() => this.ExecuteLoginWithFacebook());
        }

        private void ExecuteLoginWithFacebook()
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.DisplayAlert(
                    "Ahah",
                    "Ahahah",
                    "Ah");
            });

            this.IsBusy = false;
        }
    }
}
