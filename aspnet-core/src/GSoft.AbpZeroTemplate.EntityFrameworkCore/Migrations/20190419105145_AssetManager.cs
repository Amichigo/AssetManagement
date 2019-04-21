using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class AssetManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelDemos");

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
                    MaTaiSan = table.Column<string>(nullable: true),
                    LoaiTaiSan = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    MaBatDongSan = table.Column<string>(nullable: true),
                    LoaiBatDongSan = table.Column<string>(nullable: true),
                    NguyenGia = table.Column<int>(nullable: true),
                    TenDiaDiem = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    ChieuDai = table.Column<int>(nullable: true),
                    ChieuRong = table.Column<int>(nullable: true),
                    DienTichDat = table.Column<int>(nullable: true),
                    TinhTrangSuDung = table.Column<string>(nullable: true),
                    LoaiSoHuu = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    DienTichDatXayDung = table.Column<string>(nullable: true),
                    DienTichSan = table.Column<string>(nullable: true),
                    SoTang = table.Column<string>(nullable: true),
                    MucDichXayDung = table.Column<string>(nullable: true),
                    TienDoXayDung = table.Column<string>(nullable: true),
                    ThoiGianDuKienHoanThanh = table.Column<string>(nullable: true),
                    LoaiDat = table.Column<string>(nullable: true),
                    MucDichSuDung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Handovers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaPhieuNhan = table.Column<string>(nullable: true),
                    NgayBanGiao = table.Column<string>(nullable: true),
                    BoPhanBanGiao = table.Column<string>(nullable: true),
                    NhanVienBanGiao = table.Column<string>(nullable: true),
                    BoPhanNhanBanGiao = table.Column<string>(nullable: true),
                    LyDoNhanBDS = table.Column<string>(nullable: true),
                    MaBatDongSan = table.Column<string>(nullable: true),
                    LoaiBatDongSan = table.Column<string>(nullable: true),
                    TinhTrangBatDongSan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Handovers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revokes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaPhieuThu = table.Column<string>(nullable: true),
                    NgayThuHoi = table.Column<string>(nullable: true),
                    BoPhanThuHoi = table.Column<string>(nullable: true),
                    NhanVienThuHoi = table.Column<string>(nullable: true),
                    BoPhanBiThuHoi = table.Column<string>(nullable: true),
                    LyDoThuBDS = table.Column<string>(nullable: true),
                    MaBatDongSan = table.Column<string>(nullable: true),
                    LoaiBatDongSan = table.Column<string>(nullable: true),
                    TinhTrangBatDongSan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revokes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Handovers");

            migrationBuilder.DropTable(
                name: "Revokes");

            migrationBuilder.CreateTable(
                name: "ModelDemos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDemos", x => x.Id);
                });
        }
    }
}
