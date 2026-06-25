using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TermCourseSessionDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeekDay",
                schema: "InstituteManagement",
                table: "TermCourse");

            migrationBuilder.RenameColumn(
                name: "Time",
                schema: "InstituteManagement",
                table: "TermCourse",
                newName: "StartTime");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "EndTime",
                schema: "InstituteManagement",
                table: "TermCourse",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "InstituteManagement",
                table: "TermCourse",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TermCourseSessionDay",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TermCourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    WeekDay = table.Column<byte>(type: "smallint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermCourseSessionDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermCourseSessionDay_TermCourse_TermCourseId",
                        column: x => x.TermCourseId,
                        principalSchema: "InstituteManagement",
                        principalTable: "TermCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TermCourseSessionDay_TermCourseId",
                schema: "InstituteManagement",
                table: "TermCourseSessionDay",
                column: "TermCourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TermCourseSessionDay",
                schema: "InstituteManagement");

            migrationBuilder.DropColumn(
                name: "EndTime",
                schema: "InstituteManagement",
                table: "TermCourse");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "InstituteManagement",
                table: "TermCourse");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                schema: "InstituteManagement",
                table: "TermCourse",
                newName: "Time");

            migrationBuilder.AddColumn<byte>(
                name: "WeekDay",
                schema: "InstituteManagement",
                table: "TermCourse",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
