using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class addTableSuaChuaBatDongSan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuaChuaBatDongSans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaSuaChuaBatDongSan = table.Column<string>(nullable: true),
                    MaTaiSan = table.Column<string>(nullable: true),
                    NgayDeXuat = table.Column<string>(nullable: true),
                    NgayDuKienSuaXong = table.Column<string>(nullable: true),
                    ChiPhiDuKien = table.Column<float>(nullable: false),
                    DonViSuaChua = table.Column<string>(nullable: true),
                    DonViDeXuat = table.Column<string>(nullable: true),
                    NguoiDeXuat = table.Column<string>(nullable: true),
                    NhanVienPhuTrach = table.Column<string>(nullable: true),
                    NoiDungSuaChua = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    NgaySuaXong = table.Column<string>(nullable: true),
                    DonViSuaChuaThucTe = table.Column<string>(nullable: true),
                    ChiPhiSuaChuaThucTe = table.Column<string>(nullable: true),
                    NoiDungSuaChuaThucTe = table.Column<string>(nullable: true),
                    GhiChuThucTe = table.Column<string>(nullable: true),
                    ThayDoiCongNang = table.Column<bool>(nullable: false),
                    TrangThaiSuaChua = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuaChuaBatDongSans", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuaChuaBatDongSans");
        }
    }
}
