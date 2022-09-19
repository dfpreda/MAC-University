using Microsoft.EntityFrameworkCore.Migrations;

namespace MAC.Data.Migrations
{
    public partial class ModifyOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassId_ClassGroup",
                table: "ClassGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupId_ClassGroup",
                table: "ClassGroups");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassId_ClassGroup",
                table: "ClassGroups",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupId_ClassGroup",
                table: "ClassGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassId_ClassGroup",
                table: "ClassGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupId_ClassGroup",
                table: "ClassGroups");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassId_ClassGroup",
                table: "ClassGroups",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupId_ClassGroup",
                table: "ClassGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
