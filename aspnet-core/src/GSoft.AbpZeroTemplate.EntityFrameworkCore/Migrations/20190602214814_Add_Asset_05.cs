using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Add_Asset_05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets_05",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    AssetId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TotalMonthDepreciation = table.Column<int>(nullable: false),
                    DepreciationValue = table.Column<float>(nullable: false),
                    DepreciationRate = table.Column<float>(nullable: false),
                    RemainingDepMonths = table.Column<int>(nullable: false),
                    DepreciationStatus = table.Column<string>(nullable: true),
                    RemainingDepValue = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OriginalPrice = table.Column<float>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    PurchaseOderId = table.Column<string>(nullable: true),
                    AssetDetailId = table.Column<string>(nullable: true),
                    AssetGroupId = table.Column<string>(nullable: true),
                    WarrantyId = table.Column<string>(nullable: true),
                    LinkofImage = table.Column<string>(nullable: true),
                    AssetTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets_05", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets_05");
        }
    }
}
