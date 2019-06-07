using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Nhom_07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FixedAssets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FixedAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetTag = table.Column<int>(nullable: false),
                    Categocy = table.Column<string>(nullable: true),
                    Cost = table.Column<float>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DepreciationValue = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    LinkofImage = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OperatingCosts = table.Column<float>(nullable: false),
                    PONumber = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PurchaseFrom = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    TypeofAsset = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedAssets", x => x.Id);
                });
        }
    }
}
