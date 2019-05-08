using Microsoft.EntityFrameworkCore.Migrations;

namespace VcwBackend.Migrations
{
    public partial class AddCompanyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ChallengeState",
                table: "Challenges",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Challenges",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Challenges");

            migrationBuilder.AlterColumn<decimal>(
                name: "ChallengeState",
                table: "Challenges",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
