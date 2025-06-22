using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_footer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Footers_SocialMedias_SocialMediaId",
                table: "Footers");

            migrationBuilder.DropIndex(
                name: "IX_Footers_SocialMediaId",
                table: "Footers");

            migrationBuilder.DropColumn(
                name: "SocialMediaId",
                table: "Footers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SocialMediaId",
                table: "Footers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Footers_SocialMediaId",
                table: "Footers",
                column: "SocialMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Footers_SocialMedias_SocialMediaId",
                table: "Footers",
                column: "SocialMediaId",
                principalTable: "SocialMedias",
                principalColumn: "SocialMediaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
