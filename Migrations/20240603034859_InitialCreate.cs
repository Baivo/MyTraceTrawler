using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WooliesScraper.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barcode",
                columns: table => new
                {
                    BarcodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcode", x => x.BarcodeId);
                });

            migrationBuilder.CreateTable(
                name: "StockCodes",
                columns: table => new
                {
                    VendorStockCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<int>(type: "int", nullable: false),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BarcodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCodes", x => x.VendorStockCodeId);
                    table.ForeignKey(
                        name: "FK_StockCodes_Barcode_BarcodeId",
                        column: x => x.BarcodeId,
                        principalTable: "Barcode",
                        principalColumn: "BarcodeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockCodes_BarcodeId",
                table: "StockCodes",
                column: "BarcodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockCodes");

            migrationBuilder.DropTable(
                name: "Barcode");
        }
    }
}
