using Microsoft.EntityFrameworkCore.Migrations;

namespace MAJServices.Migrations
{
    public partial class FcmJustDeviceIDAsPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FirebaseCMDevices",
                table: "FirebaseCMDevices");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_FirebaseCMDevices",
                table: "FirebaseCMDevices",
                column: "DeviceId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86f4a4b0-98d3-4467-b0fb-059909930eee", "9686ea42-efd3-4274-9903-c5460811fb2d", "SuperAdmin", "SUPERADMIN" },
                    { "f9119eaa-6cd9-4a91-afd3-464eb96303c3", "a6c5cb43-7398-4f68-b285-3a4f785dc3e5", "Admin", "ADMIN" },
                    { "e3a0d9b7-2216-4925-9262-82dfe400feef", "e23fa376-176e-45ed-8174-e21c6b2e0d07", "Subadmin", "SUBADMIN" },
                    { "0e6ee6dc-af85-4e8c-9a40-7090eb80aa70", "64e944f4-5d4a-4d9f-9ab7-eaeacdb2f7a2", "General", "GENERAL" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014193056",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "da9e1b74-1823-48d4-b815-f727f54dc735", "16db7e59-273b-4081-ad33-c4ed57922abc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014378223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2812fbae-e89a-47a5-8156-8994e9d28132", "14cf332e-e99d-4781-9242-ad8f6b9ee596" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014630132",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "db8ce6d4-cdbe-4b80-8936-be6dc1e367f3", "4b8376cf-6143-4c69-b4ad-366f5147c750" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014631903",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6b776258-0fc5-4d16-8ff1-8c678abcf862", "09bd4cd2-5e60-4803-a717-f8d68ecd36d0" });

            migrationBuilder.CreateIndex(
                name: "IX_FirebaseCMDevices_UserId",
                table: "FirebaseCMDevices",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FirebaseCMDevices",
                table: "FirebaseCMDevices");

            migrationBuilder.DropIndex(
                name: "IX_FirebaseCMDevices_UserId",
                table: "FirebaseCMDevices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0e6ee6dc-af85-4e8c-9a40-7090eb80aa70", "64e944f4-5d4a-4d9f-9ab7-eaeacdb2f7a2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "86f4a4b0-98d3-4467-b0fb-059909930eee", "9686ea42-efd3-4274-9903-c5460811fb2d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e3a0d9b7-2216-4925-9262-82dfe400feef", "e23fa376-176e-45ed-8174-e21c6b2e0d07" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f9119eaa-6cd9-4a91-afd3-464eb96303c3", "a6c5cb43-7398-4f68-b285-3a4f785dc3e5" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FirebaseCMDevices",
                table: "FirebaseCMDevices",
                columns: new[] { "UserId", "DeviceId" });

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
        }
    }
}
