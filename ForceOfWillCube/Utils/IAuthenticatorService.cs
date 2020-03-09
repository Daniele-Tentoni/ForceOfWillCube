namespace ForceOfWillCube.Utils
{
    using ForceOfWillCube.Models.Users;

    public interface IAuthenticatorService
    {
        UserModel GetSignedUser();
        bool SigninUser(string username);
        bool SignoutUser();
    }
}
