using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickBuck.Repository.Data.Migrations
{
    public partial class CreateIntentAndClientSecret : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientSecret",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientSecret",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "Wallets");
        }
    }
}
