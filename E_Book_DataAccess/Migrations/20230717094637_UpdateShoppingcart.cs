using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Book_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShoppingcart : Migration
    {
        /// <inheritdoc />
        //protected override void Up(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropColumn(
        //        name: "ApplicationUser",
        //        table: "shoppingCarts");

        //    migrationBuilder.AlterColumn<string>(
        //        name: "ApplicationUserId",
        //        table: "shoppingCarts",
        //        type: "nvarchar(450)",
        //        nullable: true,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(max)",
        //        oldNullable: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_shoppingCarts_ApplicationUserId",
        //        table: "shoppingCarts",
        //        column: "ApplicationUserId");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_shoppingCarts_AspNetUsers_ApplicationUserId",
        //        table: "shoppingCarts",
        //        column: "ApplicationUserId",
        //        principalTable: "AspNetUsers",
        //        principalColumn: "Id");
        //}

        ///// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_shoppingCarts_AspNetUsers_ApplicationUserId",
        //        table: "shoppingCarts");

        //    migrationBuilder.DropIndex(
        //        name: "IX_shoppingCarts_ApplicationUserId",
        //        table: "shoppingCarts");

        //    migrationBuilder.AlterColumn<string>(
        //        name: "ApplicationUserId",
        //        table: "shoppingCarts",
        //        type: "nvarchar(max)",
        //        nullable: true,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(450)",
        //        oldNullable: true);

        //    migrationBuilder.AddColumn<string>(
        //        name: "ApplicationUser",
        //        table: "shoppingCarts",
        //        type: "nvarchar(max)",
        //        nullable: true);
        //}




        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingCarts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_shoppingCarts_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_ApplicationUserId",
                table: "shoppingCarts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_ProductId",
                table: "shoppingCarts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shoppingCarts");
        }





    }
}
