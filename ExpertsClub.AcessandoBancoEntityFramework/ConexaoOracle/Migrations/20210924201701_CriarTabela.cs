using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConexaoOracle.Migrations
{
    public partial class CriarTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "Valor" },
                values: new object[,]
                {
                    { new Guid("aee5b12c-c6bd-4c2e-92e7-32a1eff004d2"), "Caneta Bic", 1m },
                    { new Guid("64329454-2845-4b5e-b3e1-bf97a663f08c"), "Caneta Azul", 1.39m },
                    { new Guid("51189550-5e5a-4d09-8531-1aa32610e3f3"), "Caneta Vermelha", 1.40m },
                    { new Guid("23fcf005-a96c-4ad8-881f-e6f3b2a46290"), "Caneta Preta", 1.41m },
                    { new Guid("5e49dc28-26ff-4d5f-8da1-5cce451e79b6"), "Lápis", 0.37m },
                    { new Guid("d166b9b4-54e3-4452-9799-d8f59ac76ce0"), "Borracha", 0.74m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
