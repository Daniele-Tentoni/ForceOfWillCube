namespace ForceOfWillCube.Utils
{
    using ForceOfWillCube.Models.Users;
    using Xamarin.Forms;

    public class AuthenticatorManager
    {
        private readonly IAuthenticatorService authService = DependencyService.Get<IAuthenticatorService>();

        public UserModel SignedUser => this.authService.GetSignedUser();

        public void SignIn(string username)
        {
            var result = this.authService.SigninUser(username);
            if (result)
                MessagingCenter.Send(this, AppStrings.USER_SIGN_IN);
            else
                MessagingCenter.Send(this, AppStrings.USER_NOT_SIGN_IN);
        }

        public void SignOut()
        {
            var result = this.authService.SignoutUser();
            if (result)
                MessagingCenter.Send(this, AppStrings.USER_SIGN_OUT);
            else
                MessagingCenter.Send(this, AppStrings.USER_NOT_SIGN_OUT);
        }
    }
}
