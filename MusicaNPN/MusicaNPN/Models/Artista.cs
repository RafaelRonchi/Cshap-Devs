namespace MusicaNPN.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Funcao { get; set; } = string.Empty;

        public List<Musica> Musicas { get; set;} = new List<Musica> { };
       
    }
}
