using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class N13addTableHopDongToTrinhBaoLanhHPBaoLanhBaoHanh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaoLanhBaoHanh_N13",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaHinhThucBaoLanh = table.Column<string>(nullable: true),
                    SoChungTuBaoLanh = table.Column<string>(nullable: true),
                    NganHangBaoLanh = table.Column<string>(nullable: true),
                    SoTienBaoLanh = table.Column<float>(nullable: false),
                    NgayHetHanChungTu = table.Column<string>(nullable: true),
                    MaHopDong = table.Column<string>(nullable: true),
                    FileDinhKem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoLanhBaoHanh_N13", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaoLanhHopDong_N13",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaHinhThucBaoLanh = table.Column<string>(nullable: true),
                    SoChungTuBaoLanh = table.Column<string>(nullable: true),
                    NganHangBaoLanh = table.Column<string>(nullable: true),
                    SoTienBaoLanh = table.Column<float>(nullable: false),
                    NgayHetHanChungTu = table.Column<string>(nullable: true),
                    MaHopDong = table.Column<string>(nullable: true),
                    FileDinhKem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoLanhHopDong_N13", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HopDong_N13",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaHopDong = table.Column<string>(nullable: true),
                    SoHopDong = table.Column<string>(nullable: true),
                    NoiDungHopDong = table.Column<string>(nullable: true),
                    TongGiaTriHopDong = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong_N13", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThanhToan_N13",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    NgayDuKienThanhToan = table.Column<string>(nullable: true),
                    SoTienThanhToan = table.Column<float>(nullable: false),
                    DaThanhToan = table.Column<float>(nullable: false),
                    NgayThanhToan = table.Column<float>(nullable: false),
                    NoiDungThanhToan = table.Column<string>(nullable: true),
                    MaHopDong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToan_N13", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToTrinh_N13",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    SoToTrinh = table.Column<string>(nullable: true),
                    NoiDungToTrinh = table.Column<string>(nullable: true),
                    NgayKy = table.Column<string>(nullable: true),
                    ChiPhiDuyet = table.Column<string>(nullable: true),
                    FileDinhKem = table.Column<string>(nullable: true),
                    MaHopDong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToTrinh_N13", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoLanhBaoHanh_N13");

            migrationBuilder.DropTable(
                name: "BaoLanhHopDong_N13");

            migrationBuilder.DropTable(
                name: "HopDong_N13");

            migrationBuilder.DropTable(
                name: "ThanhToan_N13");

            migrationBuilder.DropTable(
                name: "ToTrinh_N13");
        }
    }
}
