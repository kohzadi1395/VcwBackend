using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Blogs_Posts_CategoryId",
                "Blogs");

            migrationBuilder.DropPrimaryKey(
                "PK_Posts",
                "Posts");

            migrationBuilder.DropPrimaryKey(
                "PK_Blogs",
                "Blogs");

            migrationBuilder.RenameTable(
                "Posts",
                newName: "Categories");

            migrationBuilder.RenameTable(
                "Blogs",
                newName: "Attachments");

            migrationBuilder.RenameIndex(
                "IX_Blogs_CategoryId",
                table: "Attachments",
                newName: "IX_Attachments_CategoryId");

            migrationBuilder.AddPrimaryKey(
                "PK_Categories",
                "Categories",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_Attachments",
                "Attachments",
                "Id");

            migrationBuilder.CreateTable(
                "Challenges",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Deadline = table.Column<DateTime>(nullable: true),
                    FirstBounce = table.Column<decimal>(nullable: true),
                    SecondBunce = table.Column<decimal>(nullable: true),
                    ThirdBounce = table.Column<decimal>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Challenges", x => x.Id); });

            migrationBuilder.CreateTable(
                "Comments",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    TableId = table.Column<Guid>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Comments", x => x.Id); });

            migrationBuilder.CreateTable(
                "Filters",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Filters", x => x.Id); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 10, nullable: true),
                    Password = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                "Invits",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsMaster = table.Column<bool>(nullable: true),
                    ChallengeId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invits", x => x.Id);
                    table.ForeignKey(
                        "FK_Invits_Challenges_ChallengeId",
                        x => x.ChallengeId,
                        "Challenges",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Invits_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Ideas",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    InvitId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.Id);
                    table.ForeignKey(
                        "FK_Ideas_Invits_InvitId",
                        x => x.InvitId,
                        "Invits",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "ExamIdeas",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FilterId = table.Column<Guid>(nullable: true),
                    IdeaId = table.Column<Guid>(nullable: true),
                    IsPassed = table.Column<bool>(nullable: true),
                    rank = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamIdeas", x => x.Id);
                    table.ForeignKey(
                        "FK_ExamIdeas_Filters_FilterId",
                        x => x.FilterId,
                        "Filters",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_ExamIdeas_Ideas_IdeaId",
                        x => x.IdeaId,
                        "Ideas",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_ExamIdeas_FilterId",
                "ExamIdeas",
                "FilterId");

            migrationBuilder.CreateIndex(
                "IX_ExamIdeas_IdeaId",
                "ExamIdeas",
                "IdeaId");

            migrationBuilder.CreateIndex(
                "IX_Ideas_InvitId",
                "Ideas",
                "InvitId");

            migrationBuilder.CreateIndex(
                "IX_Invits_ChallengeId",
                "Invits",
                "ChallengeId");

            migrationBuilder.CreateIndex(
                "IX_Invits_UserId",
                "Invits",
                "UserId");

            migrationBuilder.AddForeignKey(
                "FK_Attachments_Categories_CategoryId",
                "Attachments",
                "CategoryId",
                "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Attachments_Categories_CategoryId",
                "Attachments");

            migrationBuilder.DropTable(
                "Comments");

            migrationBuilder.DropTable(
                "ExamIdeas");

            migrationBuilder.DropTable(
                "Filters");

            migrationBuilder.DropTable(
                "Ideas");

            migrationBuilder.DropTable(
                "Invits");

            migrationBuilder.DropTable(
                "Challenges");

            migrationBuilder.DropTable(
                "Users");

            migrationBuilder.DropPrimaryKey(
                "PK_Categories",
                "Categories");

            migrationBuilder.DropPrimaryKey(
                "PK_Attachments",
                "Attachments");

            migrationBuilder.RenameTable(
                "Categories",
                newName: "Posts");

            migrationBuilder.RenameTable(
                "Attachments",
                newName: "Blogs");

            migrationBuilder.RenameIndex(
                "IX_Attachments_CategoryId",
                table: "Blogs",
                newName: "IX_Blogs_CategoryId");

            migrationBuilder.AddPrimaryKey(
                "PK_Posts",
                "Posts",
                "Id");

            migrationBuilder.AddPrimaryKey(
                "PK_Blogs",
                "Blogs",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_Blogs_Posts_CategoryId",
                "Blogs",
                "CategoryId",
                "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}