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
        public DbSet<RuneEntity> Runes { get; set; }
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
            //LargeImageEntity
            LargeImageEntity image1 = new LargeImageEntity { Id = 1, Base64 = "empty" };
            LargeImageEntity image2 = new LargeImageEntity { Id = 2, Base64 = " " };

            modelBuilder.Entity<LargeImageEntity>().HasData(image1, image2);

            //ChampionEntity
            modelBuilder.Entity<ChampionEntity>().HasKey(e => e.Id);

            modelBuilder.Entity<ChampionEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
            ChampionEntity Akali = new ChampionEntity { Id = Guid.Parse("{4422C524-B2CB-43EF-8263-990C3CEA7CAE}"), Name = "Akali", Class = ChampionClassEntity.Assassin, Bio = "", Icon = "", ImageId = 1 };
            ChampionEntity Aatrox = new ChampionEntity { Id = Guid.Parse("{A4F84D92-C20F-4F2D-B3F9-CA00EF556E72}"), Name = "Aatrox", Class = ChampionClassEntity.Fighter, Bio = "", Icon = "", ImageId = 2 };
            ChampionEntity Ahri = new ChampionEntity { Id = Guid.Parse("{AE5FE535-F041-445E-B570-28B75BC78CB9}"), Name = "Ahri", Class = ChampionClassEntity.Mage, Bio = "", Icon = "", ImageId = 1 };
            ChampionEntity Akshan = new ChampionEntity { Id = Guid.Parse("{3708dcfd-02a1-491e-b4f7-e75bf274cf23}"), Name = "Akshan", Class = ChampionClassEntity.Marksman, Bio = "", Icon = "", ImageId = 1 };
            ChampionEntity Bard = new ChampionEntity { Id = Guid.Parse("{7f7746fa-b1cb-49da-9409-4b3e6910500e}"), Name = "Bard", Class = ChampionClassEntity.Support, Bio = "", Icon = "", ImageId = 1 };
            ChampionEntity Alistar = new ChampionEntity { Id = Guid.Parse("{36ad2a82-d17b-47de-8a95-6e154a7df557}"), Name = "Alistar", Class = ChampionClassEntity.Tank, Bio = "", Icon = "", ImageId = 1 };


            modelBuilder.Entity<ChampionEntity>().HasData(Akali, Aatrox, Ahri, Akshan, Bard, Alistar);

            //SkillEntity
            modelBuilder.Entity<SkillEntity>().HasData(
                new { Name = "Boule de feu", Description = "Fire!", Type = SkillTypeEntity.Basic },
                new { Name = "White Star", Description = "Random damage", Type = SkillTypeEntity.Ultimate }
            );

            //SkinEntity
            modelBuilder.Entity<SkinEntity>().HasData(
                new SkinEntity { Name = "Akali Infernale", ChampionForeignKey = Guid.Parse("{4422C524-B2CB-43EF-8263-990C3CEA7CAE}"), Description = "Djinn qu'on invoque en dessous du monde, l'Infernale connue sous le nom d'Akali réduira en cendres les ennemis de son maître… mais le prix de son service est toujours exorbitant.", Icon = "empty", Price = 520, ImageId = 1 },
                new SkinEntity { Name = "Akshan Cyberpop", ChampionForeignKey = Guid.Parse("{3708dcfd-02a1-491e-b4f7-e75bf274cf23}"), Description = "Les bas-fonds d'Audio City ont un nouveau héros : le Rebelle fluo. Cette position, Akshan la doit à son courage, sa sagesse et sa capacité à s'infiltrer dans des bâtiments d'affaires hautement sécurisés, et ce, sans être repéré. Son charme ravageur l'a aussi beaucoup aidé.", Icon = "empty", Price = 1350, ImageId = 2 }
            );

            //RuneEntity
            modelBuilder.Entity<RuneEntity>().HasData(
                new RuneEntity { Name = "Hextech Flashtraption ", Description = "While Flash is on cooldown, it is replaced by Hexflash.", SkillType = SkillTypeEntity.Passive, ImageId = 1 },
                new RuneEntity { Name = "Manaflow Band ", Description = "Hitting enemy champions with a spell grants 25 maximum mana, up to 250 mana.", SkillType = SkillTypeEntity.Basic, ImageId = 2 }            
            );

        }

    }
}
