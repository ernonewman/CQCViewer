using Microsoft.EntityFrameworkCore.Migrations;

namespace CQCViewer.Shared.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProviderDetails",
                columns: table => new
                {
                    providerId = table.Column<string>(nullable: false),
                    organisationType = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    alsoKnownAs = table.Column<string>(nullable: true),
                    registrationStatus = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    postalAddressLine1 = table.Column<string>(nullable: true),
                    postalAddressLine2 = table.Column<string>(nullable: true),
                    postalAddressTownCity = table.Column<string>(nullable: true),
                    postalAddressCounty = table.Column<string>(nullable: true),
                    region = table.Column<string>(nullable: true),
                    postalCode = table.Column<string>(nullable: true),
                    mainPhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderDetails", x => x.providerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderDetails");
        }
    }
}
