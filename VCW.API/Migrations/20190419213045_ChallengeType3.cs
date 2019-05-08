using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ChallengeType3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                "ChallengeType",
                "Challenges",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                "CompanyName",
                "Challenges",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "ChallengeType",
                "Challenges");

            migrationBuilder.DropColumn(
                "CompanyName",
                "Challenges");
        }
    }
}