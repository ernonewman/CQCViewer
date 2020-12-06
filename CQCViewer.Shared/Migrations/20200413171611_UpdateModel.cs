using Microsoft.EntityFrameworkCore.Migrations;

namespace CQCViewer.Shared.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropColumn(
                // name: "brandId",
                // table: "ProviderDetails");

            // migrationBuilder.DropColumn(
                // name: "brandName",
                // table: "ProviderDetails");

            // migrationBuilder.DropColumn(
                // name: "constituency",
                // table: "ProviderDetails");

            // migrationBuilder.DropColumn(
                // name: "inspectionDirectorate",
                // table: "ProviderDetails");

            // migrationBuilder.DropColumn(
                // name: "localAuthority",
                // table: "ProviderDetails");

            // migrationBuilder.DropColumn(
                // name: "onspdLatitude",
                // table: "ProviderDetails");

            // migrationBuilder.DropColumn(
                // name: "onspdLongitude",
                // table: "ProviderDetails");

            // migrationBuilder.DropColumn(
                // name: "ownershipType",
                // table: "ProviderDetails");

            // migrationBuilder.DropColumn(
                // name: "type",
                // table: "ProviderDetails");

            // migrationBuilder.DropColumn(
                // name: "uprn",
                // table: "ProviderDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "brandId",
                table: "ProviderDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "brandName",
                table: "ProviderDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "constituency",
                table: "ProviderDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inspectionDirectorate",
                table: "ProviderDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "localAuthority",
                table: "ProviderDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "onspdLatitude",
                table: "ProviderDetails",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "onspdLongitude",
                table: "ProviderDetails",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ownershipType",
                table: "ProviderDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "ProviderDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "uprn",
                table: "ProviderDetails",
                type: "TEXT",
                nullable: true);
        }
    }
}
