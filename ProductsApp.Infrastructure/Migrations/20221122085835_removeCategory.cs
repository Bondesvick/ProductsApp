using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
