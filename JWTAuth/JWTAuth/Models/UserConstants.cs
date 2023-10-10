namespace JWTAuth.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>
        {
            new UserModel()
            {
                Username = "rafael_admin",
                EmailAddress = "rafael@email.com",
                Password = "admin",
                GivenName = "Rafael",
                Surname = "admin",
                Role = "Administrator"
            }
        };
    }
}
