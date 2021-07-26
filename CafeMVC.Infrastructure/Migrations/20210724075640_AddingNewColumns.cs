using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeMVC.Infrastructure.Migrations
{
    public partial class AddingNewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressTypes_Adresses_AddersRef",
                table: "AddressTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetailInfotmationTypes_CustomerContactInformation_CustomerContactInformationRef",
                table: "ContactDetailInfotmationTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContactInformation_Customers_CustomerId",
                table: "CustomerContactInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerContactInformation",
                table: "CustomerContactInformation");

            migrationBuilder.DropIndex(
                name: "IX_CustomerContactInformation_CustomerId",
                table: "CustomerContactInformation");

            migrationBuilder.RenameTable(
                name: "CustomerContactInformation",
                newName: "CustomerContactInformations");

            migrationBuilder.RenameColumn(
                name: "AddersRef",
                table: "AddressTypes",
                newName: "AddressRef");

            migrationBuilder.RenameIndex(
                name: "IX_AddressTypes_AddersRef",
                table: "AddressTypes",
                newName: "IX_AddressTypes_AddressRef");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderConfirmation",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerContactInformations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerContactInformations",
                table: "CustomerContactInformations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContactInformations_CustomerId",
                table: "CustomerContactInformations",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressTypes_Adresses_AddressRef",
                table: "AddressTypes",
                column: "AddressRef",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetailInfotmationTypes_CustomerContactInformations_CustomerContactInformationRef",
                table: "ContactDetailInfotmationTypes",
                column: "CustomerContactInformationRef",
                principalTable: "CustomerContactInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContactInformations_Customers_CustomerId",
                table: "CustomerContactInformations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressTypes_Adresses_AddressRef",
                table: "AddressTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetailInfotmationTypes_CustomerContactInformations_CustomerContactInformationRef",
                table: "ContactDetailInfotmationTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContactInformations_Customers_CustomerId",
                table: "CustomerContactInformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerContactInformations",
                table: "CustomerContactInformations");

            migrationBuilder.DropIndex(
                name: "IX_CustomerContactInformations_CustomerId",
                table: "CustomerContactInformations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "CustomerContactInformations",
                newName: "CustomerContactInformation");

            migrationBuilder.RenameColumn(
                name: "AddressRef",
                table: "AddressTypes",
                newName: "AddersRef");

            migrationBuilder.RenameIndex(
                name: "IX_AddressTypes_AddressRef",
                table: "AddressTypes",
                newName: "IX_AddressTypes_AddersRef");

            migrationBuilder.AlterColumn<int>(
                name: "OrderConfirmation",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerContactInformation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerContactInformation",
                table: "CustomerContactInformation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContactInformation_CustomerId",
                table: "CustomerContactInformation",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressTypes_Adresses_AddersRef",
                table: "AddressTypes",
                column: "AddersRef",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetailInfotmationTypes_CustomerContactInformation_CustomerContactInformationRef",
                table: "ContactDetailInfotmationTypes",
                column: "CustomerContactInformationRef",
                principalTable: "CustomerContactInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContactInformation_Customers_CustomerId",
                table: "CustomerContactInformation",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
