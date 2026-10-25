using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onion.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductBeandId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Discription",
                table: "Products",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Discription");

            migrationBuilder.AddColumn<int>(
                name: "ProductBeandId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
