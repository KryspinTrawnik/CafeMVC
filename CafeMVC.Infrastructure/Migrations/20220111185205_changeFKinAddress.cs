using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeMVC.Infrastructure.Migrations
{
    public partial class changeFKinAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_AddressTypes_AddressTypeId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Customers_CustomerId",
                table: "Adresses");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Adresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressTypeId",
                table: "Adresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_AddressTypes_AddressTypeId",
                table: "Adresses",
                column: "AddressTypeId",
                principalTable: "AddressTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Customers_CustomerId",
                table: "Adresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_AddressTypes_AddressTypeId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Customers_CustomerId",
                table: "Adresses");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Adresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressTypeId",
                table: "Adresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_AddressTypes_AddressTypeId",
                table: "Adresses",
                column: "AddressTypeId",
                principalTable: "AddressTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Customers_CustomerId",
                table: "Adresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
