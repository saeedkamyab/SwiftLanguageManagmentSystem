using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserEntityAndConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessageMedias_MediaAsset_MediaAssetId",
                table: "ChatMessageMedias");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessageMedias_Message_MessageId",
                table: "ChatMessageMedias");

            migrationBuilder.DropForeignKey(
                name: "FK_PostMedias_MediaAsset_MediaAssetId",
                table: "PostMedias");

            migrationBuilder.DropForeignKey(
                name: "FK_PostMedias_Post_PostId",
                table: "PostMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostMedias",
                table: "PostMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessageMedias",
                table: "ChatMessageMedias");

            migrationBuilder.EnsureSchema(
                name: "Media");

            migrationBuilder.RenameTable(
                name: "MediaAsset",
                newName: "MediaAsset",
                newSchema: "Media");

            migrationBuilder.RenameTable(
                name: "PostMedias",
                newName: "PostMedia",
                newSchema: "SocialNetwork");

            migrationBuilder.RenameTable(
                name: "ChatMessageMedias",
                newName: "ChatMessageMedia",
                newSchema: "Messaging");

            migrationBuilder.RenameIndex(
                name: "IX_PostMedias_PostId",
                schema: "SocialNetwork",
                table: "PostMedia",
                newName: "IX_PostMedia_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_PostMedias_MediaAssetId",
                schema: "SocialNetwork",
                table: "PostMedia",
                newName: "IX_PostMedia_MediaAssetId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessageMedias_MessageId",
                schema: "Messaging",
                table: "ChatMessageMedia",
                newName: "IX_ChatMessageMedia_MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessageMedias_MediaAssetId",
                schema: "Messaging",
                table: "ChatMessageMedia",
                newName: "IX_ChatMessageMedia_MediaAssetId");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImageUrl",
                schema: "UserManagment",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                schema: "UserManagment",
                table: "User",
                type: "character(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "UserManagment",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "UserManagment",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "TermCourse",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "TermCourse",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "Room",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "Room",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "SocialNetwork",
                table: "Post",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "SocialNetwork",
                table: "Post",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "Messaging",
                table: "Message",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "Messaging",
                table: "Message",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "MembershipRequest",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "MembershipRequest",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "SocialNetwork",
                table: "Like",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "SocialNetwork",
                table: "Like",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "Level",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "Level",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "InstituteMembershipGroup",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "InstituteMembershipGroup",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "InstituteMembership",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "InstituteMembership",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "Institute",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "Institute",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "Group",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "Group",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "SocialNetwork",
                table: "Follow",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "SocialNetwork",
                table: "Follow",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "Messaging",
                table: "ConversationMember",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "Messaging",
                table: "ConversationMember",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "Messaging",
                table: "Conversation",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "Messaging",
                table: "Conversation",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "SocialNetwork",
                table: "Comment",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "SocialNetwork",
                table: "Comment",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "Classification",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "Classification",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "Certificate",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "Certificate",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "SocialNetwork",
                table: "Bookmark",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "SocialNetwork",
                table: "Bookmark",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "AbsentPresent",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "AbsentPresent",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "Media",
                table: "MediaAsset",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "Media",
                table: "MediaAsset",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "SocialNetwork",
                table: "PostMedia",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "SocialNetwork",
                table: "PostMedia",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "Messaging",
                table: "ChatMessageMedia",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedById",
                schema: "Messaging",
                table: "ChatMessageMedia",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostMedia",
                schema: "SocialNetwork",
                table: "PostMedia",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessageMedia",
                schema: "Messaging",
                table: "ChatMessageMedia",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessageMedia_MediaAsset_MediaAssetId",
                schema: "Messaging",
                table: "ChatMessageMedia",
                column: "MediaAssetId",
                principalSchema: "Media",
                principalTable: "MediaAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessageMedia_Message_MessageId",
                schema: "Messaging",
                table: "ChatMessageMedia",
                column: "MessageId",
                principalSchema: "Messaging",
                principalTable: "Message",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostMedia_MediaAsset_MediaAssetId",
                schema: "SocialNetwork",
                table: "PostMedia",
                column: "MediaAssetId",
                principalSchema: "Media",
                principalTable: "MediaAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostMedia_Post_PostId",
                schema: "SocialNetwork",
                table: "PostMedia",
                column: "PostId",
                principalSchema: "SocialNetwork",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessageMedia_MediaAsset_MediaAssetId",
                schema: "Messaging",
                table: "ChatMessageMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessageMedia_Message_MessageId",
                schema: "Messaging",
                table: "ChatMessageMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_PostMedia_MediaAsset_MediaAssetId",
                schema: "SocialNetwork",
                table: "PostMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_PostMedia_Post_PostId",
                schema: "SocialNetwork",
                table: "PostMedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostMedia",
                schema: "SocialNetwork",
                table: "PostMedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessageMedia",
                schema: "Messaging",
                table: "ChatMessageMedia");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "UserManagment",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "UserManagment",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "TermCourse");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "TermCourse");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "SocialNetwork",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "SocialNetwork",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "Messaging",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "Messaging",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "MembershipRequest");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "MembershipRequest");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "SocialNetwork",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "SocialNetwork",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "Level");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "Level");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "InstituteMembershipGroup");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "InstituteMembershipGroup");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "InstituteMembership");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "InstituteMembership");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "Institute");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "Institute");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "SocialNetwork",
                table: "Follow");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "SocialNetwork",
                table: "Follow");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "Messaging",
                table: "ConversationMember");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "Messaging",
                table: "ConversationMember");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "Messaging",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "Messaging",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "SocialNetwork",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "SocialNetwork",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "Classification");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "Classification");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "SocialNetwork",
                table: "Bookmark");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "SocialNetwork",
                table: "Bookmark");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "InstituteManagement",
                table: "AbsentPresent");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "InstituteManagement",
                table: "AbsentPresent");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "Media",
                table: "MediaAsset");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "Media",
                table: "MediaAsset");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "SocialNetwork",
                table: "PostMedia");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "SocialNetwork",
                table: "PostMedia");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "Messaging",
                table: "ChatMessageMedia");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                schema: "Messaging",
                table: "ChatMessageMedia");

            migrationBuilder.RenameTable(
                name: "MediaAsset",
                schema: "Media",
                newName: "MediaAsset");

            migrationBuilder.RenameTable(
                name: "PostMedia",
                schema: "SocialNetwork",
                newName: "PostMedias");

            migrationBuilder.RenameTable(
                name: "ChatMessageMedia",
                schema: "Messaging",
                newName: "ChatMessageMedias");

            migrationBuilder.RenameIndex(
                name: "IX_PostMedia_PostId",
                table: "PostMedias",
                newName: "IX_PostMedias_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_PostMedia_MediaAssetId",
                table: "PostMedias",
                newName: "IX_PostMedias_MediaAssetId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessageMedia_MessageId",
                table: "ChatMessageMedias",
                newName: "IX_ChatMessageMedias_MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessageMedia_MediaAssetId",
                table: "ChatMessageMedias",
                newName: "IX_ChatMessageMedias_MediaAssetId");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImageUrl",
                schema: "UserManagment",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                schema: "UserManagment",
                table: "User",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostMedias",
                table: "PostMedias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessageMedias",
                table: "ChatMessageMedias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessageMedias_MediaAsset_MediaAssetId",
                table: "ChatMessageMedias",
                column: "MediaAssetId",
                principalTable: "MediaAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessageMedias_Message_MessageId",
                table: "ChatMessageMedias",
                column: "MessageId",
                principalSchema: "Messaging",
                principalTable: "Message",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostMedias_MediaAsset_MediaAssetId",
                table: "PostMedias",
                column: "MediaAssetId",
                principalTable: "MediaAsset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostMedias_Post_PostId",
                table: "PostMedias",
                column: "PostId",
                principalSchema: "SocialNetwork",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
