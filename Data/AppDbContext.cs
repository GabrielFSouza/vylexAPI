using Microsoft.EntityFrameworkCore;
using vylexAPI.Models;


namespace vylexAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estudante> Estudantes { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Curso)
                .WithMany(c => c.Avaliacoes)
                .HasForeignKey(a => a.CursoId);

            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Estudante)
                .WithMany(e => e.Avaliacoes)
                .HasForeignKey(a => a.EstudanteId);
        }
    }
}
