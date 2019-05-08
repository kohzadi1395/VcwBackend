using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VcwBackend.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Attachments");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Invites",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Invites",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifDate",
                table: "Invites",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Ideas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Ideas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifDate",
                table: "Ideas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Filters",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Filters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifDate",
                table: "Filters",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "ExamIdeas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ExamIdeas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifDate",
                table: "ExamIdeas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Comments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifDate",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ChallengeType",
                table: "Challenges",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Challenges",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Challenges",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifDate",
                table: "Challenges",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Challenges",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Attachments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Attachments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifDate",
                table: "Attachments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "ModifDate",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "ModifDate",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Filters");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Filters");

            migrationBuilder.DropColumn(
                name: "ModifDate",
                table: "Filters");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ExamIdeas");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ExamIdeas");

            migrationBuilder.DropColumn(
                name: "ModifDate",
                table: "ExamIdeas");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ModifDate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ChallengeType",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "ModifDate",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Challenges");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "ModifDate",
                table: "Attachments");

            migrationBuilder.AddColumn<Guid>(
                name: "TableId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TableId",
                table: "Attachments",
                nullable: true);
        }
    }
}
