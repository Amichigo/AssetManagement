using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Group6UpdateMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintainedAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    AssetTypeId = table.Column<string>(nullable: true),
                    AssetTypeName = table.Column<string>(nullable: true),
                    RecordedDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintainedAssets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperatingAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    AssetTypeId = table.Column<string>(nullable: true),
                    AssetTypeName = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    DepreciatedAmount = table.Column<double>(nullable: false),
                    DepreciatedQuantity = table.Column<double>(nullable: false),
                    RecordedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingAssets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlannedToMaintainAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    AssetTypeId = table.Column<string>(nullable: true),
                    AssetTypeName = table.Column<string>(nullable: true),
                    RecordedDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedToMaintainAssets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlannedToPurchaseAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    AssetTypeId = table.Column<string>(nullable: true),
                    AssetTypeName = table.Column<string>(nullable: true),
                    RecordedDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedToPurchaseAssets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlannedToSellAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    AssetTypeId = table.Column<string>(nullable: true),
                    AssetTypeName = table.Column<string>(nullable: true),
                    RecordedDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedToSellAssets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchasedAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    AssetTypeId = table.Column<string>(nullable: true),
                    AssetTypeName = table.Column<string>(nullable: true),
                    RecordedDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedAssets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoldAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    AssetTypeId = table.Column<string>(nullable: true),
                    AssetTypeName = table.Column<string>(nullable: true),
                    RecordedDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Quantity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldAssets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintainedAssets");

            migrationBuilder.DropTable(
                name: "OperatingAssets");

            migrationBuilder.DropTable(
                name: "PlannedToMaintainAssets");

            migrationBuilder.DropTable(
                name: "PlannedToPurchaseAssets");

            migrationBuilder.DropTable(
                name: "PlannedToSellAssets");

            migrationBuilder.DropTable(
                name: "PurchasedAssets");

            migrationBuilder.DropTable(
                name: "SoldAssets");
        }
    }
}
