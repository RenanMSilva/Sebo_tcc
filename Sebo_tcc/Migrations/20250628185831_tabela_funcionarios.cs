using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sebo_tcc.Migrations
{
    /// <inheritdoc />
    public partial class tabela_funcionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEmployee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPFCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataHiring = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailEmployee = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
