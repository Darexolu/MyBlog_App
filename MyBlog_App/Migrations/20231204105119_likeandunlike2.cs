using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog_App.Migrations
{
    /// <inheritdoc />
    public partial class likeandunlike2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_PostModels_PostModelId",
                table: "CommentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeModel_PostModels_PostModelId",
                table: "LikeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeModel",
                table: "LikeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel");

            migrationBuilder.RenameTable(
                name: "LikeModel",
                newName: "LikeModels");

            migrationBuilder.RenameTable(
                name: "CommentModel",
                newName: "CommentModels");

            migrationBuilder.RenameIndex(
                name: "IX_LikeModel_PostModelId",
                table: "LikeModels",
                newName: "IX_LikeModels_PostModelId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_PostModelId",
                table: "CommentModels",
                newName: "IX_CommentModels_PostModelId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CommentModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeModels",
                table: "LikeModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentModels",
                table: "CommentModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModels_PostModels_PostModelId",
                table: "CommentModels",
                column: "PostModelId",
                principalTable: "PostModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeModels_PostModels_PostModelId",
                table: "LikeModels",
                column: "PostModelId",
                principalTable: "PostModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModels_PostModels_PostModelId",
                table: "CommentModels");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeModels_PostModels_PostModelId",
                table: "LikeModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeModels",
                table: "LikeModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentModels",
                table: "CommentModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CommentModels");

            migrationBuilder.RenameTable(
                name: "LikeModels",
                newName: "LikeModel");

            migrationBuilder.RenameTable(
                name: "CommentModels",
                newName: "CommentModel");

            migrationBuilder.RenameIndex(
                name: "IX_LikeModels_PostModelId",
                table: "LikeModel",
                newName: "IX_LikeModel_PostModelId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModels_PostModelId",
                table: "CommentModel",
                newName: "IX_CommentModel_PostModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeModel",
                table: "LikeModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_PostModels_PostModelId",
                table: "CommentModel",
                column: "PostModelId",
                principalTable: "PostModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeModel_PostModels_PostModelId",
                table: "LikeModel",
                column: "PostModelId",
                principalTable: "PostModels",
                principalColumn: "Id");
        }
    }
}
