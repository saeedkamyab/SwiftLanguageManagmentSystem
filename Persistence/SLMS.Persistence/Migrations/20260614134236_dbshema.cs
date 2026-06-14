using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dbshema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "InstituteField",
                newName: "InstituteField",
                newSchema: "InstituteManagement");

            migrationBuilder.RenameTable(
                name: "Field",
                newName: "Field",
                newSchema: "InstituteManagement");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Category",
                newSchema: "InstituteManagement");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "InstituteField",
                schema: "InstituteManagement",
                newName: "InstituteField");

            migrationBuilder.RenameTable(
                name: "Field",
                schema: "InstituteManagement",
                newName: "Field");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "InstituteManagement",
                newName: "Category");
        }
    }
}
