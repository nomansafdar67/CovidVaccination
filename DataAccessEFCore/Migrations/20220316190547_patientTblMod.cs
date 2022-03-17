using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEFCore.Migrations
{
    public partial class patientTblMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "vaccinations");

            migrationBuilder.AddColumn<short>(
                name: "Status",
                table: "patients",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "patients");

            migrationBuilder.AddColumn<short>(
                name: "Status",
                table: "vaccinations",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
