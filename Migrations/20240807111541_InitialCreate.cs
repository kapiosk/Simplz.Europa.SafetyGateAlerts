using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simplz.Europa.SafetyGateAlerts.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    RapexUrl = table.Column<string>(type: "TEXT", nullable: false),
                    AlertLevel = table.Column<string>(type: "TEXT", nullable: true),
                    AlertGroup = table.Column<string>(type: "TEXT", nullable: true),
                    AlertNumber = table.Column<string>(type: "TEXT", nullable: false),
                    AlertCountry = table.Column<string>(type: "TEXT", nullable: true),
                    ProductCountry = table.Column<string>(type: "TEXT", nullable: true),
                    ProductCounterfeit = table.Column<string>(type: "TEXT", nullable: true),
                    RiskLegalProvision = table.Column<string>(type: "TEXT", nullable: true),
                    ProductType = table.Column<string>(type: "TEXT", nullable: true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    ProductDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ProductBrand = table.Column<string>(type: "TEXT", nullable: true),
                    ProductCategory = table.Column<string>(type: "TEXT", nullable: true),
                    ProductModelType = table.Column<string>(type: "TEXT", nullable: true),
                    OecdPortalCategory = table.Column<string>(type: "TEXT", nullable: true),
                    AlertDescription = table.Column<string>(type: "TEXT", nullable: true),
                    TechnicalDefect = table.Column<string>(type: "TEXT", nullable: true),
                    ProductRecallUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ProductBarcode = table.Column<string>(type: "TEXT", nullable: true),
                    ProductBatchNumber = table.Column<string>(type: "TEXT", nullable: true),
                    ProductPackagingDescription = table.Column<string>(type: "TEXT", nullable: true),
                    AlertDate = table.Column<string>(type: "TEXT", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductImage = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.RapexUrl);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
