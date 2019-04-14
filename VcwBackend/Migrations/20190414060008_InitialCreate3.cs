using Microsoft.EntityFrameworkCore.Migrations;

namespace VcwBackend.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Invits_InvitId",
                table: "Ideas");

            migrationBuilder.DropForeignKey(
                name: "FK_Invits_Challenges_ChallengeId",
                table: "Invits");

            migrationBuilder.DropForeignKey(
                name: "FK_Invits_Users_UserId",
                table: "Invits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invits",
                table: "Invits");

            migrationBuilder.RenameTable(
                name: "Invits",
                newName: "Invites");

            migrationBuilder.RenameColumn(
                name: "SecondBunce",
                table: "Challenges",
                newName: "SecondBounce");

            migrationBuilder.RenameIndex(
                name: "IX_Invits_UserId",
                table: "Invites",
                newName: "IX_Invites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invits_ChallengeId",
                table: "Invites",
                newName: "IX_Invites_ChallengeId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ideas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Filters",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Challenges",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Attachments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invites",
                table: "Invites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Invites_InvitId",
                table: "Ideas",
                column: "InvitId",
                principalTable: "Invites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Challenges_ChallengeId",
                table: "Invites",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Users_UserId",
                table: "Invites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Invites_InvitId",
                table: "Ideas");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Challenges_ChallengeId",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Users_UserId",
                table: "Invites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invites",
                table: "Invites");

            migrationBuilder.RenameTable(
                name: "Invites",
                newName: "Invits");

            migrationBuilder.RenameColumn(
                name: "SecondBounce",
                table: "Challenges",
                newName: "SecondBunce");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_UserId",
                table: "Invits",
                newName: "IX_Invits_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_ChallengeId",
                table: "Invits",
                newName: "IX_Invits_ChallengeId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ideas",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Filters",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comments",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Challenges",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Attachments",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invits",
                table: "Invits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Invits_InvitId",
                table: "Ideas",
                column: "InvitId",
                principalTable: "Invits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invits_Challenges_ChallengeId",
                table: "Invits",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invits_Users_UserId",
                table: "Invits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
