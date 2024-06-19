using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickBuck.Repository.Data.Migrations
{
    public partial class ok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WalletId",
                table: "JobProviders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobProviders_WalletId",
                table: "JobProviders",
                column: "WalletId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobProviders_Wallets_WalletId",
                table: "JobProviders",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobProviders_Wallets_WalletId",
                table: "JobProviders");

            migrationBuilder.DropIndex(
                name: "IX_JobProviders_WalletId",
                table: "JobProviders");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "JobProviders");
        }
    }
}
