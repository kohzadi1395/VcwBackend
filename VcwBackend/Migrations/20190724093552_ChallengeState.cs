using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VcwBackend.Migrations
{
    public partial class ChallengeState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Categories_FkCategory",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Challenges_FkChallenge",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_FkCategory",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "FkCategory",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "FkChallenge",
                table: "Attachments",
                newName: "ChallengeId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_FkChallenge",
                table: "Attachments",
                newName: "IX_Attachments_ChallengeId");

            migrationBuilder.AddColumn<int>(
                name: "ChallengeState",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChallengeState",
                table: "Attachments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CategoryId",
                table: "Attachments",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Categories_CategoryId",
                table: "Attachments",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Challenges_ChallengeId",
                table: "Attachments",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Categories_CategoryId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Challenges_ChallengeId",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_CategoryId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "ChallengeState",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ChallengeState",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "ChallengeId",
                table: "Attachments",
                newName: "FkChallenge");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_ChallengeId",
                table: "Attachments",
                newName: "IX_Attachments_FkChallenge");

            migrationBuilder.AddColumn<Guid>(
                name: "FkCategory",
                table: "Attachments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_FkCategory",
                table: "Attachments",
                column: "FkCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Categories_FkCategory",
                table: "Attachments",
                column: "FkCategory",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Challenges_FkChallenge",
                table: "Attachments",
                column: "FkChallenge",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
