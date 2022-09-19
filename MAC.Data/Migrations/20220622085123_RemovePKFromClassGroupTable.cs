using Microsoft.EntityFrameworkCore.Migrations;

namespace MAC.Data.Migrations
{
    public partial class RemovePKFromClassGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClassGroups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ClassGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
