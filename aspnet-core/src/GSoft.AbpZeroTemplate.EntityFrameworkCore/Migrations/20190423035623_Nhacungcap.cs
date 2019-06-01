using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Nhacungcap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhaCungCapHangHoas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhaCungCapHangHoas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    GhiChu = table.Column<string>(nullable: true),
                    HoatDong = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaLoaiNhaCungCap = table.Column<string>(nullable: true),
                    MaNhaCungCap = table.Column<string>(nullable: true),
                    NguoiLienHe = table.Column<string>(nullable: true),
                    SoDienThoai = table.Column<string>(nullable: true),
                    TenNhaCungCap = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCapHangHoas", x => x.Id);
                });
        }
    }
}
