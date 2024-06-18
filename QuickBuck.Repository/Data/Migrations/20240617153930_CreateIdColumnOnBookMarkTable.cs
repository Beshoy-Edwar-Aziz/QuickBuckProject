using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickBuck.Repository.Data.Migrations
{
    public partial class CreateIdColumnOnBookMarkTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Bookmarks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Bookmarks");
        }
    }
}
