using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactList.Persistance.Migrations
{
    public partial class default_roles_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a083548f-52be-438d-8ab5-d5d4988a7d78", "b0458e05-ebb9-4ee8-b7dd-bdc07eb64c22", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b15a74dc-d9e6-4c11-8ca6-4ae7d05e7b28", "963bf7c2-69e6-422b-92cb-6bd4cfe70925", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a083548f-52be-438d-8ab5-d5d4988a7d78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b15a74dc-d9e6-4c11-8ca6-4ae7d05e7b28");
        }
    }
}
