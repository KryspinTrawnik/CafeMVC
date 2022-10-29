using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeMVC.Infrastructure.Migrations
{
    public partial class deliveryChargeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryCharge",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryCharge",
                table: "Orders");
        }
    }
}
