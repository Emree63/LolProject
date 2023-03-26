using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyFlib.Migrations
{
    /// <inheritdoc />
    public partial class myMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LargeImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Base64 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LargeImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunePages",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunePages", x => x.Name);
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
                    ImageId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Champions_LargeImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "LargeImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Runes",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Family = table.Column<int>(type: "INTEGER", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    ImageId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runes", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Runes_LargeImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "LargeImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChampionEntityRunePageEntity",
                columns: table => new
                {
                    ChampionsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RunePagesName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionEntityRunePageEntity", x => new { x.ChampionsId, x.RunePagesName });
                    table.ForeignKey(
                        name: "FK_ChampionEntityRunePageEntity_Champions_ChampionsId",
                        column: x => x.ChampionsId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChampionEntityRunePageEntity_RunePages_RunePagesName",
                        column: x => x.RunePagesName,
                        principalTable: "RunePages",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characteristic",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    ChampionForeignKey = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristic", x => new { x.Name, x.ChampionForeignKey });
                    table.ForeignKey(
                        name: "FK_Characteristic_Champions_ChampionForeignKey",
                        column: x => x.ChampionForeignKey,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    ChampionForeignKey = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Skills_Champions_ChampionForeignKey",
                        column: x => x.ChampionForeignKey,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skins",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    ChampionForeignKey = table.Column<Guid>(type: "TEXT", nullable: false),
                    ImageId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                        name: "FK_Skins_LargeImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "LargeImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryRunes",
                columns: table => new
                {
                    RunePageName = table.Column<string>(type: "TEXT", nullable: false),
                    RuneName = table.Column<string>(type: "TEXT", nullable: false),
                    category = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRunes", x => new { x.RunePageName, x.RuneName });
                    table.ForeignKey(
                        name: "FK_CategoryRunes_RunePages_RunePageName",
                        column: x => x.RunePageName,
                        principalTable: "RunePages",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryRunes_Runes_RuneName",
                        column: x => x.RuneName,
                        principalTable: "Runes",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LargeImages",
                columns: new[] { "Id", "Base64" },
                values: new object[,]
                {
                    { new Guid("8d121cdc-6787-4738-8edd-9e026ac16b65"), "empty" },
                    { new Guid("9f9086f5-5cc5-47b5-af9b-a935f4e9b89c"), " " }
                });

            migrationBuilder.InsertData(
                table: "RunePages",
                column: "Name",
                values: new object[]
                {
                    "Page 1",
                    "Page 2"
                });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "Bio", "Class", "Icon", "ImageId", "Name" },
                values: new object[,]
                {
                    { new Guid("36ad2a82-d17b-47de-8a95-6e154a7df557"), "", 6, "", new Guid("8d121cdc-6787-4738-8edd-9e026ac16b65"), "Alistar" },
                    { new Guid("3708dcfd-02a1-491e-b4f7-e75bf274cf23"), "", 4, "", new Guid("8d121cdc-6787-4738-8edd-9e026ac16b65"), "Akshan" },
                    { new Guid("4422c524-b2cb-43ef-8263-990c3cea7cae"), "", 1, "", new Guid("8d121cdc-6787-4738-8edd-9e026ac16b65"), "Akali" },
                    { new Guid("7f7746fa-b1cb-49da-9409-4b3e6910500e"), "", 5, "", new Guid("8d121cdc-6787-4738-8edd-9e026ac16b65"), "Bard" },
                    { new Guid("a4f84d92-c20f-4f2d-b3f9-ca00ef556e72"), "", 2, "", new Guid("9f9086f5-5cc5-47b5-af9b-a935f4e9b89c"), "Aatrox" },
                    { new Guid("ae5fe535-f041-445e-b570-28b75bc78cb9"), "", 3, "", new Guid("8d121cdc-6787-4738-8edd-9e026ac16b65"), "Ahri" }
                });

            migrationBuilder.InsertData(
                table: "Runes",
                columns: new[] { "Name", "Description", "Family", "Icon", "ImageId" },
                values: new object[,]
                {
                    { "Hextech Flashtraption ", "While Flash is on cooldown, it is replaced by Hexflash.", 0, "", new Guid("8d121cdc-6787-4738-8edd-9e026ac16b65") },
                    { "Manaflow Band ", "Hitting enemy champions with a spell grants 25 maximum mana, up to 250 mana.", 2, "", new Guid("9f9086f5-5cc5-47b5-af9b-a935f4e9b89c") }
                });

            migrationBuilder.InsertData(
                table: "CategoryRunes",
                columns: new[] { "RuneName", "RunePageName", "category" },
                values: new object[,]
                {
                    { "Hextech Flashtraption ", "Page 1", 0 },
                    { "Manaflow Band ", "Page 1", 1 },
                    { "Hextech Flashtraption ", "Page 2", 5 },
                    { "Manaflow Band ", "Page 2", 4 }
                });

            migrationBuilder.InsertData(
                table: "Characteristic",
                columns: new[] { "ChampionForeignKey", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("36ad2a82-d17b-47de-8a95-6e154a7df557"), "Ability Power", 0 },
                    { new Guid("3708dcfd-02a1-491e-b4f7-e75bf274cf23"), "Ability Power", 0 },
                    { new Guid("4422c524-b2cb-43ef-8263-990c3cea7cae"), "Ability Power", 0 },
                    { new Guid("7f7746fa-b1cb-49da-9409-4b3e6910500e"), "Ability Power", 30 },
                    { new Guid("a4f84d92-c20f-4f2d-b3f9-ca00ef556e72"), "Ability Power", 0 },
                    { new Guid("ae5fe535-f041-445e-b570-28b75bc78cb9"), "Ability Power", 92 },
                    { new Guid("36ad2a82-d17b-47de-8a95-6e154a7df557"), "Attack Damage", 63 },
                    { new Guid("3708dcfd-02a1-491e-b4f7-e75bf274cf23"), "Attack Damage", 68 },
                    { new Guid("4422c524-b2cb-43ef-8263-990c3cea7cae"), "Attack Damage", 56 },
                    { new Guid("a4f84d92-c20f-4f2d-b3f9-ca00ef556e72"), "Attack Damage", 70 },
                    { new Guid("ae5fe535-f041-445e-b570-28b75bc78cb9"), "Attack Damage", 58 },
                    { new Guid("36ad2a82-d17b-47de-8a95-6e154a7df557"), "Attack Speed", 2 },
                    { new Guid("3708dcfd-02a1-491e-b4f7-e75bf274cf23"), "Attack Speed", 1 },
                    { new Guid("4422c524-b2cb-43ef-8263-990c3cea7cae"), "Attack Speed", 1 },
                    { new Guid("7f7746fa-b1cb-49da-9409-4b3e6910500e"), "Attack Speed", 1 },
                    { new Guid("a4f84d92-c20f-4f2d-b3f9-ca00ef556e72"), "Attack Speed", 1 },
                    { new Guid("ae5fe535-f041-445e-b570-28b75bc78cb9"), "Attack Speed", 6 },
                    { new Guid("36ad2a82-d17b-47de-8a95-6e154a7df557"), "Health", 573 },
                    { new Guid("3708dcfd-02a1-491e-b4f7-e75bf274cf23"), "Health", 570 },
                    { new Guid("4422c524-b2cb-43ef-8263-990c3cea7cae"), "Health", 575 },
                    { new Guid("7f7746fa-b1cb-49da-9409-4b3e6910500e"), "Health", 535 },
                    { new Guid("a4f84d92-c20f-4f2d-b3f9-ca00ef556e72"), "Health", 580 },
                    { new Guid("ae5fe535-f041-445e-b570-28b75bc78cb9"), "Health", 526 },
                    { new Guid("36ad2a82-d17b-47de-8a95-6e154a7df557"), "Mana", 278 },
                    { new Guid("3708dcfd-02a1-491e-b4f7-e75bf274cf23"), "Mana", 350 },
                    { new Guid("4422c524-b2cb-43ef-8263-990c3cea7cae"), "Mana", 200 },
                    { new Guid("7f7746fa-b1cb-49da-9409-4b3e6910500e"), "Mana", 350 },
                    { new Guid("a4f84d92-c20f-4f2d-b3f9-ca00ef556e72"), "Mana", 0 },
                    { new Guid("ae5fe535-f041-445e-b570-28b75bc78cb9"), "Mana", 418 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Name", "ChampionForeignKey", "Description", "Type" },
                values: new object[,]
                {
                    { "Boule de feu", new Guid("4422c524-b2cb-43ef-8263-990c3cea7cae"), "Fire!", 1 },
                    { "White Star", new Guid("3708dcfd-02a1-491e-b4f7-e75bf274cf23"), "Random damage", 3 }
                });

            migrationBuilder.InsertData(
                table: "Skins",
                columns: new[] { "Name", "ChampionForeignKey", "Description", "Icon", "ImageId", "Price" },
                values: new object[,]
                {
                    { "Akali Infernale", new Guid("4422c524-b2cb-43ef-8263-990c3cea7cae"), "Djinn qu'on invoque en dessous du monde, l'Infernale connue sous le nom d'Akali réduira en cendres les ennemis de son maître… mais le prix de son service est toujours exorbitant.", "empty", new Guid("8d121cdc-6787-4738-8edd-9e026ac16b65"), 520f },
                    { "Akshan Cyberpop", new Guid("3708dcfd-02a1-491e-b4f7-e75bf274cf23"), "Les bas-fonds d'Audio City ont un nouveau héros : le Rebelle fluo. Cette position, Akshan la doit à son courage, sa sagesse et sa capacité à s'infiltrer dans des bâtiments d'affaires hautement sécurisés, et ce, sans être repéré. Son charme ravageur l'a aussi beaucoup aidé.", "empty", new Guid("9f9086f5-5cc5-47b5-af9b-a935f4e9b89c"), 1350f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRunes_RuneName",
                table: "CategoryRunes",
                column: "RuneName");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionEntityRunePageEntity_RunePagesName",
                table: "ChampionEntityRunePageEntity",
                column: "RunePagesName");

            migrationBuilder.CreateIndex(
                name: "IX_Champions_ImageId",
                table: "Champions",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Characteristic_ChampionForeignKey",
                table: "Characteristic",
                column: "ChampionForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Runes_ImageId",
                table: "Runes",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ChampionForeignKey",
                table: "Skills",
                column: "ChampionForeignKey");

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
                name: "CategoryRunes");

            migrationBuilder.DropTable(
                name: "ChampionEntityRunePageEntity");

            migrationBuilder.DropTable(
                name: "Characteristic");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Skins");

            migrationBuilder.DropTable(
                name: "Runes");

            migrationBuilder.DropTable(
                name: "RunePages");

            migrationBuilder.DropTable(
                name: "Champions");

            migrationBuilder.DropTable(
                name: "LargeImages");
        }
    }
}
