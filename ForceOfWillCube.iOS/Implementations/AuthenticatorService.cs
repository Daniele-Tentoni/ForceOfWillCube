using System;
using Xamarin.Forms;
using ForceOfWillCube.iOS.Implementations;
using Foundation;
using ForceOfWillCube.Models.Users;
using ForceOfWillCube.Utils;
using System.Diagnostics;

[assembly: Dependency(typeof(AuthenticatorService))]
namespace ForceOfWillCube.iOS.Implementations
{
    public class AuthenticatorService : IAuthenticatorService
    {
        private readonly NSUserDefaults userDefaults;
        private UserModel currentUser;

        public AuthenticatorService()
        {
            this.userDefaults = NSUserDefaults.StandardUserDefaults;
            this.currentUser = this.ReadUserFromPreferences(this.userDefaults);
        }

        public UserModel GetSignedUser() => this.currentUser;

        public bool SigninUser(string username)
        {
            this.currentUser.Email = username;
            this.currentUser.IsLogged = true;
            this.currentUser.PhotoUrl = string.Empty;
            this.currentUser.Username = username;
            this.currentUser.UserId = 1;
            return this.EditPreferences(this.userDefaults, this.currentUser);
        }

        public bool SignoutUser()
        {
            this.currentUser = new UserModel { IsLogged = false, Username = "Guest user" };
            return this.EditPreferences(this.userDefaults, this.currentUser);
        }

        private UserModel ReadUserFromPreferences(NSUserDefaults preferences)
        {
            return new UserModel
            {
                Email = preferences.StringForKey("user_email"),
                IsLogged = preferences.BoolForKey("is_logged"),
                PhotoUrl = preferences.StringForKey("user_photo_url"),
                UserId = (int)preferences.IntForKey("user_user_id"),
                Username = preferences.StringForKey("user_username")
            };
        }

        private bool EditPreferences(NSUserDefaults defaults, UserModel user)
        {
            try
            {
                defaults.SetString(user.Email, "user_mail");
                defaults.SetBool(user.IsLogged, "is_logged");
                defaults.SetString(user.PhotoUrl, "user_photo_url");
                defaults.SetInt(user.UserId, "user_user_id");
                defaults.SetString(user.Username, "user_username");
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("AUTHENTICATOR MANAGER", "Catched exception.");
                throw e;
            }
        }
    }
}
