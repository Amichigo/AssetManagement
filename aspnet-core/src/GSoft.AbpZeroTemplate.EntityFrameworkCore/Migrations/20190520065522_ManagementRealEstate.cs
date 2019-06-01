using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class ManagementRealEstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelDemos");

            migrationBuilder.CreateTable(
                name: "Assets_Test9",
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
                    LoaiTaiSan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets_Test9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealEstates_9",
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
                    DiaChi = table.Column<string>(nullable: true),
                    TenTaiSan = table.Column<string>(nullable: true),
                    LoaiTaiSan = table.Column<string>(nullable: true),
                    NhomTaiSan = table.Column<string>(nullable: true),
                    ThongTin = table.Column<string>(nullable: true),
                    NguyenGia = table.Column<string>(nullable: true),
                    DonViSuDung = table.Column<string>(nullable: true),
                    NguoiSuDung = table.Column<string>(nullable: true),
                    TinhTrangTaiSan = table.Column<string>(nullable: true),
                    TinhTranKhauHao = table.Column<string>(nullable: true),
                    MaBatDongSan = table.Column<string>(nullable: true),
                    HienTrang = table.Column<string>(nullable: true),
                    MaLoaiBatDongSan = table.Column<string>(nullable: true),
                    ChieuDai = table.Column<float>(nullable: false),
                    ChieuRong = table.Column<float>(nullable: false),
                    DienTichDat = table.Column<float>(nullable: false),
                    NgayMuaBatDongSan = table.Column<string>(nullable: true),
                    ThoiHanSuDung = table.Column<string>(nullable: true),
                    TinhTrangSuDung = table.Column<string>(nullable: true),
                    CongNangSuDung = table.Column<string>(nullable: true),
                    RanhGioi = table.Column<string>(nullable: true),
                    MaHienTrangPhapLy = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    LoaiSoHuu = table.Column<string>(nullable: true),
                    ChuSoHuu = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    DienTichDatXayDung = table.Column<string>(nullable: true),
                    DienTichSan = table.Column<string>(nullable: true),
                    SoTang = table.Column<string>(nullable: true),
                    KetCauNha = table.Column<string>(nullable: true),
                    TinhTrangXayDung = table.Column<string>(nullable: true),
                    MucDichSuDung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates_9", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets_Test9");

            migrationBuilder.DropTable(
                name: "RealEstates_9");

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