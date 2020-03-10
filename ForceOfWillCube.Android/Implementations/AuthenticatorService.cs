using ForceOfWillCube.Droid.Implementations;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthenticatorService))]
namespace ForceOfWillCube.Droid.Implementations
{
    using Android.App;
    using Android.Content;
    using Android.Util;
    using ForceOfWillCube.Models.Users;
    using ForceOfWillCube.Utils;
    using System;

    public class AuthenticatorService : IAuthenticatorService
    {
        private readonly ISharedPreferences sharedPreferences;

        private UserModel currentUser;

        public AuthenticatorService()
        {
            this.sharedPreferences = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            this.currentUser = new UserModel
            {
                Email = this.sharedPreferences.GetString("user_email", string.Empty),
                IsLogged = this.sharedPreferences.GetBoolean("is_logged", false),
                PhotoUrl = this.sharedPreferences.GetString("user_photo_url", string.Empty),
                UserId = this.sharedPreferences.GetInt("user_user_id", 0),
                Username = this.sharedPreferences.GetString("user_username", "Guest User")
            };
        }

        public bool SigninUser(string username)
        {
            this.currentUser.Email = username;
            this.currentUser.IsLogged = true;
            this.currentUser.PhotoUrl = string.Empty;
            this.currentUser.UserId = 1;
            this.currentUser.Username = username;
            return this.EditPreferences(this.sharedPreferences.Edit(), this.currentUser);
        }

        public bool SignoutUser()
        {
            this.currentUser = new UserModel { IsLogged = false, Username = "Guest User" };
            return this.EditPreferences(this.sharedPreferences.Edit(), this.currentUser);
        }

        private bool EditPreferences(ISharedPreferencesEditor editor, UserModel model)
        {
            try
            {
                editor.PutString("user_email", string.Empty);
                editor.PutBoolean("is_logged", false);
                editor.PutString("user_photo_url", string.Empty);
                editor.PutInt("user_user_id", model.UserId);
                editor.PutString("user_username", string.Empty);
                editor.Apply();
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