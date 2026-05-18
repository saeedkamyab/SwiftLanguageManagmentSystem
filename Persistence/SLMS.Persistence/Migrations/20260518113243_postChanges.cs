using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class postChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookmarksCount",
                schema: "SocialNetwork",
                table: "Post",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentsCount",
                schema: "SocialNetwork",
                table: "Post",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikesCount",
                schema: "SocialNetwork",
                table: "Post",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SharesCount",
                schema: "SocialNetwork",
                table: "Post",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookmarksCount",
                schema: "SocialNetwork",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "CommentsCount",
                schema: "SocialNetwork",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "LikesCount",
                schema: "SocialNetwork",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "SharesCount",
                schema: "SocialNetwork",
                table: "Post");
        }
    }
}
