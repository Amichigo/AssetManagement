using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class addTableKeHoachXayDungCoBanaddCongTrinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CongTrinh_N13",
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
                    MaKeHoach = table.Column<string>(nullable: true),
                    TenCongTrinh = table.Column<string>(nullable: true),
                    DuKienXayDung = table.Column<string>(nullable: true),
                    DuKienHoanThanh = table.Column<string>(nullable: true),
                    KinhPhiDeXuat = table.Column<float>(nullable: false),
                    KinhPhiTrinh = table.Column<float>(nullable: false),
                    KinhPhiDuocDuyet = table.Column<float>(nullable: false),
                    TienDoThucHien = table.Column<string>(nullable: true),
                    ChiPhiDaSuDung = table.Column<float>(nullable: false),
                    MaLoaiCongTrinh = table.Column<string>(nullable: true),
                    DiaChiCongTrinh = table.Column<string>(nullable: true),
                    DienTichCongTrinh = table.Column<float>(nullable: false),
                    MoTaCongTrinh = table.Column<string>(nullable: true),
                    NgayThiCongThucTe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongTrinh_N13", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeHoachXayDung_N13",
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
                    NamThucHien = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeHoachXayDung_N13", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CongTrinh_N13");

            migrationBuilder.DropTable(
                name: "KeHoachXayDung_N13");
        }
    }
}
