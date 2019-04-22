using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class PhieuGoiHang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuGoiHang",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaKeHoach = table.Column<string>(nullable: true),
                    TenKeHoach = table.Column<string>(nullable: true),
                    TenHopDong = table.Column<string>(nullable: true),
                    TenDonVi = table.Column<string>(nullable: true),
                    TenHangHoa = table.Column<string>(nullable: true),
                    SoLuong = table.Column<string>(nullable: true),
                    DonGia = table.Column<string>(nullable: true),
                    QuaTrinhThanhToan = table.Column<string>(nullable: true),
                    TienDoGiaoHang = table.Column<string>(nullable: true),
                    TinhTrangHoaDon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuGoiHang", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuGoiHang");
        }
    }
}
