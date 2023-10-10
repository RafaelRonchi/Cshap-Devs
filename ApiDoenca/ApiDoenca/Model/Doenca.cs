namespace ApiDoenca.Model
{
    public class Doenca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<string> Sintomas { get; set; } = new List<string>();
        public bool Cura { get; set;}
    }
}
