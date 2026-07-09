using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class isPresent_AbsentPresent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "InstituteManagement",
                table: "AbsentPresent",
                newName: "IsPresent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPresent",
                schema: "InstituteManagement",
                table: "AbsentPresent",
                newName: "Status");
        }
    }
}
