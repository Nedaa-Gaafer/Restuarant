using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restorant.Context.Migrations
{
    /// <inheritdoc />
    public partial class finaM1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_UserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartMenuItem_Cart_CartId",
                table: "CartMenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartMenuItem_MenuItems_MenuItemId",
                table: "CartMenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartMenuItem",
                table: "CartMenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "CartMenuItem",
                newName: "CartMenuItems");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_CartMenuItem_CartId",
                table: "CartMenuItems",
                newName: "IX_CartMenuItems_CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_UserId",
                table: "Carts",
                newName: "IX_Carts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartMenuItems",
                table: "CartMenuItems",
                columns: new[] { "MenuItemId", "CartId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 14, 30, 26, 25, DateTimeKind.Utc).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 14, 30, 26, 25, DateTimeKind.Utc).AddTicks(1801));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 14, 30, 26, 25, DateTimeKind.Utc).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 14, 30, 26, 30, DateTimeKind.Utc).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 14, 30, 26, 30, DateTimeKind.Utc).AddTicks(5816));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 14, 30, 26, 30, DateTimeKind.Utc).AddTicks(5825));

            migrationBuilder.AddForeignKey(
                name: "FK_CartMenuItems_Carts_CartId",
                table: "CartMenuItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartMenuItems_MenuItems_MenuItemId",
                table: "CartMenuItems",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartMenuItems_Carts_CartId",
                table: "CartMenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartMenuItems_MenuItems_MenuItemId",
                table: "CartMenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartMenuItems",
                table: "CartMenuItems");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Cart");

            migrationBuilder.RenameTable(
                name: "CartMenuItems",
                newName: "CartMenuItem");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserId",
                table: "Cart",
                newName: "IX_Cart_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CartMenuItems_CartId",
                table: "CartMenuItem",
                newName: "IX_CartMenuItem_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartMenuItem",
                table: "CartMenuItem",
                columns: new[] { "MenuItemId", "CartId" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 12, 29, 21, 462, DateTimeKind.Utc).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 12, 29, 21, 462, DateTimeKind.Utc).AddTicks(2672));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 12, 29, 21, 462, DateTimeKind.Utc).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 12, 29, 21, 468, DateTimeKind.Utc).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 12, 29, 21, 468, DateTimeKind.Utc).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 24, 12, 29, 21, 468, DateTimeKind.Utc).AddTicks(5899));

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartMenuItem_Cart_CartId",
                table: "CartMenuItem",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartMenuItem_MenuItems_MenuItemId",
                table: "CartMenuItem",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
