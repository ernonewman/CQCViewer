using Microsoft.EntityFrameworkCore.Migrations;

namespace CQCViewer.Shared.Migrations
{
    public partial class UpdateModelFour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "locationIdsAsAString",
                table: "ProviderDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "locationIdsAsAString",
                table: "ProviderDetails");
        }
    }
}
