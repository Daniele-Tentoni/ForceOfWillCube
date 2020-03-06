namespace ForceOfWillCube.Utils
{
    using ForceOfWillCube.Models.Users;

    public interface IAuthenticatorManager
    {
        UserModel GetSignedUser();
        bool SigninUser(string username);
        bool SignoutUser();
    }
}
