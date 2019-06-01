using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class FixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TinhTranKhauHao",
                table: "RealEstates_9",
                newName: "TinhTrangPhapLy");

            migrationBuilder.RenameColumn(
                name: "MaHienTrangPhapLy",
                table: "RealEstates_9",
                newName: "TinhTrangKhauHao");

            migrationBuilder.RenameColumn(
                name: "MaDiaDiem",
                table: "RealEstates_9",
                newName: "SoThangKhauHao");

            migrationBuilder.RenameColumn(
                name: "LoaiSoHuu",
                table: "RealEstates_9",
                newName: "NguonGocTaiSan");

            migrationBuilder.RenameColumn(
                name: "GhiChu",
                table: "RealEstates_9",
                newName: "NgayKTKhauHao");

            migrationBuilder.RenameColumn(
                name: "DiaChi",
                table: "RealEstates_9",
                newName: "NgayBDKhauHao");

            migrationBuilder.RenameColumn(
                name: "CongNangSuDung",
                table: "RealEstates_9",
                newName: "GiaTriKhauHaoConLai");

            migrationBuilder.RenameColumn(
                name: "ChuSoHuu",
                table: "RealEstates_9",
                newName: "GiaTriKhauHao");

            migrationBuilder.RenameColumn(
                name: "PhongGiaoDich",
                table: "RealEstateRepairs_9",
                newName: "TrangThaiDuyet");

            migrationBuilder.RenameColumn(
                name: "NgaySuaChua",
                table: "RealEstateRepairs_9",
                newName: "NoiDungSuaChua");

            migrationBuilder.RenameColumn(
                name: "MaDonVi",
                table: "RealEstateRepairs_9",
                newName: "NhanVienPhuTrach");

            migrationBuilder.RenameColumn(
                name: "MaBatDongSan",
                table: "RealEstateRepairs_9",
                newName: "NguoiDeXuat");

            migrationBuilder.RenameColumn(
                name: "KhuVuc",
                table: "RealEstateRepairs_9",
                newName: "MaTaiSan");

            migrationBuilder.RenameColumn(
                name: "ChiPhiSua",
                table: "RealEstateRepairs_9",
                newName: "GhiChu");

            migrationBuilder.AddColumn<string>(
                name: "FileDinhKem",
                table: "RealEstates_9",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChiPhiDuKien",
                table: "RealEstateRepairs_9",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonViDeXuat",
                table: "RealEstateRepairs_9",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonViSuaChua",
                table: "RealEstateRepairs_9",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileDinhKem",
                table: "RealEstates_9");

            migrationBuilder.DropColumn(
                name: "ChiPhiDuKien",
                table: "RealEstateRepairs_9");

            migrationBuilder.DropColumn(
                name: "DonViDeXuat",
                table: "RealEstateRepairs_9");

            migrationBuilder.DropColumn(
                name: "DonViSuaChua",
                table: "RealEstateRepairs_9");

            migrationBuilder.RenameColumn(
                name: "TinhTrangPhapLy",
                table: "RealEstates_9",
                newName: "TinhTranKhauHao");

            migrationBuilder.RenameColumn(
                name: "TinhTrangKhauHao",
                table: "RealEstates_9",
                newName: "MaHienTrangPhapLy");

            migrationBuilder.RenameColumn(
                name: "SoThangKhauHao",
                table: "RealEstates_9",
                newName: "MaDiaDiem");

            migrationBuilder.RenameColumn(
                name: "NguonGocTaiSan",
                table: "RealEstates_9",
                newName: "LoaiSoHuu");

            migrationBuilder.RenameColumn(
                name: "NgayKTKhauHao",
                table: "RealEstates_9",
                newName: "GhiChu");

            migrationBuilder.RenameColumn(
                name: "NgayBDKhauHao",
                table: "RealEstates_9",
                newName: "DiaChi");

            migrationBuilder.RenameColumn(
                name: "GiaTriKhauHaoConLai",
                table: "RealEstates_9",
                newName: "CongNangSuDung");

            migrationBuilder.RenameColumn(
                name: "GiaTriKhauHao",
                table: "RealEstates_9",
                newName: "ChuSoHuu");

            migrationBuilder.RenameColumn(
                name: "TrangThaiDuyet",
                table: "RealEstateRepairs_9",
                newName: "PhongGiaoDich");

            migrationBuilder.RenameColumn(
                name: "NoiDungSuaChua",
                table: "RealEstateRepairs_9",
                newName: "NgaySuaChua");

            migrationBuilder.RenameColumn(
                name: "NhanVienPhuTrach",
                table: "RealEstateRepairs_9",
                newName: "MaDonVi");

            migrationBuilder.RenameColumn(
                name: "NguoiDeXuat",
                table: "RealEstateRepairs_9",
                newName: "MaBatDongSan");

            migrationBuilder.RenameColumn(
                name: "MaTaiSan",
                table: "RealEstateRepairs_9",
                newName: "KhuVuc");

            migrationBuilder.RenameColumn(
                name: "GhiChu",
                table: "RealEstateRepairs_9",
                newName: "ChiPhiSua");
        }
    }
}
