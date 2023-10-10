using MusicaNPN.DTOs;

namespace MusicaNPN.Services.Interfaces
{
    public interface IMusicaService
    {
        Task<List<MusicaDTO>> GetAllMusicasAsync();
        Task<GetMusicaDTO> GetMusicaByIdAsync(int musicaId);
        Task<List<GetMusicaDTO>> GetMusicasByGeneroAsync(string genero);
        Task<GetMusicaDTO> CreateMusicaAsync(Musica musica);
        Task<bool> DeleteMusicaAsync(int musicaId);
        Task<bool> UpdateMusicaAsync(int musicaId, MusicaDTO updateMusicaDto);
        Task<bool> UpdateMusicaNovoArtistaAsync(int musicaId, int artistId);
    }
}
