using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class fieldNameChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classification_InstituteMembership_ClassificationMemberId",
                schema: "InstituteManagement",
                table: "Classification");

            migrationBuilder.RenameColumn(
                name: "ClassificationMemberId",
                schema: "InstituteManagement",
                table: "Classification",
                newName: "PupilMembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_Classification_ClassificationMemberId",
                schema: "InstituteManagement",
                table: "Classification",
                newName: "IX_Classification_PupilMembershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classification_InstituteMembership_PupilMembershipId",
                schema: "InstituteManagement",
                table: "Classification",
                column: "PupilMembershipId",
                principalSchema: "InstituteManagement",
                principalTable: "InstituteMembership",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classification_InstituteMembership_PupilMembershipId",
                schema: "InstituteManagement",
                table: "Classification");

            migrationBuilder.RenameColumn(
                name: "PupilMembershipId",
                schema: "InstituteManagement",
                table: "Classification",
                newName: "ClassificationMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Classification_PupilMembershipId",
                schema: "InstituteManagement",
                table: "Classification",
                newName: "IX_Classification_ClassificationMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classification_InstituteMembership_ClassificationMemberId",
                schema: "InstituteManagement",
                table: "Classification",
                column: "ClassificationMemberId",
                principalSchema: "InstituteManagement",
                principalTable: "InstituteMembership",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
