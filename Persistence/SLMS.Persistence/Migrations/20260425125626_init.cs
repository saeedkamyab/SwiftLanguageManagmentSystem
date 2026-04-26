using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "InstituteManagement");

            migrationBuilder.EnsureSchema(
                name: "SocialNetwork");

            migrationBuilder.EnsureSchema(
                name: "Messaging");

            migrationBuilder.EnsureSchema(
                name: "UserManagment");

            migrationBuilder.CreateTable(
                name: "Conversation",
                schema: "Messaging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LastMessageTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institute",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Fields = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "UserManagment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FatherName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    InstituteId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_Institute_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Institute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    InstituteId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Level_Institute_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Institute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    InstituteId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Institute_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Institute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConversationMember",
                schema: "Messaging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LastReadMessageTimestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ConversationId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversationMember_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalSchema: "Messaging",
                        principalTable: "Conversation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversationMember_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "UserManagment",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Follow",
                schema: "SocialNetwork",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowerUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowingUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follow_User_FollowerUserId",
                        column: x => x.FollowerUserId,
                        principalSchema: "UserManagment",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Follow_User_FollowingUserId",
                        column: x => x.FollowingUserId,
                        principalSchema: "UserManagment",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembershipRequest",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    InstituteId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembershipRequest_Institute_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Institute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembershipRequest_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "UserManagment",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "Messaging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: true),
                    VideoUrl = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: true),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<byte>(type: "smallint", nullable: false, defaultValue: (byte)1),
                    ConversationId = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalSchema: "Messaging",
                        principalTable: "Conversation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_User_SenderUserId",
                        column: x => x.SenderUserId,
                        principalSchema: "UserManagment",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                schema: "SocialNetwork",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Caption = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: true),
                    PostOwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_User_PostOwnerId",
                        column: x => x.PostOwnerId,
                        principalSchema: "UserManagment",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstituteMembership",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberType = table.Column<byte>(type: "smallint", nullable: false),
                    InstituteId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LevelId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteMembership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstituteMembership_Institute_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Institute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstituteMembership_Level_LevelId",
                        column: x => x.LevelId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstituteMembership_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "UserManagment",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TermCourse",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WeekDay = table.Column<byte>(type: "smallint", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LevelId = table.Column<Guid>(type: "uuid", nullable: false),
                    InstituteId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermCourse_Institute_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Institute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TermCourse_Level_LevelId",
                        column: x => x.LevelId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TermCourse_Room_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "SocialNetwork",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CommentContext = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "SocialNetwork",
                        principalTable: "Comment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalSchema: "SocialNetwork",
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "UserManagment",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                schema: "SocialNetwork",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_Post_PostId",
                        column: x => x.PostId,
                        principalSchema: "SocialNetwork",
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "UserManagment",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstituteMembershipGroup",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstituteMembershipId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituteMembershipGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstituteMembershipGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstituteMembershipGroup_InstituteMembership_InstituteMembe~",
                        column: x => x.InstituteMembershipId,
                        principalSchema: "InstituteManagement",
                        principalTable: "InstituteMembership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classification",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TermCourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassificationMemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classification_InstituteMembership_ClassificationMemberId",
                        column: x => x.ClassificationMemberId,
                        principalSchema: "InstituteManagement",
                        principalTable: "InstituteMembership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classification_TermCourse_TermCourseId",
                        column: x => x.TermCourseId,
                        principalSchema: "InstituteManagement",
                        principalTable: "TermCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbsentPresent",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SessionNumber = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    ClassifictionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsentPresent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbsentPresent_Classification_ClassifictionId",
                        column: x => x.ClassifictionId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Classification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                schema: "InstituteManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Reading = table.Column<int>(type: "integer", nullable: false),
                    Writting = table.Column<int>(type: "integer", nullable: false),
                    Listening = table.Column<int>(type: "integer", nullable: false),
                    Speaking = table.Column<int>(type: "integer", nullable: false),
                    MidTerm = table.Column<int>(type: "integer", nullable: false),
                    Final = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<byte>(type: "smallint", nullable: false),
                    ClassificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificate_Classification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalSchema: "InstituteManagement",
                        principalTable: "Classification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbsentPresent_ClassifictionId",
                schema: "InstituteManagement",
                table: "AbsentPresent",
                column: "ClassifictionId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_ClassificationId",
                schema: "InstituteManagement",
                table: "Certificate",
                column: "ClassificationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classification_ClassificationMemberId",
                schema: "InstituteManagement",
                table: "Classification",
                column: "ClassificationMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Classification_TermCourseId",
                schema: "InstituteManagement",
                table: "Classification",
                column: "TermCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentId",
                schema: "SocialNetwork",
                table: "Comment",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                schema: "SocialNetwork",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                schema: "SocialNetwork",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationMember_ConversationId",
                schema: "Messaging",
                table: "ConversationMember",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationMember_UserId",
                schema: "Messaging",
                table: "ConversationMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_FollowerUserId",
                schema: "SocialNetwork",
                table: "Follow",
                column: "FollowerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_FollowingUserId",
                schema: "SocialNetwork",
                table: "Follow",
                column: "FollowingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_InstituteId",
                schema: "InstituteManagement",
                table: "Group",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMembership_InstituteId",
                schema: "InstituteManagement",
                table: "InstituteMembership",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMembership_LevelId",
                schema: "InstituteManagement",
                table: "InstituteMembership",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMembership_UserId",
                schema: "InstituteManagement",
                table: "InstituteMembership",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMembershipGroup_GroupId",
                schema: "InstituteManagement",
                table: "InstituteMembershipGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituteMembershipGroup_InstituteMembershipId",
                schema: "InstituteManagement",
                table: "InstituteMembershipGroup",
                column: "InstituteMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Level_InstituteId",
                schema: "InstituteManagement",
                table: "Level",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_PostId",
                schema: "SocialNetwork",
                table: "Like",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId",
                schema: "SocialNetwork",
                table: "Like",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipRequest_InstituteId",
                schema: "InstituteManagement",
                table: "MembershipRequest",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipRequest_UserId",
                schema: "InstituteManagement",
                table: "MembershipRequest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ConversationId",
                schema: "Messaging",
                table: "Message",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderUserId",
                schema: "Messaging",
                table: "Message",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_PostOwnerId",
                schema: "SocialNetwork",
                table: "Post",
                column: "PostOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_InstituteId",
                schema: "InstituteManagement",
                table: "Room",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_TermCourse_InstituteId",
                schema: "InstituteManagement",
                table: "TermCourse",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_TermCourse_LevelId",
                schema: "InstituteManagement",
                table: "TermCourse",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TermCourse_RoomId",
                schema: "InstituteManagement",
                table: "TermCourse",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbsentPresent",
                schema: "InstituteManagement");

            migrationBuilder.DropTable(
                name: "Certificate",
                schema: "InstituteManagement");

            migrationBuilder.DropTable(
                name: "Comment",
                schema: "SocialNetwork");

            migrationBuilder.DropTable(
                name: "ConversationMember",
                schema: "Messaging");

            migrationBuilder.DropTable(
                name: "Follow",
                schema: "SocialNetwork");

            migrationBuilder.DropTable(
                name: "InstituteMembershipGroup",
                schema: "InstituteManagement");

            migrationBuilder.DropTable(
                name: "Like",
                schema: "SocialNetwork");

            migrationBuilder.DropTable(
                name: "MembershipRequest",
                schema: "InstituteManagement");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "Messaging");

            migrationBuilder.DropTable(
                name: "Classification",
                schema: "InstituteManagement");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "InstituteManagement");

            migrationBuilder.DropTable(
                name: "Post",
                schema: "SocialNetwork");

            migrationBuilder.DropTable(
                name: "Conversation",
                schema: "Messaging");

            migrationBuilder.DropTable(
                name: "InstituteMembership",
                schema: "InstituteManagement");

            migrationBuilder.DropTable(
                name: "TermCourse",
                schema: "InstituteManagement");

            migrationBuilder.DropTable(
                name: "User",
                schema: "UserManagment");

            migrationBuilder.DropTable(
                name: "Level",
                schema: "InstituteManagement");

            migrationBuilder.DropTable(
                name: "Room",
                schema: "InstituteManagement");

            migrationBuilder.DropTable(
                name: "Institute",
                schema: "InstituteManagement");
        }
    }
}
