using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace envelweb.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dados",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoria = table.Column<string>(nullable: true),
                    data = table.Column<DateTime>(nullable: false),
                    pagrec = table.Column<string>(nullable: true),
                    banco = table.Column<string>(nullable: true),
                    valor = table.Column<decimal>(nullable: false),
                    juros = table.Column<decimal>(nullable: false),
                    desconto = table.Column<decimal>(nullable: false),
                    nota = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dados", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dados");
        }
    }
}
