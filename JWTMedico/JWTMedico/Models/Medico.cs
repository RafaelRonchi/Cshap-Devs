namespace JWTMedico.Models
{
    public class Medico
    {
        public string Senha { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CRMHash { get; set; } = string.Empty;
    }
}
