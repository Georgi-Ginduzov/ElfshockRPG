using Microsoft.EntityFrameworkCore;
using RPG.models;

namespace RPG
{
    public class GameContext : DbContext
    {
        public DbSet<HeroEntity> Heroes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ElfshockRPGGameDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroEntity>().ToTable("Heroes");
        }
    }
}
