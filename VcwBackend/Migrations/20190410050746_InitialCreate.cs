using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VcwBackend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Posts",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Posts", x => x.Id); });

            migrationBuilder.CreateTable(
                "Blogs",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(maxLength: 10, nullable: true),
                    Type = table.Column<string>(maxLength: 10, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    CategoryId = table.Column<Guid>(nullable: true),
                    TableId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        "FK_Blogs_Posts_CategoryId",
                        x => x.CategoryId,
                        "Posts",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Blogs_CategoryId",
                "Blogs",
                "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Blogs");

            migrationBuilder.DropTable(
                "Posts");
        }
    }
}