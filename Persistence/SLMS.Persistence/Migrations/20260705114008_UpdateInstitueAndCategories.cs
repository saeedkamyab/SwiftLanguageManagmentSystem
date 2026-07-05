using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInstitueAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstituteField",
                schema: "InstituteManagement");

            migrationBuilder.DropTable(
                name: "Field",
                schema: "InstituteManagement");

            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "InstituteManagement",
                table: "Category",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentCategoryId",
                schema: "InstituteManagement",
                table: "Category",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                schema: "InstituteManagement",
                table: "Category",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InstituteCategory",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstituteId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstituteCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstituteCategory_Institute_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Institute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                schema: "InstituteManagement",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteCategory_CategoryId",
                schema: "InstituteManagement",
                table: "InstituteCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteCategory_InstituteId",
                schema: "InstituteManagement",
                table: "InstituteCategory",
                column: "InstituteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                schema: "InstituteManagement",
                table: "Category",
                column: "ParentCategoryId",
                principalSchema: "InstituteManagement",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                schema: "InstituteManagement",
                table: "Category");

            migrationBuilder.DropTable(
                name: "InstituteCategory",
                schema: "InstituteManagement");

            migrationBuilder.DropIndex(
                name: "IX_Category_ParentCategoryId",
                schema: "InstituteManagement",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                schema: "InstituteManagement",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "InstituteManagement",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "InstituteManagement",
                table: "Category",
                newName: "Title");

            migrationBuilder.CreateTable(
                name: "Field",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstituteField",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FieldId = table.Column<Guid>(type: "uuid", nullable: false),
                    InstituteId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstituteField_Field_FieldId",
                        column: x => x.FieldId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstituteField_Institute_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Institute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Field_CategoryId",
                schema: "InstituteManagement",
                table: "Field",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteField_FieldId",
                schema: "InstituteManagement",
                table: "InstituteField",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteField_InstituteId",
                schema: "InstituteManagement",
                table: "InstituteField",
                column: "InstituteId");
        }
    }
}
