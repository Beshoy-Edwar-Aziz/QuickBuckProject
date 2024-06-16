using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickBuck.Repository.Data.Migrations
{
    public partial class addingname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Messages");
        }
    }
}
