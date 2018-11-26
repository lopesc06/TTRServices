using Microsoft.EntityFrameworkCore.Migrations;

namespace MAJServices.Migrations
{
    public partial class FirebaseTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "52fd8488-beea-4688-ade3-d09a1a21e0f5", "352534d8-89a0-4f99-8222-32d124378b82" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "82a9ea4e-5ffa-431d-a81d-85185164c10b", "16028b7a-fade-4880-90c1-337858001ed8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9e5860ea-fb9f-4606-9530-27ce61ac0b1e", "b5375c53-c3ba-4baf-97c1-b8227750dd23" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "fbdf0b50-8388-4cb4-aca3-87b3cdd86287", "912a33a1-e833-49fd-b2f5-7dd249b98f14" });

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Posts",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "FirebaseCMDevices",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    DeviceId = table.Column<string>(maxLength: 250, nullable: false),
                    Token = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirebaseCMDevices", x => new { x.UserId, x.DeviceId });
                    table.ForeignKey(
                        name: "FK_FirebaseCMDevices_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirebaseCMDevices");

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

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Posts",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82a9ea4e-5ffa-431d-a81d-85185164c10b", "16028b7a-fade-4880-90c1-337858001ed8", "SuperAdmin", "SUPERADMIN" },
                    { "9e5860ea-fb9f-4606-9530-27ce61ac0b1e", "b5375c53-c3ba-4baf-97c1-b8227750dd23", "Admin", "ADMIN" },
                    { "fbdf0b50-8388-4cb4-aca3-87b3cdd86287", "912a33a1-e833-49fd-b2f5-7dd249b98f14", "Subadmin", "SUBADMIN" },
                    { "52fd8488-beea-4688-ade3-d09a1a21e0f5", "352534d8-89a0-4f99-8222-32d124378b82", "General", "GENERAL" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014193056",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0898666c-c00f-420d-9ffe-e3bf0c0a6306", "81ba2534-3b48-478e-8bbf-899fd886e2f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014378223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "21ded887-34d8-4c3c-bca4-37d557c0f295", "991ddec7-db03-4d01-b130-4c5293308153" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014630132",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d287fe70-b27d-4e60-967a-e328f39f0048", "f23fb641-7ef7-4377-9236-e5cbdf11ed07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014631903",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d50bb352-9935-41f0-886d-1d804e7b374b", "07820c19-173a-467a-932d-15adf056a21b" });
        }
    }
}
