using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeMVC.Infrastructure.Migrations
{
    public partial class RefractorTypeApproach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressTypes_Adresses_AddressRef",
                table: "AddressTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetailInfotmationTypes_CustomerContactInformations_CustomerContactInformationRef",
                table: "ContactDetailInfotmationTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_DietInformation_Products_ProductRef",
                table: "DietInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId1",
                table: "Products");

            migrationBuilder.DropTable(
                name: "DietInfoTags");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetailInfotmationTypes_CustomerContactInformationRef",
                table: "ContactDetailInfotmationTypes");

            migrationBuilder.DropIndex(
                name: "IX_AddressTypes_AddressRef",
                table: "AddressTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DietInformation",
                table: "DietInformation");

            migrationBuilder.DropIndex(
                name: "IX_DietInformation_ProductRef",
                table: "DietInformation");

            migrationBuilder.DropColumn(
                name: "ProductTypeId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomerContactInformationRef",
                table: "ContactDetailInfotmationTypes");

            migrationBuilder.DropColumn(
                name: "AddressRef",
                table: "AddressTypes");

            migrationBuilder.DropColumn(
                name: "IsGlutenFree",
                table: "DietInformation");

            migrationBuilder.DropColumn(
                name: "IsVegan",
                table: "DietInformation");

            migrationBuilder.DropColumn(
                name: "IsVegetarian",
                table: "DietInformation");

            migrationBuilder.DropColumn(
                name: "ProductRef",
                table: "DietInformation");

            migrationBuilder.RenameTable(
                name: "DietInformation",
                newName: "DietInformations");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Products",
                newName: "ImagePath");

            migrationBuilder.AddColumn<int>(
                name: "ContactDetailTypeId",
                table: "CustomerContactInformations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressTypeId",
                table: "Adresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DietInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "DietInformations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagPathway",
                table: "DietInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DietInformations",
                table: "DietInformations",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AddressTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Billing Address" },
                    { 2, "Delivery Address" }
                });

            migrationBuilder.InsertData(
                table: "ContactDetailInfotmationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "E-mail" },
                    { 2, "Mobile Number" },
                    { 3, "Home Number" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContactInformations_ContactDetailTypeId",
                table: "CustomerContactInformations",
                column: "ContactDetailTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_AddressTypeId",
                table: "Adresses",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DietInformations_ProductId",
                table: "DietInformations",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_AddressTypes_AddressTypeId",
                table: "Adresses",
                column: "AddressTypeId",
                principalTable: "AddressTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContactInformations_ContactDetailInfotmationTypes_ContactDetailTypeId",
                table: "CustomerContactInformations",
                column: "ContactDetailTypeId",
                principalTable: "ContactDetailInfotmationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DietInformations_Products_ProductId",
                table: "DietInformations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_AddressTypes_AddressTypeId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContactInformations_ContactDetailInfotmationTypes_ContactDetailTypeId",
                table: "CustomerContactInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_DietInformations_Products_ProductId",
                table: "DietInformations");

            migrationBuilder.DropIndex(
                name: "IX_CustomerContactInformations_ContactDetailTypeId",
                table: "CustomerContactInformations");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_AddressTypeId",
                table: "Adresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DietInformations",
                table: "DietInformations");

            migrationBuilder.DropIndex(
                name: "IX_DietInformations_ProductId",
                table: "DietInformations");

            migrationBuilder.DeleteData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AddressTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactDetailInfotmationTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactDetailInfotmationTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactDetailInfotmationTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ContactDetailTypeId",
                table: "CustomerContactInformations");

            migrationBuilder.DropColumn(
                name: "AddressTypeId",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DietInformations");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "DietInformations");

            migrationBuilder.DropColumn(
                name: "TagPathway",
                table: "DietInformations");

            migrationBuilder.RenameTable(
                name: "DietInformations",
                newName: "DietInformation");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Products",
                newName: "ImageName");

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerContactInformationRef",
                table: "ContactDetailInfotmationTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressRef",
                table: "AddressTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsGlutenFree",
                table: "DietInformation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVegan",
                table: "DietInformation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVegetarian",
                table: "DietInformation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProductRef",
                table: "DietInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DietInformation",
                table: "DietInformation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DietInfoTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietInformationId = table.Column<int>(type: "int", nullable: true),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietInfoTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DietInfoTags_DietInformation_DietInformationId",
                        column: x => x.DietInformationId,
                        principalTable: "DietInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTypes_Products_ProductRef",
                        column: x => x.ProductRef,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId1",
                table: "Products",
                column: "ProductTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetailInfotmationTypes_CustomerContactInformationRef",
                table: "ContactDetailInfotmationTypes",
                column: "CustomerContactInformationRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressTypes_AddressRef",
                table: "AddressTypes",
                column: "AddressRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DietInformation_ProductRef",
                table: "DietInformation",
                column: "ProductRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DietInfoTags_DietInformationId",
                table: "DietInfoTags",
                column: "DietInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_ProductRef",
                table: "ProductTypes",
                column: "ProductRef",
                unique: true);

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
                name: "FK_DietInformation_Products_ProductRef",
                table: "DietInformation",
                column: "ProductRef",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId1",
                table: "Products",
                column: "ProductTypeId1",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
