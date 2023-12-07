using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog_App.Migrations
{
    /// <inheritdoc />
    public partial class usernamecommentmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "CommentModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "CommentModels");
        }
    }
}
