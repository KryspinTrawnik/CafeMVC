using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeMVC.Infrastructure.Migrations
{
    public partial class orderUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "PayPal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
