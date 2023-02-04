using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFlib
{
    public class LolDbContext : DbContext
    {
        public DbSet<ChampionEntity> Champions { get; set; }
        public LolDbContext()
        { }

        public LolDbContext(DbContextOptions<LolDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=DataBase.db");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChampionEntity>().HasKey(e => e.Id);
            modelBuilder.Entity<ChampionEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ChampionEntity>().HasData(
                new ChampionEntity { Id = 1, Name = "Akali", Class = ChampionClassEntity.Assassin, Bio = "", Icon = "", Image = "" },
                new ChampionEntity { Id = 2, Name = "Aatrox", Class = ChampionClassEntity.Fighter, Bio = "", Icon = "", Image = "" },
                new ChampionEntity { Id = 3, Name = "Ahri", Class = ChampionClassEntity.Mage, Bio = "", Icon = "", Image = "" },
                new ChampionEntity { Id = 4, Name = "Akshan", Class = ChampionClassEntity.Marksman, Bio = "", Icon = "", Image = "" },
                new ChampionEntity { Id = 5, Name = "Bard", Class = ChampionClassEntity.Support, Bio = "", Icon = "", Image = "" },
                new ChampionEntity { Id = 6, Name = "Alistar", Class = ChampionClassEntity.Tank, Bio = "", Icon = "", Image = "" }
            );

        }

    }
}
