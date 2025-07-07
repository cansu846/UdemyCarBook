using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migblog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryForBlogId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryForBlogId",
                table: "Blogs",
                column: "CategoryForBlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_CategoryForBlogs_CategoryForBlogId",
                table: "Blogs",
                column: "CategoryForBlogId",
                principalTable: "CategoryForBlogs",
                principalColumn: "CategoryForBlogId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_CategoryForBlogs_CategoryForBlogId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CategoryForBlogId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CategoryForBlogId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Blogs");
        }
    }
}
