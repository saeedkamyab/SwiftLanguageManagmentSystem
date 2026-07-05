using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MembershipRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberType",
                schema: "InstituteManagement",
                table: "InstituteMembership");

            migrationBuilder.CreateTable(
                name: "InstituteMembershipRole",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberType = table.Column<byte>(type: "smallint", nullable: false),
                    InstituteMembershipId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteMembershipRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstituteMembershipRole_InstituteMembership_InstituteMember~",
                        column: x => x.InstituteMembershipId,
                        principalSchema: "InstituteManagement",
                        principalTable: "InstituteMembership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMembershipRole_InstituteMembershipId",
                schema: "InstituteManagement",
                table: "InstituteMembershipRole",
                column: "InstituteMembershipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstituteMembershipRole",
                schema: "InstituteManagement");

            migrationBuilder.AddColumn<byte>(
                name: "MemberType",
                schema: "InstituteManagement",
                table: "InstituteMembership",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
