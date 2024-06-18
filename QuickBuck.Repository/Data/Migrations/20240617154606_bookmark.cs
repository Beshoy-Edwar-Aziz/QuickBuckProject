using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickBuck.Repository.Data.Migrations
{
    public partial class bookmark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                columns: new[] { "Id", "JobSeekerId", "JobPostId" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_JobSeekerId",
                table: "Bookmarks",
                column: "JobSeekerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_JobSeekerId",
                table: "Bookmarks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                columns: new[] { "JobSeekerId", "JobPostId" });
        }
    }
}
