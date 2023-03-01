using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyFlib.Migrations
{
    /// <inheritdoc />
    public partial class monNomDeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LargeImageEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Base64 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LargeImageEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Bio = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    Class = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Champions_LargeImageEntity_ImageId",
                        column: x => x.ImageId,
                        principalTable: "LargeImageEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    ChampionEntityId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Skills_Champions_ChampionEntityId",
                        column: x => x.ChampionEntityId,
                        principalTable: "Champions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Skins",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    ChampionForeignKey = table.Column<Guid>(type: "TEXT", nullable: false),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skins", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Skins_Champions_ChampionForeignKey",
                        column: x => x.ChampionForeignKey,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skins_LargeImageEntity_ImageId",
                        column: x => x.ImageId,
                        principalTable: "LargeImageEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LargeImageEntity",
                columns: new[] { "Id", "Base64" },
                values: new object[,]
                {
                    { 1, "empty" },
                    { 2, " " }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Name", "ChampionEntityId", "Description", "Type" },
                values: new object[,]
                {
                    { "Boule de feu", null, "Fire!", 1 },
                    { "White Star", null, "Random damage", 3 }
                });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "Bio", "Class", "Icon", "ImageId", "Name" },
                values: new object[,]
                {
                    { new Guid("36ad2a82-d17b-47de-8a95-6e154a7df557"), "", 6, "", 1, "Alistar" },
                    { new Guid("3708dcfd-02a1-491e-b4f7-e75bf274cf23"), "", 4, "", 1, "Akshan" },
                    { new Guid("4422c524-b2cb-43ef-8263-990c3cea7cae"), "", 1, "", 1, "Akali" },
                    { new Guid("7f7746fa-b1cb-49da-9409-4b3e6910500e"), "", 5, "", 1, "Bard" },
                    { new Guid("a4f84d92-c20f-4f2d-b3f9-ca00ef556e72"), "", 2, "", 2, "Aatrox" },
                    { new Guid("ae5fe535-f041-445e-b570-28b75bc78cb9"), "", 3, "", 1, "Ahri" }
                });

            migrationBuilder.InsertData(
                table: "Skins",
                columns: new[] { "Name", "ChampionForeignKey", "Description", "Icon", "ImageId", "Price" },
                values: new object[,]
                {
                    { "Akali Infernale", new Guid("4422c524-b2cb-43ef-8263-990c3cea7cae"), "Djinn qu'on invoque en dessous du monde, l'Infernale connue sous le nom d'Akali réduira en cendres les ennemis de son maître… mais le prix de son service est toujours exorbitant.", "empty", 1, 520f },
                    { "Akshan Cyberpop", new Guid("3708dcfd-02a1-491e-b4f7-e75bf274cf23"), "Les bas-fonds d'Audio City ont un nouveau héros : le Rebelle fluo. Cette position, Akshan la doit à son courage, sa sagesse et sa capacité à s'infiltrer dans des bâtiments d'affaires hautement sécurisés, et ce, sans être repéré. Son charme ravageur l'a aussi beaucoup aidé.", "empty", 2, 1350f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Champions_ImageId",
                table: "Champions",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ChampionEntityId",
                table: "Skills",
                column: "ChampionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Skins_ChampionForeignKey",
                table: "Skins",
                column: "ChampionForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Skins_ImageId",
                table: "Skins",
                column: "ImageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Skins");

            migrationBuilder.DropTable(
                name: "Champions");

            migrationBuilder.DropTable(
                name: "LargeImageEntity");
        }
    }
}
