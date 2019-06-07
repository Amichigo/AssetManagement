using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class createa_Disposal_Plan_Detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisposalPlanDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaTS = table.Column<string>(nullable: true),
                    TenTS = table.Column<string>(nullable: true),
                    NguyenGia = table.Column<float>(nullable: false),
                    GiaTriConLai = table.Column<float>(nullable: false),
                    GiaDuKien = table.Column<float>(nullable: false),
                    TinhTrangTS = table.Column<string>(nullable: true),
                    HinhThuc = table.Column<string>(nullable: true),
                    ThangDuKien = table.Column<int>(nullable: false),
                    MaKeHoach = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisposalPlanDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisposalPlanDetails");
        }
    }
}
