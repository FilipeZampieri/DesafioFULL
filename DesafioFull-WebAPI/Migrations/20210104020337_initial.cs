using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioFull_WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dividas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<int>(nullable: false),
                    Devedor = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Juros = table.Column<decimal>(nullable: false),
                    Multa = table.Column<decimal>(nullable: false),
                    Plano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dividas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<int>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    DividaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelas_Dividas_DividaId",
                        column: x => x.DividaId,
                        principalTable: "Dividas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dividas",
                columns: new[] { "Id", "CPF", "Devedor", "Juros", "Multa", "Numero", "Plano" },
                values: new object[] { 1, "12345612348", "Antonio", 2m, 3m, 1234, 2 });

            migrationBuilder.InsertData(
                table: "Parcelas",
                columns: new[] { "Id", "DataVencimento", "DividaId", "Numero", "Valor" },
                values: new object[] { 1, new DateTime(2019, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 95.5m });

            migrationBuilder.InsertData(
                table: "Parcelas",
                columns: new[] { "Id", "DataVencimento", "DividaId", "Numero", "Valor" },
                values: new object[] { 2, new DateTime(2019, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 96m });

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_DividaId",
                table: "Parcelas",
                column: "DividaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcelas");

            migrationBuilder.DropTable(
                name: "Dividas");
        }
    }
}
