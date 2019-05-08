using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class titleChallenge2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "Title",
                "Challenges",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Title",
                "Challenges");
        }
    }
}