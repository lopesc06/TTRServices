using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAJServices.Migrations
{
    public partial class ReleaseDatetimeAndTextLenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "02d74195-e38d-4ce8-acb5-e20577af0499", "4896ff55-2cac-4343-9740-7854fa08d413" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3013d880-2150-4efd-b7d0-3131d1cad731", "be9444e2-c319-4a90-a910-8eafafa0bbaa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "676778a7-c8eb-4ebc-aca5-56d9f2d2d350", "457b5047-e9a9-4fd4-b3d6-e974e9307115" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9cd5c1c1-a237-4bbe-905c-d86c3ec9cfff", "1cf6ca6a-9281-4971-9ae9-b13630dbda92" });

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Posts",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5148956a-dea4-4a80-9e97-3a1593a50490", "42e584f8-dfc2-4892-a76f-9b2a206bae8c", "SuperAdmin", "SUPERADMIN" },
                    { "293431a3-d2ed-4769-9130-2b9d4b867870", "1fdcd961-20ae-45b9-8888-ac82fc866a78", "Admin", "ADMIN" },
                    { "2a41358d-45a0-4ab3-a7bb-269dc9da891d", "dcec9474-008a-4b56-b198-dd82b12fb51e", "Subadmin", "SUBADMIN" },
                    { "5902392a-ed35-448b-8b25-b0d68d4f0e41", "adb42b3e-3e9f-4f79-9eda-be71c32bebb2", "General", "GENERAL" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014193056",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "da10a386-b69c-421c-ac49-e1c2223030e9", "2ac1a471-d4f1-4c7a-a9b4-477e11258c65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014378223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9206fadf-8cf9-49ad-bc68-50db46ed371b", "ed23364b-29d5-4429-9805-92f516839baa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014630132",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cec2df94-6cf8-4d9e-83cd-ca2996fbb277", "6b8b1477-1683-4e72-8867-ef6de1bcbeed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014631903",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9e77bacb-cba7-4de3-b3b2-27a3993e4672", "1587ce14-2283-4475-ad0f-af9ea6846395" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentAcronym", "DepartmentImageUrl", "HexColor", "Name" },
                values: new object[] { "SUPERADMIN", null, null, "SUPERADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "293431a3-d2ed-4769-9130-2b9d4b867870", "1fdcd961-20ae-45b9-8888-ac82fc866a78" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2a41358d-45a0-4ab3-a7bb-269dc9da891d", "dcec9474-008a-4b56-b198-dd82b12fb51e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "5148956a-dea4-4a80-9e97-3a1593a50490", "42e584f8-dfc2-4892-a76f-9b2a206bae8c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "5902392a-ed35-448b-8b25-b0d68d4f0e41", "adb42b3e-3e9f-4f79-9eda-be71c32bebb2" });

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentAcronym",
                keyValue: "SUPERADMIN");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Posts",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Posts",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2000);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3013d880-2150-4efd-b7d0-3131d1cad731", "be9444e2-c319-4a90-a910-8eafafa0bbaa", "SuperAdmin", "SUPERADMIN" },
                    { "676778a7-c8eb-4ebc-aca5-56d9f2d2d350", "457b5047-e9a9-4fd4-b3d6-e974e9307115", "Admin", "ADMIN" },
                    { "9cd5c1c1-a237-4bbe-905c-d86c3ec9cfff", "1cf6ca6a-9281-4971-9ae9-b13630dbda92", "Subadmin", "SUBADMIN" },
                    { "02d74195-e38d-4ce8-acb5-e20577af0499", "4896ff55-2cac-4343-9740-7854fa08d413", "General", "GENERAL" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014193056",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "166881bc-f0a4-461e-a86b-13d3ac45ca9a", "77bbb5e4-fe64-401e-808d-6639091e0547" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014378223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3932ad86-94fd-49ea-9373-a43e3792faaa", "af07da05-7c00-4ccc-aae1-9a77cea78795" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014630132",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "57de4908-2d7e-4bf4-9906-ce9810e400c3", "b651b24d-c769-4a45-9988-d8b1e150a6c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014631903",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7390ecb1-056b-4eab-94aa-bb6aa2e38fef", "29be639c-a64c-4075-aa89-4601102348a4" });
        }
    }
}
