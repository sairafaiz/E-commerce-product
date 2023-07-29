using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Book_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removeimgurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "products");

        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

        }
    }
}
