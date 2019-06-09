using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Add_TransferringAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransferringAsset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    TransferringDate = table.Column<DateTime>(nullable: true),
                    AssetId = table.Column<string>(nullable: true),
                    IsChecked = table.Column<bool>(nullable: false),
                    UsingUnit = table.Column<long>(nullable: false),
                    UsingUser = table.Column<long>(nullable: false),
                    ReceivingUnit = table.Column<long>(nullable: false),
                    ReceivingUser = table.Column<long>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    AttachingFileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferringAsset", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferringAsset");
        }
    }
}
