using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeMVC.Infrastructure.Migrations
{
    public partial class NameChanging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContactInformations_ContactDetailInfotmationTypes_ContactDetailTypeId",
                table: "CustomerContactInformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactDetailInfotmationTypes",
                table: "ContactDetailInfotmationTypes");

            migrationBuilder.RenameTable(
                name: "ContactDetailInfotmationTypes",
                newName: "ContactDetailTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactDetailTypes",
                table: "ContactDetailTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContactInformations_ContactDetailTypes_ContactDetailTypeId",
                table: "CustomerContactInformations",
                column: "ContactDetailTypeId",
                principalTable: "ContactDetailTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContactInformations_ContactDetailTypes_ContactDetailTypeId",
                table: "CustomerContactInformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactDetailTypes",
                table: "ContactDetailTypes");

            migrationBuilder.RenameTable(
                name: "ContactDetailTypes",
                newName: "ContactDetailInfotmationTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactDetailInfotmationTypes",
                table: "ContactDetailInfotmationTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContactInformations_ContactDetailInfotmationTypes_ContactDetailTypeId",
                table: "CustomerContactInformations",
                column: "ContactDetailTypeId",
                principalTable: "ContactDetailInfotmationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
