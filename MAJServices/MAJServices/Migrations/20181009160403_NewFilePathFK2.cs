using Microsoft.EntityFrameworkCore.Migrations;

namespace MAJServices.Migrations
{
    public partial class NewFilePathFK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "FilePaths",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "FilePaths",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdPost",
                table: "FilePaths",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "FilePaths");

            migrationBuilder.DropColumn(
                name: "IdPost",
                table: "FilePaths");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "FilePaths",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
