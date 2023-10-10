namespace JWTAuth.Models
{
    public class UsersConstants
    {
        public static List<UserModel> Users = new List<UserModel>
        {
            new UserModel()
            {
                Role = "Aluno",
                FullName = "RafaelAluno",
                EmailAddress = "aluno@email",
            },
            new UserModel()
            {
                Role = "Professor",
                FullName = "RafaelProfessor",
                EmailAddress = "professor@email",
            },
            new UserModel()
            {
                Role = "Diretor",
                FullName = "RafaelDiretor",
                EmailAddress = "diretor@email",
            }
        };
    }
}
