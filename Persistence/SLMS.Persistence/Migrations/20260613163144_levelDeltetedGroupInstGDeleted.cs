using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class levelDeltetedGroupInstGDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstituteMembership_Level_LevelId",
                schema: "InstituteManagement",
                table: "InstituteMembership");

            migrationBuilder.DropIndex(
                name: "IX_InstituteMembership_LevelId",
                schema: "InstituteManagement",
                table: "InstituteMembership");

            migrationBuilder.DropColumn(
                name: "LevelId",
                schema: "InstituteManagement",
                table: "InstituteMembership");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "InstituteManagement",
                table: "Institute",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Fields",
                schema: "InstituteManagement",
                table: "Institute",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "InstituteManagement",
                table: "Institute",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                schema: "InstituteManagement",
                table: "Certificate",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LevelId",
                schema: "InstituteManagement",
                table: "InstituteMembership",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "InstituteManagement",
                table: "Institute",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Fields",
                schema: "InstituteManagement",
                table: "Institute",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "InstituteManagement",
                table: "Institute",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                schema: "InstituteManagement",
                table: "Certificate",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMembership_LevelId",
                schema: "InstituteManagement",
                table: "InstituteMembership",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstituteMembership_Level_LevelId",
                schema: "InstituteManagement",
                table: "InstituteMembership",
                column: "LevelId",
                principalSchema: "InstituteManagement",
                principalTable: "Level",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
