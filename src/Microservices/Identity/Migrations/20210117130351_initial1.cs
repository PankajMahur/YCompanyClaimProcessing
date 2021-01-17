using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PolicyCustomers",
                columns: new[] { "CustomerId", "FirstName", "LastName", "MobileNumber" },
                values: new object[] { new Guid("3d460ad8-b566-49ef-a1f6-e44bd5b641f5"), "Pankaj", "Mahur", "1234" });

            migrationBuilder.InsertData(
                table: "PolicyCustomers",
                columns: new[] { "CustomerId", "FirstName", "LastName", "MobileNumber" },
                values: new object[] { new Guid("2c59df60-7495-4152-bacf-58c92595f676"), "Pooja", "Mahur", "5678" });

            migrationBuilder.InsertData(
                table: "PolicyCustomers",
                columns: new[] { "CustomerId", "FirstName", "LastName", "MobileNumber" },
                values: new object[] { new Guid("19ea5298-053e-48f6-96fe-b19fa041268c"), "Neha", "Mahur", "91011" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PolicyCustomers",
                keyColumn: "CustomerId",
                keyValue: new Guid("19ea5298-053e-48f6-96fe-b19fa041268c"));

            migrationBuilder.DeleteData(
                table: "PolicyCustomers",
                keyColumn: "CustomerId",
                keyValue: new Guid("2c59df60-7495-4152-bacf-58c92595f676"));

            migrationBuilder.DeleteData(
                table: "PolicyCustomers",
                keyColumn: "CustomerId",
                keyValue: new Guid("3d460ad8-b566-49ef-a1f6-e44bd5b641f5"));
        }
    }
}
