using Microsoft.EntityFrameworkCore.Migrations;

namespace NeighborGood.MSSQL.Migrations
{
    public partial class AddedAddressProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Announcements_AnnouncementId",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "AnnouncementId",
                table: "Tags",
                newName: "UserRegisterRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_AnnouncementId",
                table: "Tags",
                newName: "IX_Tags_UserRegisterRequestId");

            migrationBuilder.AddColumn<string>(
                name: "Addresess",
                table: "Localizations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Announcements_UserRegisterRequestId",
                table: "Tags",
                column: "UserRegisterRequestId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Announcements_UserRegisterRequestId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Addresess",
                table: "Localizations");

            migrationBuilder.RenameColumn(
                name: "UserRegisterRequestId",
                table: "Tags",
                newName: "AnnouncementId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_UserRegisterRequestId",
                table: "Tags",
                newName: "IX_Tags_AnnouncementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Announcements_AnnouncementId",
                table: "Tags",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
