using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetType.Persistense.Database.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PetCategory");

            migrationBuilder.CreateTable(
                name: "PetCategories",
                schema: "PetCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "PetCategory",
                table: "PetCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, " PetCategory 0" },
                    { 2, " PetCategory 1" },
                    { 3, " PetCategory 2" },
                    { 4, " PetCategory 3" },
                    { 5, " PetCategory 4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetCategories",
                schema: "PetCategory");
        }
    }
}
