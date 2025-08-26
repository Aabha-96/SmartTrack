using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartTrack.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b27a8f28-0b9b-4d4d-8c5b-12ab34cd56ef", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a12c3d45-678e-9fab-bc12-3456de7890ff", 0, "02b22d20-2223-439b-bae8-71162dfb0781", "admin@demo.com", true, "Default Admin", false, null, "ADMIN@DEMO.COM", "ADMIN@DEMO.COM", "AQAAAAIAAYagAAAAEJgSs1aQf94cVKxkRkYvfNaoVUiPluC+oc1bUmHAM1E+zuu2XC8xZDztxcdykd+zng==", null, false, "a80708ff-faa3-4138-bc7d-3cc5fedb2c12", false, "admin@demo.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b27a8f28-0b9b-4d4d-8c5b-12ab34cd56ef", "a12c3d45-678e-9fab-bc12-3456de7890ff" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b27a8f28-0b9b-4d4d-8c5b-12ab34cd56ef", "a12c3d45-678e-9fab-bc12-3456de7890ff" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b27a8f28-0b9b-4d4d-8c5b-12ab34cd56ef");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a12c3d45-678e-9fab-bc12-3456de7890ff");
        }
    }
}
