using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Asset_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.CreateTable(
                name: "Assets_8",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaTaiSan = table.Column<string>(nullable: true),
                    MaNhomTaiSan = table.Column<string>(nullable: true),
                    MaLoaiTaiSan = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    TenTaiSan = table.Column<string>(nullable: true),
                    TinhTrangTaiSan = table.Column<string>(nullable: true),
                    NguyenGiaTaiSan = table.Column<float>(nullable: false),
                    GiaTinhKhauHao = table.Column<float>(nullable: false),
                    NgayNhapTaiSan = table.Column<string>(nullable: true),
                    NgayBatDauKhauHao = table.Column<string>(nullable: true),
                    NgayKetThucKhauHao = table.Column<string>(nullable: true),
                    KhauHao = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets_8", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets_8");

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    GiaTinhKhauHao = table.Column<float>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    KhauHao = table.Column<string>(nullable: true),
                    MaAsset = table.Column<string>(nullable: true),
                    MaLoaiAsset = table.Column<string>(nullable: true),
                    MaNhomAsset = table.Column<string>(nullable: true),
                    NgayBatDauKhauHao = table.Column<string>(nullable: true),
                    NgayKetThucKhauHao = table.Column<string>(nullable: true),
                    NgayNhapAsset = table.Column<string>(nullable: true),
                    NguyenGiaAsset = table.Column<float>(nullable: false),
                    TenAsset = table.Column<string>(nullable: true),
                    TinhTrangAsset = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });
        }
    }
}
