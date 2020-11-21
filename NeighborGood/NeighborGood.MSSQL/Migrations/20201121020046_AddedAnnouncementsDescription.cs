using Microsoft.EntityFrameworkCore.Migrations;

namespace NeighborGood.MSSQL.Migrations
{
    public partial class AddedAnnouncementsDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Announcements");
        }
    }
}
