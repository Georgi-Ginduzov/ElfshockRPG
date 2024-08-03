using Microsoft.EntityFrameworkCore;
using RPG.models;

namespace RPG
{
    public class GameContext : DbContext
    {
        public DbSet<HeroEntity> Heroes { get; set; }
        
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ElfshockRPGGameDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroEntity>().ToTable("Heroes");
        }
    }
}
