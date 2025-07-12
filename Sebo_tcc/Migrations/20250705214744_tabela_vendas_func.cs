using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sebo_tcc.Migrations
{
    /// <inheritdoc />
    public partial class tabela_vendas_func : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Books_IdBook",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_IdBook",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "BookName",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "IdBook",
                table: "Sales");

            migrationBuilder.CreateTable(
                name: "Order_Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    SaleModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Sales_Books_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Sales_Sales_SaleModelId",
                        column: x => x.SaleModelId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Sales_ItemId",
                table: "Order_Sales",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Sales_SaleModelId",
                table: "Order_Sales",
                column: "SaleModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Sales");

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdBook",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdBook",
                table: "Sales",
                column: "IdBook");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Books_IdBook",
                table: "Sales",
                column: "IdBook",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
