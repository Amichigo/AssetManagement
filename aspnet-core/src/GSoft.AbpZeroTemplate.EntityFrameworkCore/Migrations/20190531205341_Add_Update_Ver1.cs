using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Add_Update_Ver1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChiPhuSuaChua",
                table: "RealEstateRepairs_9",
                newName: "NoiDungSuaChuaThucTe");

            migrationBuilder.AddColumn<string>(
                name: "ChiPhuSuaChuaThucTe",
                table: "RealEstateRepairs_9",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonViSuaChuaThucTe",
                table: "RealEstateRepairs_9",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChuThucTe",
                table: "RealEstateRepairs_9",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NgaySuaChuaXong",
                table: "RealEstateRepairs_9",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BidManagers_9",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaHoSoThau = table.Column<string>(nullable: true),
                    HangMucThau = table.Column<string>(nullable: true),
                    NgayNhanHSThau = table.Column<string>(nullable: true),
                    NgayHetHanNopHSThau = table.Column<string>(nullable: true),
                    NgayMoThau = table.Column<string>(nullable: true),
                    HinhThucThau = table.Column<string>(nullable: true),
                    BaoLanhDuThau = table.Column<string>(nullable: true),
                    PhanTram = table.Column<string>(nullable: true),
                    NgayHetHanBaoLanh = table.Column<string>(nullable: true),
                    FileDinhKem = table.Column<string>(nullable: true),
                    MaCongTrinh = table.Column<string>(nullable: true),
                    MaDonViThau = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidManagers_9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Constructions_9",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaCongTrinh = table.Column<string>(nullable: true),
                    TenCongTrinh = table.Column<string>(nullable: true),
                    MaLoaiCongTrinh = table.Column<string>(nullable: true),
                    MaKeHoach = table.Column<string>(nullable: true),
                    DienTichCongTrinh = table.Column<string>(nullable: true),
                    ChiPhiCongTrinh = table.Column<string>(nullable: true),
                    NgayDuKienThucHien = table.Column<string>(nullable: true),
                    ThoiGianDuKienHT = table.Column<string>(nullable: true),
                    MoTaCongTrinh = table.Column<string>(nullable: true),
                    ChiPhiDaThucHien = table.Column<string>(nullable: true),
                    NgayThucThiThucTe = table.Column<string>(nullable: true),
                    NgayHoanThanh = table.Column<string>(nullable: true),
                    TienDo = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true),
                    DonViLapKeHoach = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constructions_9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractGuarantees_9",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaBaoLanhHopDong = table.Column<string>(nullable: true),
                    HinhThucBLHD = table.Column<string>(nullable: true),
                    SoChungTuBLHD = table.Column<string>(nullable: true),
                    NganHangBLHD = table.Column<string>(nullable: true),
                    SoTienBLHD = table.Column<string>(nullable: true),
                    SoTienVNDBLHD = table.Column<string>(nullable: true),
                    NgayHetHanBLHD = table.Column<string>(nullable: true),
                    DinhKemBLHD = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractGuarantees_9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractManagements_9",
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
                    TongGiaTriHopDong = table.Column<string>(nullable: true),
                    TienDongThiCong = table.Column<string>(nullable: true),
                    MaHoSoThau = table.Column<string>(nullable: true),
                    MaCongTrinh = table.Column<string>(nullable: true),
                    MaToTrinh = table.Column<string>(nullable: true),
                    MaBaoLanhHopDong = table.Column<string>(nullable: true),
                    MaBaoLanhBaoHanh = table.Column<string>(nullable: true),
                    TongTienDaThanhToan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractManagements_9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contractors_9",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaDonViThau = table.Column<string>(nullable: true),
                    TenDonViThau = table.Column<string>(nullable: true),
                    NgayNopHS = table.Column<string>(nullable: true),
                    GiaChaoThau = table.Column<string>(nullable: true),
                    HinhThuocBL = table.Column<string>(nullable: true),
                    SoChungThuSL = table.Column<string>(nullable: true),
                    TaiNganHang = table.Column<string>(nullable: true),
                    FileDinhKem = table.Column<string>(nullable: true),
                    TrungThau = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors_9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails_9",
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
                    SoTienThanhToan = table.Column<string>(nullable: true),
                    DaThanhToan = table.Column<string>(nullable: true),
                    NgayThanhToan = table.Column<string>(nullable: true),
                    NoiDungThanhToan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails_9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans_9",
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
                    MaDonVi = table.Column<string>(nullable: true),
                    NgayLapKeHoach = table.Column<string>(nullable: true),
                    TrangThaiDuyet = table.Column<string>(nullable: true),
                    NgayHieuLuc = table.Column<string>(nullable: true),
                    NamThucHien = table.Column<string>(nullable: true),
                    TongChiPhi = table.Column<string>(nullable: true),
                    TongChiPhiĐuocDuyet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans_9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyGuarantees_9",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaBaoLanhBaoHanh = table.Column<string>(nullable: true),
                    HinhThucBLBH = table.Column<string>(nullable: true),
                    SoChungTuBLBH = table.Column<string>(nullable: true),
                    NganHangBLBH = table.Column<string>(nullable: true),
                    SoTienBLBH = table.Column<string>(nullable: true),
                    SoTienVNDBLBH = table.Column<string>(nullable: true),
                    NgayHetHanBLBH = table.Column<string>(nullable: true),
                    DinhKemBLBH = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyGuarantees_9", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidManagers_9");

            migrationBuilder.DropTable(
                name: "Constructions_9");

            migrationBuilder.DropTable(
                name: "ContractGuarantees_9");

            migrationBuilder.DropTable(
                name: "ContractManagements_9");

            migrationBuilder.DropTable(
                name: "Contractors_9");

            migrationBuilder.DropTable(
                name: "PaymentDetails_9");

            migrationBuilder.DropTable(
                name: "Plans_9");

            migrationBuilder.DropTable(
                name: "WarrantyGuarantees_9");

            migrationBuilder.DropColumn(
                name: "ChiPhuSuaChuaThucTe",
                table: "RealEstateRepairs_9");

            migrationBuilder.DropColumn(
                name: "DonViSuaChuaThucTe",
                table: "RealEstateRepairs_9");

            migrationBuilder.DropColumn(
                name: "GhiChuThucTe",
                table: "RealEstateRepairs_9");

            migrationBuilder.DropColumn(
                name: "NgaySuaChuaXong",
                table: "RealEstateRepairs_9");

            migrationBuilder.RenameColumn(
                name: "NoiDungSuaChuaThucTe",
                table: "RealEstateRepairs_9",
                newName: "ChiPhuSuaChua");
        }
    }
}
