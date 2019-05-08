using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Ideas_Invits_InvitId",
                "Ideas");

            migrationBuilder.DropForeignKey(
                "FK_Invits_Challenges_ChallengeId",
                "Invits");

            migrationBuilder.DropForeignKey(
                "FK_Invits_Users_UserId",
                "Invits");

            migrationBuilder.DropPrimaryKey(
                "PK_Invits",
                "Invits");

            migrationBuilder.RenameTable(
                "Invits",
                newName: "Invites");

            migrationBuilder.RenameColumn(
                "SecondBunce",
                "Challenges",
                "SecondBounce");

            migrationBuilder.RenameIndex(
                "IX_Invits_UserId",
                table: "Invites",
                newName: "IX_Invites_UserId");

            migrationBuilder.RenameIndex(
                "IX_Invits_ChallengeId",
                table: "Invites",
                newName: "IX_Invites_ChallengeId");

            migrationBuilder.AlterColumn<string>(
                "Description",
                "Ideas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Description",
                "Filters",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Description",
                "Comments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Description",
                "Challenges",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Description",
                "Attachments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                "PK_Invites",
                "Invites",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_Ideas_Invites_InvitId",
                "Ideas",
                "InvitId",
                "Invites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Invites_Challenges_ChallengeId",
                "Invites",
                "ChallengeId",
                "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Invites_Users_UserId",
                "Invites",
                "UserId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Ideas_Invites_InvitId",
                "Ideas");

            migrationBuilder.DropForeignKey(
                "FK_Invites_Challenges_ChallengeId",
                "Invites");

            migrationBuilder.DropForeignKey(
                "FK_Invites_Users_UserId",
                "Invites");

            migrationBuilder.DropPrimaryKey(
                "PK_Invites",
                "Invites");

            migrationBuilder.RenameTable(
                "Invites",
                newName: "Invits");

            migrationBuilder.RenameColumn(
                "SecondBounce",
                "Challenges",
                "SecondBunce");

            migrationBuilder.RenameIndex(
                "IX_Invites_UserId",
                table: "Invits",
                newName: "IX_Invits_UserId");

            migrationBuilder.RenameIndex(
                "IX_Invites_ChallengeId",
                table: "Invits",
                newName: "IX_Invits_ChallengeId");

            migrationBuilder.AlterColumn<string>(
                "Description",
                "Ideas",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Description",
                "Filters",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Description",
                "Comments",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Description",
                "Challenges",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Description",
                "Attachments",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                "PK_Invits",
                "Invits",
                "Id");

            migrationBuilder.AddForeignKey(
                "FK_Ideas_Invits_InvitId",
                "Ideas",
                "InvitId",
                "Invits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Invits_Challenges_ChallengeId",
                "Invits",
                "ChallengeId",
                "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Invits_Users_UserId",
                "Invits",
                "UserId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}