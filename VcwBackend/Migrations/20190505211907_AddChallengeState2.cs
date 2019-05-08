using Microsoft.EntityFrameworkCore.Migrations;

namespace VcwBackend.Migrations
{
    public partial class AddChallengeState2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ChallengeState",
                table: "Challenges",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChallengeState",
                table: "Challenges");
        }
    }
}
