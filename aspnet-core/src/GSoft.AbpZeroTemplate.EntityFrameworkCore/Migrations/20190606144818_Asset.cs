using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Asset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    AssetName = table.Column<string>(nullable: true),
                    AssetCode = table.Column<string>(nullable: true),
                    AssetType = table.Column<string>(nullable: true),
                    AssetGroup = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AssetStatus = table.Column<string>(nullable: true),
                    AssetValue = table.Column<float>(nullable: false),
                    Supplier = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    LinkofImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
