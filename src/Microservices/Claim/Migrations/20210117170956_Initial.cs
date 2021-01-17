using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Claim.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Claims",
                columns: new[] { "Id", "PolicyCustomerId", "PolicyId", "RegisterDate", "Status" },
                values: new object[] { new Guid("9eb7b968-f55e-4b3b-9c34-ff6a777dce0c"), new Guid("3d460ad8-b566-49ef-a1f6-e44bd5b641f5"), new Guid("ef52bd90-5769-407e-a357-6d9fa8b6172a"), new DateTime(2021, 1, 17, 22, 39, 55, 834, DateTimeKind.Local).AddTicks(1357), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");
        }
    }
}
