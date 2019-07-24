using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VcwBackend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: true),
                    FirstBounce = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SecondBounce = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ThirdBounce = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ChallengeType = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ChallengeState = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ProfileImage = table.Column<byte[]>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: true),
                    FkCategory = table.Column<Guid>(nullable: true),
                    FkChallenge = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Categories_FkCategory",
                        column: x => x.FkCategory,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_Challenges_FkChallenge",
                        column: x => x.FkChallenge,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Invites",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    IsMaster = table.Column<bool>(nullable: true),
                    ChallengeId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invites_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InviteId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filters_Invites_InviteId",
                        column: x => x.InviteId,
                        principalTable: "Invites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ideas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InviteId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ideas_Invites_InviteId",
                        column: x => x.InviteId,
                        principalTable: "Invites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilterStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: true),
                    FilterId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Rank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilterStatuses_Filters_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilterStatuses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilterStatuses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdeaStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StatusId = table.Column<Guid>(nullable: false),
                    IdeaId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdeaStatuses_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdeaStatuses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdeaStatuses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterIdeaPasseds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    FilterStatusId = table.Column<Guid>(nullable: true),
                    IdeaStatusId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    Passed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterIdeaPasseds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilterIdeaPasseds_FilterStatuses_FilterStatusId",
                        column: x => x.FilterStatusId,
                        principalTable: "FilterStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilterIdeaPasseds_IdeaStatuses_IdeaStatusId",
                        column: x => x.IdeaStatusId,
                        principalTable: "IdeaStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilterIdeaPasseds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_FkCategory",
                table: "Attachments",
                column: "FkCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_FkChallenge",
                table: "Attachments",
                column: "FkChallenge");

            migrationBuilder.CreateIndex(
                name: "IX_FilterIdeaPasseds_FilterStatusId",
                table: "FilterIdeaPasseds",
                column: "FilterStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterIdeaPasseds_IdeaStatusId",
                table: "FilterIdeaPasseds",
                column: "IdeaStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterIdeaPasseds_UserId",
                table: "FilterIdeaPasseds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_InviteId",
                table: "Filters",
                column: "InviteId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterStatuses_FilterId",
                table: "FilterStatuses",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterStatuses_StatusId",
                table: "FilterStatuses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterStatuses_UserId",
                table: "FilterStatuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_InviteId",
                table: "Ideas",
                column: "InviteId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaStatuses_IdeaId",
                table: "IdeaStatuses",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaStatuses_StatusId",
                table: "IdeaStatuses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaStatuses_UserId",
                table: "IdeaStatuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_ChallengeId",
                table: "Invites",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_UserId",
                table: "Invites",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FilterIdeaPasseds");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "FilterStatuses");

            migrationBuilder.DropTable(
                name: "IdeaStatuses");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Invites");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
