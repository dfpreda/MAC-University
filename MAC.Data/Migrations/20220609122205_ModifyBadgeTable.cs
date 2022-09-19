using Microsoft.EntityFrameworkCore.Migrations;

namespace MAC.Data.Migrations
{
    public partial class ModifyBadgeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentAddress",
                table: "Badges");

            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Badges",
                newName: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Badges",
                newName: "StudentName");

            migrationBuilder.AddColumn<string>(
                name: "StudentAddress",
                table: "Badges",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
