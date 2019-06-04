using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "LoaiNhaCungCaps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaLoaiNhaCungCap = table.Column<string>(nullable: true),
                    TenLoaiNhaCungCap = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiNhaCungCaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCapHangHoas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaNhaCungCap = table.Column<string>(nullable: true),
                    TenNhaCungCap = table.Column<string>(nullable: true),
                    MaLoaiNhaCungCap = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SoDienThoai = table.Column<string>(nullable: true),
                    NguoiLienHe = table.Column<string>(nullable: true),
                    HoatDong = table.Column<bool>(nullable: false),
                    GhiChu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCapHangHoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaLoaiSanPham = table.Column<string>(nullable: true),
                    TenLoaiSanPham = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaSanPham = table.Column<string>(nullable: true),
                    TenSanPham = table.Column<string>(nullable: true),
                    MaLoaiSanPham = table.Column<string>(nullable: true),
                    MaNhaCungCap = table.Column<string>(nullable: true),
                    GiaSanPham = table.Column<string>(nullable: true),
                    DonViTinh = table.Column<string>(nullable: true),
                    SoLuong = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoaiNhaCungCaps");

            migrationBuilder.DropTable(
                name: "NhaCungCapHangHoas");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "SanPhams");

    //        migrationBuilder.CreateTable(
    //            name: "Allcodes",
    //            columns: table => new
    //            {
    //                Id = table.Column<int>(nullable: false)
    //                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
    //                BRANCH_ID = table.Column<string>(nullable: true),
    //                CDNAME = table.Column<string>(nullable: true),
    //                CDTYPE = table.Column<string>(nullable: true),
    //                CDVAL = table.Column<string>(nullable: true),
    //                CONTENT = table.Column<string>(nullable: true),
    //                LSTODR = table.Column<int>(nullable: false)
    //            },
    //            constraints: table =>
    //            {
    //                table.PrimaryKey("PK_Allcodes", x => x.Id);
    //            });
    //        migrationBuilder.DropTable(
    //name: "Allcodes");

        }
    }
}
