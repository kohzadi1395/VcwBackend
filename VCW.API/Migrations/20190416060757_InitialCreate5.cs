using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "Company",
                "Users",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                "Pic",
                "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Title",
                "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Company",
                "Users");

            migrationBuilder.DropColumn(
                "Pic",
                "Users");

            migrationBuilder.DropColumn(
                "Title",
                "Users");
        }
    }
}