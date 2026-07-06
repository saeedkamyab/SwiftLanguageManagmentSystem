using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class membershipStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActived",
                schema: "InstituteManagement",
                table: "InstituteMembership",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActived",
                schema: "InstituteManagement",
                table: "InstituteMembership");
        }
    }
}
