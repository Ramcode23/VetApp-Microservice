using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceType.Persistese.Database.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ServiceCategories");

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                schema: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "ServiceCategories",
                table: "ServiceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, " Service 1" },
                    { 2, " Service 2" },
                    { 3, " Service 3" },
                    { 4, " Service 4" },
                    { 5, " Service 5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceCategories",
                schema: "ServiceCategories");
        }
    }
}
