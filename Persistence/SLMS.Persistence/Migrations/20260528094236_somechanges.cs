using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class somechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "Messaging",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "SentAt",
                schema: "Messaging",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                schema: "Messaging",
                table: "Message");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "UserManagment",
                table: "User",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "UserManagment",
                table: "User",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "UserManagment",
                table: "User",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                schema: "UserManagment",
                table: "User",
                type: "character(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "UserManagment",
                table: "User",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "UserManagment",
                table: "User",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                schema: "UserManagment",
                table: "User",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "UserManagment",
                table: "User",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "MessageType",
                schema: "Messaging",
                table: "Message",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<bool>(
                name: "IsGroup",
                schema: "Messaging",
                table: "Conversation",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageType",
                schema: "Messaging",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "IsGroup",
                schema: "Messaging",
                table: "Conversation");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "UserManagment",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "UserManagment",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "UserManagment",
                table: "User",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1500)",
                oldMaxLength: 1500);

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                schema: "UserManagment",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "UserManagment",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "UserManagment",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                schema: "UserManagment",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "UserManagment",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "Messaging",
                table: "Message",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SentAt",
                schema: "Messaging",
                table: "Message",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                schema: "Messaging",
                table: "Message",
                type: "character varying(1500)",
                maxLength: 1500,
                nullable: true);
        }
    }
}
