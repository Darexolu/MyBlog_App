using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog_App.Migrations
{
    /// <inheritdoc />
    public partial class islikelikemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "LikeModels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "LikeModels");
        }
    }
}
