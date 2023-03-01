using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEF.SQL_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryIdColumn_Items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Items");
        }
    }
}
