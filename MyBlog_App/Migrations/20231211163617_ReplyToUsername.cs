using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog_App.Migrations
{
    /// <inheritdoc />
    public partial class ReplyToUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ReplyToCommentText",
                table: "CommentModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReplyToUserName",
                table: "CommentModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CommentModels_ParentCommentId",
                table: "CommentModels",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModels_CommentModels_ParentCommentId",
                table: "CommentModels",
                column: "ParentCommentId",
                principalTable: "CommentModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModels_CommentModels_ParentCommentId",
                table: "CommentModels");

            migrationBuilder.DropIndex(
                name: "IX_CommentModels_ParentCommentId",
                table: "CommentModels");

            migrationBuilder.DropColumn(
                name: "ReplyToCommentText",
                table: "CommentModels");

            migrationBuilder.DropColumn(
                name: "ReplyToUserName",
                table: "CommentModels");

            migrationBuilder.AddColumn<int>(
                name: "CommentModelId",
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
    }
}
