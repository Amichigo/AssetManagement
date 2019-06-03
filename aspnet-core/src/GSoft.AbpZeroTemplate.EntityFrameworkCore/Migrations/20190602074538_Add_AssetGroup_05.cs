using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Add_AssetGroup_05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetGroups_05",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    AssetGroupId = table.Column<string>(nullable: true),
                    SelectedId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AssetTypeId = table.Column<int>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    FatherAssetGroup = table.Column<string>(nullable: true),
                    MonthsDepreciation = table.Column<int>(nullable: false),
                    DepreciationRates = table.Column<float>(nullable: false),
                    AssetAccount = table.Column<string>(nullable: true),
                    DepreciationAccount = table.Column<string>(nullable: true),
                    CostAccount = table.Column<string>(nullable: true),
                    IncomeAccount = table.Column<string>(nullable: true),
                    LiquidationCostAccount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetGroups_05", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetGroups_05");
        }
    }
}
