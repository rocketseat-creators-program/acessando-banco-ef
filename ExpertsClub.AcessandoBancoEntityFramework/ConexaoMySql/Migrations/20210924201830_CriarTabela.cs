using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConexaoMySql.Migrations
{
    public partial class CriarTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Nome", "Valor" },
                values: new object[,]
                {
                    { new Guid("41afaa64-ad63-45bd-a336-e555e90ef217"), "Caneta Bic", 1m },
                    { new Guid("cdac4b98-6c6e-4fcf-b849-b9a191eb5f2f"), "Caneta Azul", 1.39m },
                    { new Guid("6bd213de-4805-4f39-9213-0eefb04631e4"), "Caneta Vermelha", 1.40m },
                    { new Guid("52e8f5c6-be1f-455b-b7ca-be70fd1f82ca"), "Caneta Preta", 1.41m },
                    { new Guid("c8a03f4d-4fad-4326-832c-7ecd24da321d"), "Lápis", 0.37m },
                    { new Guid("34d0100c-ce64-44c2-bbd9-e1bde0ba8264"), "Borracha", 0.74m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
