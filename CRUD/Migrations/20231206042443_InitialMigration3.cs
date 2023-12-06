using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD.Migrations
{
    public partial class InitialMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreDepartamento",
                table: "Provincia",
                newName: "NombreProvincia");

            migrationBuilder.RenameColumn(
                name: "NombreProvincia",
                table: "Distrito",
                newName: "NombreDistrito");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreProvincia",
                table: "Provincia",
                newName: "NombreDepartamento");

            migrationBuilder.RenameColumn(
                name: "NombreDistrito",
                table: "Distrito",
                newName: "NombreProvincia");
        }
    }
}
