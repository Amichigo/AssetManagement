using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class addTableHoSoThauDonViThau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonViThau_N13",
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
                    MaGoiThau = table.Column<string>(nullable: true),
                    TenDonViThamGiaThau = table.Column<string>(nullable: true),
                    NgayNopHoSoThau = table.Column<string>(nullable: true),
                    GiaChaoThau = table.Column<string>(nullable: true),
                    HinhThucBaoLanh = table.Column<string>(nullable: true),
                    SoChungThuBaoLanh = table.Column<string>(nullable: true),
                    TaiNganHang = table.Column<string>(nullable: true),
                    IsTrungThau = table.Column<bool>(nullable: false),
                    FileDinhKem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViThau_N13", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoSoThau_N13",
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
                    MaCongTrinh = table.Column<string>(nullable: true),
                    TenHoSoThau = table.Column<string>(nullable: true),
                    HangMucThau = table.Column<string>(nullable: true),
                    NgayNhapHoSoThau = table.Column<string>(nullable: true),
                    NgayHetHanNopHoSoThau = table.Column<string>(nullable: true),
                    NgayMoThau = table.Column<string>(nullable: true),
                    MaHinhThucThau = table.Column<string>(nullable: true),
                    BaoLanhDuThauBD = table.Column<float>(nullable: false),
                    BaoLanhDuThauKT = table.Column<float>(nullable: false),
                    NgayHetHanBaoLanh = table.Column<string>(nullable: true),
                    FileDinhKem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoThau_N13", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonViThau_N13");

            migrationBuilder.DropTable(
                name: "HoSoThau_N13");
        }
    }
}
