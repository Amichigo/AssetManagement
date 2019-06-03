using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class addAssetAndRealEstaseDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatDongSans",
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
                    HienTrangBDS = table.Column<string>(nullable: true),
                    MaLoaiBDS = table.Column<int>(nullable: false),
                    ChieuDai = table.Column<float>(nullable: false),
                    ChieuRong = table.Column<float>(nullable: false),
                    DienTichDatNen = table.Column<float>(nullable: false),
                    DienTichXayDung = table.Column<float>(nullable: false),
                    MaTinhTrangSuDungDat = table.Column<float>(nullable: false),
                    MaTinhTrangXayDung = table.Column<float>(nullable: false),
                    CongNangSuDung = table.Column<string>(nullable: true),
                    KetCauNha = table.Column<string>(nullable: true),
                    RanhGioi = table.Column<string>(nullable: true),
                    MaHienTrangPhapLy = table.Column<int>(nullable: false),
                    MaLoaiSoHuu = table.Column<int>(nullable: false),
                    ChuSoHuu = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    FileDinhKem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatDongSans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiayPhepSuDungs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ThoiHan = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiayPhepSuDungs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HienTrangPhapLys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HienTrangPhapLys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiBatDongSans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiBatDongSans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSoHuus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSoHuus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiTaiSans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiTaiSans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MucDinhSuDungDats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MucDinhSuDungDats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhomTaiSans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomTaiSans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiSans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    ThongTinMoTa = table.Column<string>(nullable: true),
                    MaLoaiTaiSan = table.Column<int>(nullable: false),
                    MaNhomTaiSan = table.Column<int>(nullable: false),
                    NguyenGiaTaiSan = table.Column<long>(nullable: false),
                    NguoiSuDung = table.Column<string>(nullable: true),
                    DonViSuDung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiSans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangSuDungDats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangSuDungDats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrangXayDungs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrangXayDungs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatDongSans");

            migrationBuilder.DropTable(
                name: "GiayPhepSuDungs");

            migrationBuilder.DropTable(
                name: "HienTrangPhapLys");

            migrationBuilder.DropTable(
                name: "LoaiBatDongSans");

            migrationBuilder.DropTable(
                name: "LoaiSoHuus");

            migrationBuilder.DropTable(
                name: "LoaiTaiSans");

            migrationBuilder.DropTable(
                name: "MucDinhSuDungDats");

            migrationBuilder.DropTable(
                name: "NhomTaiSans");

            migrationBuilder.DropTable(
                name: "TaiSans");

            migrationBuilder.DropTable(
                name: "TinhTrangSuDungDats");

            migrationBuilder.DropTable(
                name: "TinhTrangXayDungs");
        }
    }
}
