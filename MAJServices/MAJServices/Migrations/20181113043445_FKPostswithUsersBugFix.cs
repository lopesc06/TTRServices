using Microsoft.EntityFrameworkCore.Migrations;

namespace MAJServices.Migrations
{
    public partial class FKPostswithUsersBugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "754ff240-a94d-42a2-8f1e-bcf8b4395de5", "2b4ec8ae-09de-4605-a1ef-5377ca7c2c2e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "adc65061-5002-4975-a3ac-403ccc1e240b", "40c19764-6820-4baa-ba10-7aa908ca8c03" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "cbd420f5-f4b7-4ded-b02b-0be3f0e7cae8", "1ee83260-19ac-47d3-9e7f-962fdcf8e36c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ead63431-fafd-4a1b-a0a8-fb0d95282c51", "fffd99cb-6b96-4b97-857b-e258559a7726" });

            migrationBuilder.AddColumn<string>(
                name: "DepartmentId",
                table: "Posts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "isActive" },
                values: new object[] { "166881bc-f0a4-461e-a86b-13d3ac45ca9a", "77bbb5e4-fe64-401e-808d-6639091e0547", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014378223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "isActive" },
                values: new object[] { "3932ad86-94fd-49ea-9373-a43e3792faaa", "af07da05-7c00-4ccc-aae1-9a77cea78795", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014630132",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "isActive" },
                values: new object[] { "57de4908-2d7e-4bf4-9906-ce9810e400c3", "b651b24d-c769-4a45-9988-d8b1e150a6c2", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014631903",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "isActive" },
                values: new object[] { "7390ecb1-056b-4eab-94aa-bb6aa2e38fef", "29be639c-a64c-4075-aa89-4601102348a4", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "adc65061-5002-4975-a3ac-403ccc1e240b", "40c19764-6820-4baa-ba10-7aa908ca8c03", "SuperAdmin", "SUPERADMIN" },
                    { "ead63431-fafd-4a1b-a0a8-fb0d95282c51", "fffd99cb-6b96-4b97-857b-e258559a7726", "Admin", "ADMIN" },
                    { "cbd420f5-f4b7-4ded-b02b-0be3f0e7cae8", "1ee83260-19ac-47d3-9e7f-962fdcf8e36c", "Subadmin", "SUBADMIN" },
                    { "754ff240-a94d-42a2-8f1e-bcf8b4395de5", "2b4ec8ae-09de-4605-a1ef-5377ca7c2c2e", "General", "GENERAL" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014193056",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78ce0c37-6b5c-4336-8e99-a1a743eca47f", "a2b05cce-a925-43d5-994e-67ee02c6824b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014378223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f0c52c28-b268-474f-a6f2-11a980a6e57e", "388dc68f-2fbd-4812-9c0c-e13d8d10c7b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014630132",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5de87f13-b52f-4e76-b863-7ea45d1204c0", "f4bdee45-44e8-4dbd-bbab-45dc0221c6d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014631903",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7afc9e7c-d58c-48c6-8081-36572250802c", "df7a570a-7285-40ec-9a74-080f410c8dfa" });
        }
    }
}
