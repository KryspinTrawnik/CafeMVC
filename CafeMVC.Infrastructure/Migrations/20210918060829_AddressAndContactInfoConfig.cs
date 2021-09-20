using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeMVC.Infrastructure.Migrations
{
    public partial class AddressAndContactInfoConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_ContactDetailTypes_ContactDetailTypeId",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "ContactDetailTypId",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Adresses");

            migrationBuilder.AlterColumn<int>(
                name: "ContactDetailTypeId",
                table: "ContactDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_ContactDetailTypes_ContactDetailTypeId",
                table: "ContactDetails",
                column: "ContactDetailTypeId",
                principalTable: "ContactDetailTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_ContactDetailTypes_ContactDetailTypeId",
                table: "ContactDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ContactDetailTypeId",
                table: "ContactDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ContactDetailTypId",
                table: "ContactDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Adresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_ContactDetailTypes_ContactDetailTypeId",
                table: "ContactDetails",
                column: "ContactDetailTypeId",
                principalTable: "ContactDetailTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
