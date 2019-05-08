using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                "rank",
                "ExamIdeas",
                "Rank");

            migrationBuilder.AlterColumn<string>(
                "Username",
                "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Password",
                "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                "Email",
                "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "FirstName",
                "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "LastName",
                "Users",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                "CategoryName",
                "Categories",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Type",
                "Attachments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "FileName",
                "Attachments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Email",
                "Users");

            migrationBuilder.DropColumn(
                "FirstName",
                "Users");

            migrationBuilder.DropColumn(
                "LastName",
                "Users");

            migrationBuilder.RenameColumn(
                "Rank",
                "ExamIdeas",
                "rank");

            migrationBuilder.AlterColumn<string>(
                "Username",
                "Users",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Password",
                "Users",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "CategoryName",
                "Categories",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "Type",
                "Attachments",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                "FileName",
                "Attachments",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}