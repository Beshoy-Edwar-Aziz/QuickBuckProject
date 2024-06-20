using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickBuck.Repository.Data.Migrations
{
    public partial class AddingPremStatToSeekerAndProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Premium",
                table: "JobSeekers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Premium",
                table: "JobProviders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Premium",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "Premium",
                table: "JobProviders");
        }
    }
}
