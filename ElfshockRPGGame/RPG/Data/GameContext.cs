using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RPG.Data.models;

namespace RPG.Data
{
    public class GameContext : DbContext
    {
        public DbSet<HeroEntity> Heroes { get; set; }

        public GameContext()
        {

        }

        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroEntity>().ToTable("Heroes");
        }
    }
}
