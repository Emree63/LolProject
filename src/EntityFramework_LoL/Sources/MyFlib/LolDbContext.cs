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
        public DbSet<SkillEntity> Skills { get; set; }
        public DbSet<SkinEntity> Skins { get; set; }
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
            var image1 = new LargeImageEntity { ImageId = 1, Base64 = "image1" };
            var image2 = new LargeImageEntity { ImageId = 2, Base64 = "image2" };

            modelBuilder.Entity<LargeImageEntity>().HasData(image1, image2);

            modelBuilder.Entity<SkinEntity>().Property<int>("ImageId");

            modelBuilder.Entity<ChampionEntity>().HasKey(e => e.Id);
            modelBuilder.Entity<ChampionEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ChampionEntity>().HasData(
                new { Id = Guid.Parse("{4422C524-B2CB-43EF-8263-990C3CEA7CAE}"), Name = "Akali", Class = ChampionClassEntity.Assassin, Bio = "", Icon = "", Image = "empty" },
                new { Id = Guid.Parse("{A4F84D92-C20F-4F2D-B3F9-CA00EF556E72}"), Name = "Aatrox", Class = ChampionClassEntity.Fighter, Bio = "", Icon = "", Image = "empty" },
                new { Id = Guid.Parse("{AE5FE535-F041-445E-B570-28B75BC78CB9}"), Name = "Ahri", Class = ChampionClassEntity.Mage, Bio = "", Icon = "", Image = "empty" },
                new { Id = Guid.Parse("{3708dcfd-02a1-491e-b4f7-e75bf274cf23}"), Name = "Akshan", Class = ChampionClassEntity.Marksman, Bio = "", Icon = "", Image = "empty" },
                new { Id = Guid.Parse("{7f7746fa-b1cb-49da-9409-4b3e6910500e}"), Name = "Bard", Class = ChampionClassEntity.Support, Bio = "", Icon = "", Image = "empty" },
                new { Id = Guid.Parse("{36ad2a82-d17b-47de-8a95-6e154a7df557}"), Name = "Alistar", Class = ChampionClassEntity.Tank, Bio = "", Icon = "", Image = "empty" }
            );

            modelBuilder.Entity<SkillEntity>().HasData(
                new { Name = "Boule de feu", Description = "Fire!", Type = SkillTypeEntity.Basic },
                new { Name = "White Star", Description = "Random damage", Type = SkillTypeEntity.Ultimate }
            );

            modelBuilder.Entity<SkinEntity>().HasData(
                new SkinEntity { Name = "Yone fleur spirituelle", Description = "Spirit Blossom", Icon = "empty", Price = 975, ImageId = 1 },
                new SkinEntity { Name = "Yasuo Lune de sang", Description = "Blood Moon", Icon = "empty", Price = 975, ImageId = 2 }
            );

        }

    }
}
