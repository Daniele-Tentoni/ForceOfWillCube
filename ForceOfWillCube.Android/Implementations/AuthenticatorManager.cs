using ForceOfWillCube.Droid.Implementations;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthenticatorManager))]
namespace ForceOfWillCube.Droid.Implementations
{
    using Android.App;
    using Android.Content;
    using Android.Util;
    using ForceOfWillCube.Models.Users;
    using ForceOfWillCube.Utils;
    using System;

    public class AuthenticatorManager : IAuthenticatorManager
    {
        private readonly ISharedPreferences sharedPreferences;

        private UserModel currentUser;

        public AuthenticatorManager()
        {
            this.sharedPreferences = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            this.currentUser = new UserModel
            {
                Email = this.sharedPreferences.GetString("user_email", string.Empty),
                IsLogged = this.sharedPreferences.GetBoolean("is_logged", false),
                PhotoUrl = this.sharedPreferences.GetString("user_photo_url", string.Empty),
                Username = this.sharedPreferences.GetString("user_username", "Guest User")
            };
        }

        public bool SigninUser(string username)
        {
            this.currentUser.Email = username;
            this.currentUser.IsLogged = true;
            this.currentUser.PhotoUrl = string.Empty;
            this.currentUser.Username = username;
            return this.EditPreferences(this.currentUser);
        }

        public bool SignoutUser()
        {
            this.currentUser = new UserModel { IsLogged = false, Username = "Guest User" };
            return this.EditPreferences(this.currentUser);
        }

        private bool EditPreferences(UserModel model)
        {
            try
            {
                this.sharedPreferences.Edit().PutString("user_email", string.Empty);
                this.sharedPreferences.Edit().PutBoolean("is_logged", false);
                this.sharedPreferences.Edit().PutString("user_photo_url", string.Empty);
                this.sharedPreferences.Edit().PutString("user_username", string.Empty);
                this.sharedPreferences.Edit().Apply();
                return true;
            }
            catch (Exception e)
            {
                Log.Error("AUTHENTICATOR MANAGER", "Catched exception in signin.");
                throw e;
            }
        }

        public UserModel GetSignedUser() => this.currentUser;
    }
}