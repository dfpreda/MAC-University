using Microsoft.EntityFrameworkCore.Migrations;

namespace MAC.Data.Migrations
{
    public partial class AddPKToClassGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ClassGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClassGroups");
        }
    }
}
