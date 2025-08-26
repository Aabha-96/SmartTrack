using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartTrack.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingDataEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "DateofBirth", "Department", "Designation", "EmailAddress", "FirstName", "HireDate", "IsActive", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { 1, "N2W-5Y7,Kitchener", new DateTime(1996, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "Analyst", "anagha123@gmail.com", "Anagha", new DateTime(2024, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chandran", "S", "413-987-657" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1);
        }
    }
}
