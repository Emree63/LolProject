﻿using Microsoft.EntityFrameworkCore;
using MyFlib.Entities;
using MyFlib.Entities.enums;
using System.IO;
using System.Reflection;

namespace MyFlib
{
    public class LolDbContext : DbContext
    {
        public DbSet<LargeImageEntity> LargeImages { get; set; }
        public DbSet<ChampionEntity> Champions { get; set; }
        public DbSet<SkillEntity> Skills { get; set; }
        public DbSet<SkinEntity> Skins { get; set; }
        public DbSet<RuneEntity> Runes { get; set; }
        public DbSet<DictionaryCategoryRune> CategoryRunes { get; set; }
        public DbSet<RunePageEntity> RunePages { get; set; }
        public DbSet<CharacteristicEntity> Characteristic { get; set; }
        public LolDbContext()
        { }

        public LolDbContext(DbContextOptions<LolDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..\\..\\..\\..\\MyFlib\\DataBase.db");
                optionsBuilder.UseSqlite($"Data Source={path}");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //LargeImageEntity
            LargeImageEntity image1 = new LargeImageEntity { Id = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}"), Base64 = "UklGRtwDAABXRUJQVlA4INADAAAwEACdASoqACoAAMASJZgCdMoSCz655ndU4XXAP2yXIge5neM/Qd6WCfO8evoj2S0A/p7+f0An85cBxlLDgPC8jO/0nsl/13/O8vvzj7Af8s/p3/H4FU6td4MCwq23z1H2uzoKIXaqJniPI/bRMf8qzv0Zp+HE1RCBw5WQ1j/JovdM1FS52+QcaAAA/v/+NxU4DpPk3+xQPW7tcmURSo9vC4qc+XMxNVBzEM5E8actDz98gmwTXgD62e9EmG/ervdd2ovFFSuxYppWl/wtaX3rkn0xrt8qOql/5I2jfLOnCU0kALLcW4F/wTjU10qsxZXW9fxauC6OPVRF28sc94V9ocmoSWy+sf6jW3vYkVOh+gE/RE0L6b2d3oFyHmkRJnfYwG8o3p6fv9pivNF5aopIBzFnjzwb/VqSq3/b+MWKFmjr8T1qe4/fITo2vBWEqDyogV3ZVGnDVi2DbiEFVSUr2eXTNZQ9V/D9QC/+vCR5TGyX9QOVBgtAYtm/ZTIwzPEYB9NrV1NeO1/sAz78u0tW59r0I+SO5Jgm3B9i1toRurzHv9EZJ9yZL8nafb/T1FaoPDkuJfM+iPs0j8xnS7TaU/gEK0wCxeDYRYtJx9j4hUQq7pAu/T2yWy0vjcUHki952ZNbXnXxB8m8pV5x9E1sfLj5MZEgpU2XV8RHrVvWniCjsf6vgxmR7+KtwIbMjahitUGtHet1WdL+8MmdL29iQJC37pDXirir1NibxKKhFYRuJ3xW9O0r9+Vnh8diqbBuXqDbYR/MSoHvscOCm2t95dN5WBdRUoD7YCG/ZHWc7Ypv/x/al4fkB2lZlYhVWHxjaoeF9jEPI0gAN5XsvUI6hbzEzWMsNW/1orkNOnlskalgmpI4B2rm4Gc7LNui+MuMBrpnBvLkbYX9exe9g8tu7wLt7ScOjDcL99oOyR89Mh9L8rd4+43+JQyR6tsIfcPJo6T6FxHf11d/MGayJi+SWct/uhvvua0oOh+zXNIaUzgoBmu1XULjkpuA0Ghzctf30jbY1AOM49qbMZRYS9A+0S1HrHPnwRvpQY/Sj4xKPn0gdpv/+iTbKJb8zkPC4/9af0Jvesa+GDG0/iw3TswenMhqlh7BM9MW5txpeblsByx4WnJ/oHv6cc0dmM7tsV36lYkCTUXEf/0eKlnfivnN0g1g+j/Lk9et/uoa6TFCW0HgwFOIVFumEYdT675PfuTrYO5o8ZrWEIHtv2Ctlrv9J3TrslD/iKEwtipGHtn0Vak8B9wLL+kz+CIQ/VG4KJpXjx88CeCC4XaGitEdjAAA" };
            LargeImageEntity image2 = new LargeImageEntity { Id = Guid.Parse("{9f9086f5-5cc5-47b5-af9b-a935f4e9b89c}"), Base64 = "UklGRtwDAABXRUJQVlA4INADAAAwEACdASoqACoAAMASJZgCdMoSCz655ndU4XXAP2yXIge5neM/Qd6WCfO8evoj2S0A/p7+f0An85cBxlLDgPC8jO/0nsl/13/O8vvzj7Af8s/p3/H4FU6td4MCwq23z1H2uzoKIXaqJniPI/bRMf8qzv0Zp+HE1RCBw5WQ1j/JovdM1FS52+QcaAAA/v/+NxU4DpPk3+xQPW7tcmURSo9vC4qc+XMxNVBzEM5E8actDz98gmwTXgD62e9EmG/ervdd2ovFFSuxYppWl/wtaX3rkn0xrt8qOql/5I2jfLOnCU0kALLcW4F/wTjU10qsxZXW9fxauC6OPVRF28sc94V9ocmoSWy+sf6jW3vYkVOh+gE/RE0L6b2d3oFyHmkRJnfYwG8o3p6fv9pivNF5aopIBzFnjzwb/VqSq3/b+MWKFmjr8T1qe4/fITo2vBWEqDyogV3ZVGnDVi2DbiEFVSUr2eXTNZQ9V/D9QC/+vCR5TGyX9QOVBgtAYtm/ZTIwzPEYB9NrV1NeO1/sAz78u0tW59r0I+SO5Jgm3B9i1toRurzHv9EZJ9yZL8nafb/T1FaoPDkuJfM+iPs0j8xnS7TaU/gEK0wCxeDYRYtJx9j4hUQq7pAu/T2yWy0vjcUHki952ZNbXnXxB8m8pV5x9E1sfLj5MZEgpU2XV8RHrVvWniCjsf6vgxmR7+KtwIbMjahitUGtHet1WdL+8MmdL29iQJC37pDXirir1NibxKKhFYRuJ3xW9O0r9+Vnh8diqbBuXqDbYR/MSoHvscOCm2t95dN5WBdRUoD7YCG/ZHWc7Ypv/x/al4fkB2lZlYhVWHxjaoeF9jEPI0gAN5XsvUI6hbzEzWMsNW/1orkNOnlskalgmpI4B2rm4Gc7LNui+MuMBrpnBvLkbYX9exe9g8tu7wLt7ScOjDcL99oOyR89Mh9L8rd4+43+JQyR6tsIfcPJo6T6FxHf11d/MGayJi+SWct/uhvvua0oOh+zXNIaUzgoBmu1XULjkpuA0Ghzctf30jbY1AOM49qbMZRYS9A+0S1HrHPnwRvpQY/Sj4xKPn0gdpv/+iTbKJb8zkPC4/9af0Jvesa+GDG0/iw3TswenMhqlh7BM9MW5txpeblsByx4WnJ/oHv6cc0dmM7tsV36lYkCTUXEf/0eKlnfivnN0g1g+j/Lk9et/uoa6TFCW0HgwFOIVFumEYdT675PfuTrYO5o8ZrWEIHtv2Ctlrv9J3TrslD/iKEwtipGHtn0Vak8B9wLL+kz+CIQ/VG4KJpXjx88CeCC4XaGitEdjAAA" };

            modelBuilder.Entity<LargeImageEntity>().HasData(image1, image2);

            //ChampionEntity
            modelBuilder.Entity<ChampionEntity>().HasKey(e => e.Id);
            modelBuilder.Entity<ChampionEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ChampionEntity>().HasMany(champion => champion.RunePages).WithMany(runePage => runePage.Champions);

            ChampionEntity Akali = new ChampionEntity { Id = Guid.Parse("{4422C524-B2CB-43EF-8263-990C3CEA7CAE}"), Name = "Akali", Class = ChampionClassEntity.Assassin, Bio = "", Icon = "", ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
            ChampionEntity Aatrox = new ChampionEntity { Id = Guid.Parse("{A4F84D92-C20F-4F2D-B3F9-CA00EF556E72}"), Name = "Aatrox", Class = ChampionClassEntity.Fighter, Bio = "", Icon = "", ImageId = Guid.Parse("{9f9086f5-5cc5-47b5-af9b-a935f4e9b89c}") };
            ChampionEntity Ahri = new ChampionEntity { Id = Guid.Parse("{AE5FE535-F041-445E-B570-28B75BC78CB9}"), Name = "Ahri", Class = ChampionClassEntity.Mage, Bio = "", Icon = "", ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
            ChampionEntity Akshan = new ChampionEntity { Id = Guid.Parse("{3708dcfd-02a1-491e-b4f7-e75bf274cf23}"), Name = "Akshan", Class = ChampionClassEntity.Marksman, Bio = "", Icon = "", ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
            ChampionEntity Bard = new ChampionEntity { Id = Guid.Parse("{7f7746fa-b1cb-49da-9409-4b3e6910500e}"), Name = "Bard", Class = ChampionClassEntity.Support, Bio = "", Icon = "", ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
            ChampionEntity Alistar = new ChampionEntity { Id = Guid.Parse("{36ad2a82-d17b-47de-8a95-6e154a7df557}"), Name = "Alistar", Class = ChampionClassEntity.Tank, Bio = "", Icon = "", ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };


            modelBuilder.Entity<ChampionEntity>().HasData(Akali, Aatrox, Ahri, Akshan, Bard, Alistar);

            //SkillEntity
            modelBuilder.Entity<SkillEntity>()
                .HasOne(m => m.Champion)
                .WithMany(a => a.Skills)
                .HasForeignKey("ChampionForeignKey");

            modelBuilder.Entity<SkillEntity>().HasData(
                new { Name = "Boule de feu", Description = "Fire!", Type = SkillTypeEntity.Basic, ChampionForeignKey = Guid.Parse("{4422C524-B2CB-43EF-8263-990C3CEA7CAE}") },
                new { Name = "White Star", Description = "Random damage", Type = SkillTypeEntity.Ultimate, ChampionForeignKey = Guid.Parse("{3708dcfd-02a1-491e-b4f7-e75bf274cf23}") }
            );

            //SkinEntity
            modelBuilder.Entity<SkinEntity>()
                .HasOne(m => m.Champion)
                .WithMany(a => a.Skins)
                .HasForeignKey("ChampionForeignKey"); // not really useful because it is made in the Skin class

            modelBuilder.Entity<SkinEntity>().HasData(
                new SkinEntity { Name = "Akali Infernale", ChampionForeignKey = Guid.Parse("{4422C524-B2CB-43EF-8263-990C3CEA7CAE}"), Description = "Djinn qu'on invoque en dessous du monde, l'Infernale connue sous le nom d'Akali réduira en cendres les ennemis de son maître… mais le prix de son service est toujours exorbitant.", Icon = "empty", Price = 520, ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") },
                new SkinEntity { Name = "Akshan Cyberpop", ChampionForeignKey = Guid.Parse("{3708dcfd-02a1-491e-b4f7-e75bf274cf23}"), Description = "Les bas-fonds d'Audio City ont un nouveau héros : le Rebelle fluo. Cette position, Akshan la doit à son courage, sa sagesse et sa capacité à s'infiltrer dans des bâtiments d'affaires hautement sécurisés, et ce, sans être repéré. Son charme ravageur l'a aussi beaucoup aidé.", Icon = "empty", Price = 1350, ImageId = Guid.Parse("{9f9086f5-5cc5-47b5-af9b-a935f4e9b89c}") }
            );

            //RuneEntity
            RuneEntity runeHextech = new RuneEntity { Name = "Hextech Flashtraption ", Description = "While Flash is on cooldown, it is replaced by Hexflash.", Family = RuneFamilyEntity.Unknown, Icon = "", ImageId = Guid.Parse("{8d121cdc-6787-4738-8edd-9e026ac16b65}") };
            RuneEntity runeManaflow = new RuneEntity { Name = "Manaflow Band ", Description = "Hitting enemy champions with a spell grants 25 maximum mana, up to 250 mana.", Family = RuneFamilyEntity.Domination, Icon = "", ImageId = Guid.Parse("{9f9086f5-5cc5-47b5-af9b-a935f4e9b89c}") };
            modelBuilder.Entity<RuneEntity>().HasData(runeHextech, runeManaflow);

            //RunePageEntity
            RunePageEntity page1 = new RunePageEntity { Name = "Page 1" };
            RunePageEntity page2 = new RunePageEntity { Name = "Page 2" };

            modelBuilder.Entity<RunePageEntity>().HasData(page1, page2);

            //DictionaryCategoryRune
            modelBuilder.Entity<DictionaryCategoryRune>().HasKey(dictionary => new { dictionary.RunePageName, dictionary.RuneName });
            modelBuilder.Entity<DictionaryCategoryRune>().HasData(
                new DictionaryCategoryRune { category = CategoryEntity.Major, RuneName = runeHextech.Name, RunePageName = page1.Name },
                new DictionaryCategoryRune { category = CategoryEntity.Minor1, RuneName = runeManaflow.Name, RunePageName = page1.Name },
                new DictionaryCategoryRune { category = CategoryEntity.OtherMinor1, RuneName = runeManaflow.Name, RunePageName = page2.Name },
                new DictionaryCategoryRune { category = CategoryEntity.OtherMinor2, RuneName = runeHextech.Name, RunePageName = page2.Name }
            );

            //CharacteristicEntity
            modelBuilder.Entity<CharacteristicEntity>()
                .HasOne(m => m.Champion)
                .WithMany(a => a.Characteristics)
                .HasForeignKey("ChampionForeignKey");
            modelBuilder.Entity<CharacteristicEntity>().HasKey(c => new { c.Name, c.ChampionForeignKey });

            modelBuilder.Entity<CharacteristicEntity>().HasData(
                new CharacteristicEntity { Name = "Attack Damage", Value = 58, ChampionForeignKey = Ahri.Id },
                new CharacteristicEntity { Name = "Ability Power", Value = 92, ChampionForeignKey = Ahri.Id },
                new CharacteristicEntity { Name = "Attack Speed", Value = 6, ChampionForeignKey = Ahri.Id },
                new CharacteristicEntity { Name = "Health", Value = 526, ChampionForeignKey = Ahri.Id },
                new CharacteristicEntity { Name = "Mana", Value = 418, ChampionForeignKey = Ahri.Id },

                new CharacteristicEntity { Name = "Attack Damage", Value = 68, ChampionForeignKey = Akshan.Id },
                new CharacteristicEntity { Name = "Ability Power", Value = 0, ChampionForeignKey = Akshan.Id },
                new CharacteristicEntity { Name = "Attack Speed", Value = 1, ChampionForeignKey = Akshan.Id },
                new CharacteristicEntity { Name = "Health", Value = 570, ChampionForeignKey = Akshan.Id },
                new CharacteristicEntity { Name = "Mana", Value = 350, ChampionForeignKey = Akshan.Id },

                new CharacteristicEntity { Name = "Attack Damage", Value = 70, ChampionForeignKey = Aatrox.Id },
                new CharacteristicEntity { Name = "Ability Power", Value = 0, ChampionForeignKey = Aatrox.Id },
                new CharacteristicEntity { Name = "Attack Speed", Value = 1, ChampionForeignKey = Aatrox.Id },
                new CharacteristicEntity { Name = "Health", Value = 580, ChampionForeignKey = Aatrox.Id },
                new CharacteristicEntity { Name = "Mana", Value = 0, ChampionForeignKey = Aatrox.Id },

                new CharacteristicEntity { Name = "Attack Damage", Value = 56, ChampionForeignKey = Akali.Id },
                new CharacteristicEntity { Name = "Ability Power", Value = 0, ChampionForeignKey = Akali.Id },
                new CharacteristicEntity { Name = "Attack Speed", Value = 1, ChampionForeignKey = Akali.Id },
                new CharacteristicEntity { Name = "Health", Value = 575, ChampionForeignKey = Akali.Id },
                new CharacteristicEntity { Name = "Mana", Value = 200, ChampionForeignKey = Akali.Id },

                new CharacteristicEntity { Name = "Attack Damage", Value = 63, ChampionForeignKey = Alistar.Id },
                new CharacteristicEntity { Name = "Ability Power", Value = 0, ChampionForeignKey = Alistar.Id },
                new CharacteristicEntity { Name = "Attack Speed", Value = 2, ChampionForeignKey = Alistar.Id },
                new CharacteristicEntity { Name = "Health", Value = 573, ChampionForeignKey = Alistar.Id },
                new CharacteristicEntity { Name = "Mana", Value = 278, ChampionForeignKey = Alistar.Id },

                new CharacteristicEntity { Name = "Ability Power", Value = 30, ChampionForeignKey = Bard.Id },
                new CharacteristicEntity { Name = "Attack Speed", Value = 1, ChampionForeignKey = Bard.Id },
                new CharacteristicEntity { Name = "Health", Value = 535, ChampionForeignKey = Bard.Id },
                new CharacteristicEntity { Name = "Mana", Value = 350, ChampionForeignKey = Bard.Id }
            );

        }

    }
}
