using Microsoft.EntityFrameworkCore;

namespace FichaCadastroApi.Model
{
    public class FichaCadastroDbContext : DbContext
    {
        public FichaCadastroDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FichaModel> FichaModels { get; set; }
        public DbSet<DetalheModel> DetalheModels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalheModel>()
                        .HasOne(e => e.Ficha)
                        .WithMany(x => x.Detalhes)
                        .Metadata
                        .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<DetalheModel>()
                        .Property(p => p.DataCadastro)
                        .HasDefaultValueSql("GETDATE()");


            modelBuilder.Entity<FichaModel>()
                        .Property(p => p.DataCadastro)
                        .HasDefaultValueSql("GETDATE()");


            modelBuilder.Entity<FichaModel>().HasData(new FichaModel
            {
                Id= 1,
                DataCadastro = DateTime.Now,
                DataNascimento = DateTime.Now,
                Email = "teste@email.com.br",
                Nome = "teste"
            });
            
                base.OnModelCreating(modelBuilder);
        }
    }
}
