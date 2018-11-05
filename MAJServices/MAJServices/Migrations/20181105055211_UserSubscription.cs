using Microsoft.EntityFrameworkCore.Migrations;

namespace MAJServices.Migrations
{
    public partial class UserSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "05a5211f-7ce4-44c7-b6ab-b8bf302864e3", "9adbb418-f149-41ea-bb22-984a9a8e14d8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "223ee420-3088-4b97-9cce-5b48f668c01b", "6a041329-e1e1-4170-855a-d5ec6fbdf043" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "bc0b46a4-9840-4e76-b5a8-bd9fb64d5417", "5725fde8-42f3-4f7c-b35c-9d2de7300825" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f4fe7007-ac6c-4b32-9511-2cdf5b12342c", "be3acdac-b5a0-4d19-8236-34b413a2af6a" });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    DepartmentId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => new { x.UserId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_Subscriptions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentAcronym",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_AspNetUsers_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_DepartmentId",
                table: "Subscriptions",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05a5211f-7ce4-44c7-b6ab-b8bf302864e3", "9adbb418-f149-41ea-bb22-984a9a8e14d8", "SuperAdmin", "SUPERADMIN" },
                    { "f4fe7007-ac6c-4b32-9511-2cdf5b12342c", "be3acdac-b5a0-4d19-8236-34b413a2af6a", "Admin", "ADMIN" },
                    { "bc0b46a4-9840-4e76-b5a8-bd9fb64d5417", "5725fde8-42f3-4f7c-b35c-9d2de7300825", "Subadmin", "SUBADMIN" },
                    { "223ee420-3088-4b97-9cce-5b48f668c01b", "6a041329-e1e1-4170-855a-d5ec6fbdf043", "General", "GENERAL" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014193056",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "55cba4e8-9300-438c-8034-f9e333749c3e", "b175ee2f-3b81-48f7-aeed-8fd3fcc3516b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014378223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "08037b34-4d9c-46e4-b34b-5ec769ee0210", "97107441-ad06-46f6-9695-3737ed8a7dbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014630132",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bae5f0ed-4785-4fa6-9add-cf3cf051cde9", "93dcc1ca-96ab-4cbc-8842-e6c9108316df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014631903",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "19ccb1f5-345e-4fd8-ba18-ac43a6ef8fd6", "8aa50256-bb06-4707-a760-dd735e154734" });
        }
    }
}
