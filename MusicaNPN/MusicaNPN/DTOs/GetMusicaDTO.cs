namespace MusicaNPN.DTOs
{
    public class GetMusicaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;


        public List<string> Artistas { get; set; } = new List<string>();
    }
}
