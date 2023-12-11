using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog_App.Migrations
{
    /// <inheritdoc />
    public partial class replyComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentModelId",
                table: "CommentModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Depth",
                table: "CommentModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentCommentId",
                table: "CommentModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentModels_CommentModelId",
                table: "CommentModels",
                column: "CommentModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModels_CommentModels_CommentModelId",
                table: "CommentModels",
                column: "CommentModelId",
                principalTable: "CommentModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModels_CommentModels_CommentModelId",
                table: "CommentModels");

            migrationBuilder.DropIndex(
                name: "IX_CommentModels_CommentModelId",
                table: "CommentModels");

            migrationBuilder.DropColumn(
                name: "CommentModelId",
                table: "CommentModels");

            migrationBuilder.DropColumn(
                name: "Depth",
                table: "CommentModels");

            migrationBuilder.DropColumn(
                name: "ParentCommentId",
                table: "CommentModels");
        }
    }
}
