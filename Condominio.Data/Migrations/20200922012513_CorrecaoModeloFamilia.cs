using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoCondominio.Data.Migrations
{
    public partial class CorrecaoModeloFamilia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Familia",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Familia");
        }
    }
}
