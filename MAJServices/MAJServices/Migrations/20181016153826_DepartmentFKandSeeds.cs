using Microsoft.EntityFrameworkCore.Migrations;

namespace MAJServices.Migrations
{
    public partial class DepartmentFKandSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1c15e941-2a99-47da-9ada-78a69f2b299d", "6789f3e4-fd33-4d96-90e5-ac939893512e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "821558e6-da5b-4a8c-b803-ccca6d735107", "8f987652-e328-4ef1-9294-f274e3544313" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8fb46dc3-52ed-4b87-a80e-54bf2788c3ea", "72d60764-4fe8-43d5-8cb2-b6e4089926d0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c4071d0f-fde0-4c30-bc8b-9c08d35e7a28", "fd61d814-5af6-4421-9e52-d52ec715badb" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7df3acd9-73a7-48d2-a8d4-a504ffa89815", "503615ff-1f6f-43ea-a395-801f4cb897c2", "SuperAdmin", "SUPERADMIN" },
                    { "9100af70-37d9-4ea4-bc48-a2ffd0cd1f4b", "efaa4104-da9a-4dc0-8152-480f340b9c1a", "Admin", "ADMIN" },
                    { "4c57acdd-5d20-45d1-bf0c-f76ab8f18dd5", "443f11be-7ff1-48bb-bc31-a304565cca3f", "Subadmin", "SUBADMIN" },
                    { "2b310ff8-60f5-4e70-9b2a-e6ee5c73f259", "c13ac7d3-3739-428d-b471-15691c5e556a", "General", "GENERAL" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014193056",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "15fcce1f-4ed3-49ce-bac9-4996bc860a67", "2014193056" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014378223",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "4b05f0e2-135e-4683-93d9-73c04420119c", "2014378223" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014630132",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "ed1c34a7-c7ce-48e0-b680-364569d7f4b2", "2014630132" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014631903",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "5046e0ac-fd1c-4b43-9072-a24f28d916e6", "2014631903" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2b310ff8-60f5-4e70-9b2a-e6ee5c73f259", "c13ac7d3-3739-428d-b471-15691c5e556a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4c57acdd-5d20-45d1-bf0c-f76ab8f18dd5", "443f11be-7ff1-48bb-bc31-a304565cca3f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "7df3acd9-73a7-48d2-a8d4-a504ffa89815", "503615ff-1f6f-43ea-a395-801f4cb897c2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9100af70-37d9-4ea4-bc48-a2ffd0cd1f4b", "efaa4104-da9a-4dc0-8152-480f340b9c1a" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8fb46dc3-52ed-4b87-a80e-54bf2788c3ea", "72d60764-4fe8-43d5-8cb2-b6e4089926d0", "SuperAdmin", null },
                    { "c4071d0f-fde0-4c30-bc8b-9c08d35e7a28", "fd61d814-5af6-4421-9e52-d52ec715badb", "Admin", null },
                    { "1c15e941-2a99-47da-9ada-78a69f2b299d", "6789f3e4-fd33-4d96-90e5-ac939893512e", "Subadmin", null },
                    { "821558e6-da5b-4a8c-b803-ccca6d735107", "8f987652-e328-4ef1-9294-f274e3544313", "General", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014193056",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "cc9ee41e-99f4-4985-bd7d-6f1dfc12577a", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014378223",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "3b3f29ea-e7d5-40ff-9738-1de84f74bd8e", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014630132",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "dd84591e-b55d-4046-8842-fbbc15081eb3", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2014631903",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName" },
                values: new object[] { "5b19d93c-3074-4f71-bc3e-6377d76869d1", null });
        }
    }
}
