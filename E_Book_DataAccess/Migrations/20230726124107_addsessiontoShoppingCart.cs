using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Book_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addsessiontoShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Session",
                table: "shoppingCarts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Session",
                table: "shoppingCarts");
        }
    }
}
