using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTraceTrawler.Migrations
{
    /// <inheritdoc />
    public partial class Index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockCodes_Barcode_BarcodesId",
                table: "StockCodes");

            migrationBuilder.DropIndex(
                name: "IX_StockCodes_BarcodesId",
                table: "StockCodes");

            migrationBuilder.DropColumn(
                name: "BarcodesId",
                table: "StockCodes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarcodesId",
                table: "StockCodes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockCodes_BarcodesId",
                table: "StockCodes",
                column: "BarcodesId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockCodes_Barcode_BarcodesId",
                table: "StockCodes",
                column: "BarcodesId",
                principalTable: "Barcode",
                principalColumn: "BarcodesId");
        }
    }
}
