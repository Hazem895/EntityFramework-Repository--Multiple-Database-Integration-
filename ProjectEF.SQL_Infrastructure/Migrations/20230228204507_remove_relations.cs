using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEF.SQL_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_ItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_ItemId",
                table: "Items",
                column: "ItemId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
