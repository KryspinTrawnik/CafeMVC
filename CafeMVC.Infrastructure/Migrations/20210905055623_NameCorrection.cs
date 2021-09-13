using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeMVC.Infrastructure.Migrations
{
    public partial class NameCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContactInformations_ContactDetailTypes_ContactDetailTypeId",
                table: "CustomerContactInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContactInformations_Customers_CustomerId",
                table: "CustomerContactInformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerContactInformations",
                table: "CustomerContactInformations");

            migrationBuilder.RenameTable(
                name: "CustomerContactInformations",
                newName: "ContactDetails");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerContactInformations_CustomerId",
                table: "ContactDetails",
                newName: "IX_ContactDetails_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerContactInformations_ContactDetailTypeId",
                table: "ContactDetails",
                newName: "IX_ContactDetails_ContactDetailTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactDetails",
                table: "ContactDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_ContactDetailTypes_ContactDetailTypeId",
                table: "ContactDetails",
                column: "ContactDetailTypeId",
                principalTable: "ContactDetailTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Customers_CustomerId",
                table: "ContactDetails",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_ContactDetailTypes_ContactDetailTypeId",
                table: "ContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Customers_CustomerId",
                table: "ContactDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactDetails",
                table: "ContactDetails");

            migrationBuilder.RenameTable(
                name: "ContactDetails",
                newName: "CustomerContactInformations");

            migrationBuilder.RenameIndex(
                name: "IX_ContactDetails_CustomerId",
                table: "CustomerContactInformations",
                newName: "IX_CustomerContactInformations_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactDetails_ContactDetailTypeId",
                table: "CustomerContactInformations",
                newName: "IX_CustomerContactInformations_ContactDetailTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerContactInformations",
                table: "CustomerContactInformations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContactInformations_ContactDetailTypes_ContactDetailTypeId",
                table: "CustomerContactInformations",
                column: "ContactDetailTypeId",
                principalTable: "ContactDetailTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContactInformations_Customers_CustomerId",
                table: "CustomerContactInformations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
