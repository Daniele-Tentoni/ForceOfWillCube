namespace ForceOfWillCube.Models.Users
{
    public class UserModel
    {
        public string Email { get; set; }
        public bool IsLogged { get; set; }
        public string PhotoUrl { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}
