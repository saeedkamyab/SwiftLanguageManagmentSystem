using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TermCourseTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                schema: "InstituteManagement",
                table: "TermCourse",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TermCourse_TeacherId",
                schema: "InstituteManagement",
                table: "TermCourse",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_TermCourse_InstituteMembership_TeacherId",
                schema: "InstituteManagement",
                table: "TermCourse",
                column: "TeacherId",
                principalSchema: "InstituteManagement",
                principalTable: "InstituteMembership",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TermCourse_InstituteMembership_TeacherId",
                schema: "InstituteManagement",
                table: "TermCourse");

            migrationBuilder.DropIndex(
                name: "IX_TermCourse_TeacherId",
                schema: "InstituteManagement",
                table: "TermCourse");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                schema: "InstituteManagement",
                table: "TermCourse");
        }
    }
}
