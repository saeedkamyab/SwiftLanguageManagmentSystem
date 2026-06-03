using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class postandpostmedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PostMedia_PostId",
                schema: "SocialNetwork",
                table: "PostMedia");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                schema: "SocialNetwork",
                table: "PostMedia");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "SocialNetwork",
                table: "Post");

            migrationBuilder.AddColumn<bool>(
                name: "IsAttached",
                schema: "Media",
                table: "MediaAsset",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_PostMedia_PostId",
                schema: "SocialNetwork",
                table: "PostMedia",
                column: "PostId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PostMedia_PostId",
                schema: "SocialNetwork",
                table: "PostMedia");

            migrationBuilder.DropColumn(
                name: "IsAttached",
                schema: "Media",
                table: "MediaAsset");

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                schema: "SocialNetwork",
                table: "PostMedia",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "SocialNetwork",
                table: "Post",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PostMedia_PostId",
                schema: "SocialNetwork",
                table: "PostMedia",
                column: "PostId");
        }
    }
}
