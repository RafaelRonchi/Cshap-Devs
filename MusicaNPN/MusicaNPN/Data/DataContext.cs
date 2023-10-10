using Microsoft.EntityFrameworkCore;
using MusicaNPN.Models;

namespace MusicaNPN.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Artista> Artistas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Musica>()
                .HasMany(m => m.Artistas)
                .WithMany(a => a.Musicas)
                .UsingEntity<Dictionary<string, object>>(
                "MusicaArtista",
                j => j.HasOne<Artista>().WithMany().HasForeignKey("ArtistaId"),
                j => j.HasOne<Musica>().WithMany().HasForeignKey("MusicaId")
                );
        }
    }
}
