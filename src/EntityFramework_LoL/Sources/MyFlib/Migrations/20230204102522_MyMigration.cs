using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyFlib.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Bio = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Icon = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Class = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "Bio", "Class", "Icon", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "", 1, "", "", "Akali" },
                    { 2, "", 2, "", "", "Aatrox" },
                    { 3, "", 3, "", "", "Ahri" },
                    { 4, "", 4, "", "", "Akshan" },
                    { 5, "", 5, "", "", "Bard" },
                    { 6, "", 6, "", "", "Alistar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Champions");
        }
    }
}
