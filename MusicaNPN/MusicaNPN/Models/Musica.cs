namespace MusicaNPN.Models
{
    public class Musica
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public List<Artista> Artistas { get; set; } = new List<Artista> { };
    }
}
