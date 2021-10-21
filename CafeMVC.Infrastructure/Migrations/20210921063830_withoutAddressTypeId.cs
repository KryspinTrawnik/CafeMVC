using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeMVC.Infrastructure.Migrations
{
    public partial class withoutAddressTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_ContactDetailTypeId1",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_CustomerId1",
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
                name: "AddressTypeId1",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Adresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_Adresses_AddressTypeId1",
                table: "Adresses",
                column: "AddressTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_CustomerId1",
                table: "Adresses",
                column: "CustomerId1");

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
        }
    }
}
