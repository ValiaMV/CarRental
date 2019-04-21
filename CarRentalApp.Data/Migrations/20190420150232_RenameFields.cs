using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalApp.Data.Migrations
{
    public partial class RenameFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Cars",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "SecondName");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Cars",
                newName: "Class");
        }
    }
}
