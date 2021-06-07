using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeMVC.Infrastructure.Migrations
{
    public partial class CafeMVC2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Users_UserId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetailInfotmationTypes_UserContactInformation_UserContactInformationRef",
                table: "ContactDetailInfotmationTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "UserContactInformation");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "OrderConfirmation");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Orders",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "UserContactInformationRef",
                table: "ContactDetailInfotmationTypes",
                newName: "CustomerContactInformationRef");

            migrationBuilder.RenameIndex(
                name: "IX_ContactDetailInfotmationTypes_UserContactInformationRef",
                table: "ContactDetailInfotmationTypes",
                newName: "IX_ContactDetailInfotmationTypes_CustomerContactInformationRef");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Adresses",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Adresses_UserId",
                table: "Adresses",
                newName: "IX_Adresses_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOrder",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCollection",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DietInformationImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte>(type: "tinyint", nullable: false),
                    DietInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietInformationImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DietInformationImages_DietInformation_DietInformationId",
                        column: x => x.DietInformationId,
                        principalTable: "DietInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProductRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductRef",
                        column: x => x.ProductRef,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerContactInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactDetailInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetailTypId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContactInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerContactInformation_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContactInformation_CustomerId",
                table: "CustomerContactInformation",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DietInformationImages_DietInformationId",
                table: "DietInformationImages",
                column: "DietInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductRef",
                table: "ProductImages",
                column: "ProductRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Customers_CustomerId",
                table: "Adresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetailInfotmationTypes_CustomerContactInformation_CustomerContactInformationRef",
                table: "ContactDetailInfotmationTypes",
                column: "CustomerContactInformationRef",
                principalTable: "CustomerContactInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Customers_CustomerId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetailInfotmationTypes_CustomerContactInformation_CustomerContactInformationRef",
                table: "ContactDetailInfotmationTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CustomerContactInformation");

            migrationBuilder.DropTable(
                name: "DietInformationImages");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateOfOrder",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsCollection",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "OrderConfirmation",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CustomerContactInformationRef",
                table: "ContactDetailInfotmationTypes",
                newName: "UserContactInformationRef");

            migrationBuilder.RenameIndex(
                name: "IX_ContactDetailInfotmationTypes_CustomerContactInformationRef",
                table: "ContactDetailInfotmationTypes",
                newName: "IX_ContactDetailInfotmationTypes_UserContactInformationRef");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Adresses",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Adresses_CustomerId",
                table: "Adresses",
                newName: "IX_Adresses_UserId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserContactInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactDetailInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactDetailTypId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContactInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContactInformation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContactInformation_UserId",
                table: "UserContactInformation",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Users_UserId",
                table: "Adresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetailInfotmationTypes_UserContactInformation_UserContactInformationRef",
                table: "ContactDetailInfotmationTypes",
                column: "UserContactInformationRef",
                principalTable: "UserContactInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
