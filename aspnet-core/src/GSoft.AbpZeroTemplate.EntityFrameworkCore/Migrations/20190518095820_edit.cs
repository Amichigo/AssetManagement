using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetDetails_05",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetDetailId = table.Column<int>(nullable: false),
                    LiquidationId = table.Column<int>(nullable: false),
                    UsingProcessId = table.Column<int>(nullable: false),
                    RepairId = table.Column<int>(nullable: false),
                    DepreciationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDetails_05", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetGroups_05",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AssetTypeId = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    FatherAssetGroup = table.Column<string>(nullable: true),
                    MonthsDepreciation = table.Column<int>(nullable: false),
                    DepreciationRates = table.Column<float>(nullable: false),
                    AssetAccount = table.Column<string>(nullable: true),
                    DepreciationAccount = table.Column<string>(nullable: true),
                    CostAccount = table.Column<string>(nullable: true),
                    IncomeAccount = table.Column<string>(nullable: true),
                    LiquidationCostAccount = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetGroups_05", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets_05",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
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
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets_05", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetTypes_05",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTypes_05", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepreciationDetails_05",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AmountOfMoney = table.Column<float>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepreciationDetails_05", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Depreciations_05",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TotalMonthDepreciation = table.Column<int>(nullable: false),
                    DepreciationValue = table.Column<float>(nullable: false),
                    DepreciationRate = table.Column<float>(nullable: false),
                    RemainingDepMonths = table.Column<int>(nullable: false),
                    DepreciationStatus = table.Column<string>(nullable: true),
                    RemainingDepValue = table.Column<float>(nullable: false),
                    DepreciationDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depreciations_05", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiquidationDetails_05",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RemainingDepreciationValue = table.Column<float>(nullable: false),
                    LiquidationPrice = table.Column<float>(nullable: false),
                    FormLiquidation = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidationDetails_05", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Liquidations_05",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LiquidationDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquidations_05", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepairDetails_05",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InterpretationContent = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    AmountOfMoney = table.Column<float>(nullable: false),
                    RepairDate = table.Column<DateTime>(nullable: false),
                    RepairUnit = table.Column<string>(nullable: true),
                    RepairDetail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairDetails_05", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsingProcessDetail_05",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UseDate = table.Column<DateTime>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsingProcessDetail_05", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyDetails_05",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Warrantyperiod = table.Column<float>(nullable: false),
                    WarrantyDate = table.Column<DateTime>(nullable: false),
                    InterpretationContent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyDetails_05", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warrantys_05",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WarrantyDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warrantys_05", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repairs_05",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetDetailId = table.Column<int>(nullable: false),
                    RepairDetail_05Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs_05", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_05_RepairDetails_05_RepairDetail_05Id",
                        column: x => x.RepairDetail_05Id,
                        principalTable: "RepairDetails_05",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsingProcess_05",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetDetailId = table.Column<int>(nullable: false),
                    UsingProcessDetail_05Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsingProcess_05", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsingProcess_05_UsingProcessDetail_05_UsingProcessDetail_05Id",
                        column: x => x.UsingProcessDetail_05Id,
                        principalTable: "UsingProcessDetail_05",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_05_RepairDetail_05Id",
                table: "Repairs_05",
                column: "RepairDetail_05Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsingProcess_05_UsingProcessDetail_05Id",
                table: "UsingProcess_05",
                column: "UsingProcessDetail_05Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetDetails_05");

            migrationBuilder.DropTable(
                name: "AssetGroups_05");

            migrationBuilder.DropTable(
                name: "Assets_05");

            migrationBuilder.DropTable(
                name: "AssetTypes_05");

            migrationBuilder.DropTable(
                name: "DepreciationDetails_05");

            migrationBuilder.DropTable(
                name: "Depreciations_05");

            migrationBuilder.DropTable(
                name: "LiquidationDetails_05");

            migrationBuilder.DropTable(
                name: "Liquidations_05");

            migrationBuilder.DropTable(
                name: "Repairs_05");

            migrationBuilder.DropTable(
                name: "UsingProcess_05");

            migrationBuilder.DropTable(
                name: "WarrantyDetails_05");

            migrationBuilder.DropTable(
                name: "Warrantys_05");

            migrationBuilder.DropTable(
                name: "RepairDetails_05");

            migrationBuilder.DropTable(
                name: "UsingProcessDetail_05");
        }
    }
}
