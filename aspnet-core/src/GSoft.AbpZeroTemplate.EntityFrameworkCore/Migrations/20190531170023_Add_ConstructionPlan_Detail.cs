using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Add_ConstructionPlan_Detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConstructionPlanDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaCT = table.Column<string>(nullable: true),
                    TenCT = table.Column<string>(nullable: true),
                    DuKienXayDung = table.Column<string>(nullable: true),
                    DuKienHoanThanh = table.Column<string>(nullable: true),
                    ThoiGianThucHien = table.Column<string>(nullable: true),
                    KinhPhiDeXuat = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    MaKeHoach = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionPlanDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstructionPlanDetails");
        }
    }
}
