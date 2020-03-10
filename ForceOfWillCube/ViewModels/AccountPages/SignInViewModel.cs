namespace ForceOfWillCube.ViewModels.AccountPages
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SignInViewModel: BaseViewModel
    {
        public string WelcomeString => "Welcome to Force of Will Cube";
        public string LoginUserString => "Use this page to signin to our servers.";

        public SignInViewModel()
        {
            this.Title = "Sign in Cube";
        }
    }
}
