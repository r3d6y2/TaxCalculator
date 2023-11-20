using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxCalculator.DataAccess.SqlDb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxBands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    LowRange = table.Column<int>(type: "int", nullable: false),
                    HighRange = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBands", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "HighRange", "IsActive", "LowRange", "Name", "Range" },
                values: new object[,]
                {
                    { 1, 5000, true, 0, "Tax Band A", 0 },
                    { 2, 20000, true, 5000, "Tax Band B", 20 },
                    { 3, 2147483647, true, 20000, "Tax Band C", 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxBands");
        }
    }
}
