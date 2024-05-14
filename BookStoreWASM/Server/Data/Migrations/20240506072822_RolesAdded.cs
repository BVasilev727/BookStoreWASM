using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreWASM.Server.Data.Migrations
{
    public partial class RolesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3576b6b-6752-44a9-86a8-c96ca6cb9849", "2900598b-56f6-4f20-8099-311dca4694a0", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce78b99c-c86f-4c9e-91eb-bce4640f2e93", "c62aabae-6291-4cb6-9265-084c1baf2983", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3576b6b-6752-44a9-86a8-c96ca6cb9849");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce78b99c-c86f-4c9e-91eb-bce4640f2e93");
        }
    }
}
