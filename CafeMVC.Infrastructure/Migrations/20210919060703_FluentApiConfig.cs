using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeMVC.Infrastructure.Migrations
{
    public partial class FluentApiConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_AddressTypes_AddressTypeId",
                table: "Adresses");

            migrationBuilder.AddColumn<int>(
                name: "ContactDetailTypeId1",
                table: "ContactDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "ContactDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ContactDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressTypeId",
                table: "Adresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressTypeId1",
                table: "Adresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Adresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_ContactDetailTypeId1",
                table: "ContactDetails",
                column: "ContactDetailTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_CustomerId1",
                table: "ContactDetails",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_OrderId",
                table: "ContactDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_AddressTypeId1",
                table: "Adresses",
                column: "AddressTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_CustomerId1",
                table: "Adresses",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_AddressTypes_AddressTypeId",
                table: "Adresses",
                column: "AddressTypeId",
                principalTable: "AddressTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_AddressTypes_AddressTypeId1",
                table: "Adresses",
                column: "AddressTypeId1",
                principalTable: "AddressTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Customers_CustomerId1",
                table: "Adresses",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_ContactDetailTypes_ContactDetailTypeId1",
                table: "ContactDetails",
                column: "ContactDetailTypeId1",
                principalTable: "ContactDetailTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Customers_CustomerId1",
                table: "ContactDetails",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Orders_OrderId",
                table: "ContactDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_AddressTypes_AddressTypeId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_AddressTypes_AddressTypeId1",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Customers_CustomerId1",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_ContactDetailTypes_ContactDetailTypeId1",
                table: "ContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Customers_CustomerId1",
                table: "ContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Orders_OrderId",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_ContactDetailTypeId1",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_CustomerId1",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_OrderId",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_AddressTypeId1",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_CustomerId1",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "ContactDetailTypeId1",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "AddressTypeId1",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Adresses");

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
        }
    }
}
