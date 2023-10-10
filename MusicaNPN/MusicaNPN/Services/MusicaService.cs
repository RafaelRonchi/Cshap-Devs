using Microsoft.EntityFrameworkCore;
using MusicaNPN.Data;
using MusicaNPN.DTOs;
using MusicaNPN.Services.Interfaces;

namespace MusicaNPN.Services
{
    public class MusicaService : IMusicaService
    {
        private readonly DataContext _context;

        public MusicaService(DataContext context)
        {
            _context = context;
        }
        // CRIAR MUSICA
        public async Task<GetMusicaDTO> CreateMusicaAsync(Musica musica)
        {
            _context.Musicas.Add(musica);
            await _context.SaveChangesAsync();
            GetMusicaDTO m = new GetMusicaDTO();

            m.Id = musica.Id;
            m.Titulo = musica.Titulo;
            m.Genero = musica.Genero;


            return m;
        }

        public Task<bool> DeleteMusicaAsync(int musicaId)
        {
            throw new NotImplementedException();
        }

        // LISTA DE MUSICAS
        public async Task<List<GetMusicaDTO>> GetAllMusicasAsync()
        {
            var musicas = await _context.Musicas.Include(m => m.Artistas).Select(m => new GetMusicaDTO
            {
                Id = m.Id,
                Titulo = m.Titulo,
                Genero = m.Genero,
                Artistas = m.Artistas.Select(a => a.Name).ToList(),
            }).ToListAsync();
            return musicas;
        }
        // PEGA PELO ID
        public async Task<GetMusicaDTO> GetMusicaByIdAsync(int musicaId)
        {
            var musicas = await _context.Musicas.Include(m => m.Artistas).Select(m => new GetMusicaDTO
            {
                Id = m.Id,
                Titulo = m.Titulo,
                Genero = m.Genero,
                Artistas = m.Artistas.Select(a => a.Name).ToList(),
            }).FirstOrDefaultAsync(m => m.Id == musicaId);
            return musicas;
        }

        public Task<List<GetMusicaDTO>> GetMusicasByGeneroAsync(string genero)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMusicaAsync(int musicaId, MusicaDTO updateMusicaDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMusicaNovoArtistaAsync(int musicaId, int artistId)
        {
            throw new NotImplementedException();
        }
    }
}
