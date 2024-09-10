using Microsoft.EntityFrameworkCore;
using VideogiochiAppApi.Model;

namespace VideogiochiAppApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Videogioco> Videogiochi { get; set; }
        public DbSet<Proprietario> Proprietari { get; set; }
        public DbSet<Paese> Paesi { get; set; }
        public DbSet<VideogiocoProprietario> VideogiocoProprietari { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Paese
            modelBuilder.Entity<Paese>().HasData(
                new Paese { IdPaese = 1, Name = "Italia" },
                new Paese { IdPaese = 2, Name = "USA" }
            );

            // Seed data for Proprietario
            modelBuilder.Entity<Proprietario>().HasData(
                new Proprietario { IdProprietario = 1, Nome = "Mario", Età = 35, IdPaese = 1 },
                new Proprietario { IdProprietario = 2, Nome = "Luigi", Età = 30, IdPaese = 1 },
                new Proprietario { IdProprietario = 3, Nome = "John", Età = 28, IdPaese = 2 },
                new Proprietario { IdProprietario = 4, Nome = "Drake", Età = 45, IdPaese = 2 }

            );

            // Seed data for Videogioco
            modelBuilder.Entity<Videogioco>().HasData(
                new Videogioco { IdVideogioco = 1, Nome = "Super Mario", DataDiRilascio = new DateOnly(1985, 9, 13) },
                new Videogioco { IdVideogioco = 2, Nome = "The Legend of Zelda", DataDiRilascio = new DateOnly(1986, 2, 21) },
                new Videogioco { IdVideogioco = 3, Nome = "Donkey Kong", DataDiRilascio = new DateOnly(1981, 7, 9) },
                new Videogioco { IdVideogioco = 4, Nome = "Uncharted 4: A thief's end", DataDiRilascio = new DateOnly(2016, 5, 3) }

            );

            // Seed data for VideogiocoProprietario
            modelBuilder.Entity<VideogiocoProprietario>().HasData(
                new VideogiocoProprietario { IdVideogiocoProprietario = 1, IdVideogioco = 1, IdProprietario = 1 },
                new VideogiocoProprietario { IdVideogiocoProprietario = 2, IdVideogioco = 2, IdProprietario = 2 },
                new VideogiocoProprietario { IdVideogiocoProprietario = 3, IdVideogioco = 3, IdProprietario = 3 },
                new VideogiocoProprietario { IdVideogiocoProprietario = 4, IdVideogioco = 1, IdProprietario = 4 },
                new VideogiocoProprietario { IdVideogiocoProprietario = 5, IdVideogioco = 4, IdProprietario = 1 }


            );
        }
    }
}
