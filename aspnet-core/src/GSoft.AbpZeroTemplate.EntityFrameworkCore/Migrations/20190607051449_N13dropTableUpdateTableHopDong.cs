using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class N13dropTableUpdateTableHopDong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoLanhBaoHanh_N13");

            migrationBuilder.DropTable(
                name: "BaoLanhHopDong_N13");

            migrationBuilder.DropTable(
                name: "ToTrinh_N13");

            migrationBuilder.AddColumn<string>(
                name: "ChiPhiDuyetTT",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileDinhKemBH",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileDinhKemHD",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileDinhKemTT",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaHinhThucBaoLanhBH",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaHinhThucBaoLanhHD",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NganHangBaoLanhBH",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NganHangBaoLanhHD",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NgayHetHanChungTuBH",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NgayHetHanChungTuHD",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NgayKyTT",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiDungToTrinh",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoChungTuBaoLanhBH",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoChungTuBaoLanhHD",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SoTienBaoLanhBH",
                table: "HopDong_N13",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "SoTienBaoLanhHD",
                table: "HopDong_N13",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "SoToTrinh",
                table: "HopDong_N13",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChiPhiDuyetTT",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "FileDinhKemBH",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "FileDinhKemHD",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "FileDinhKemTT",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "MaHinhThucBaoLanhBH",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "MaHinhThucBaoLanhHD",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "NganHangBaoLanhBH",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "NganHangBaoLanhHD",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "NgayHetHanChungTuBH",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "NgayHetHanChungTuHD",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "NgayKyTT",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "NoiDungToTrinh",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "SoChungTuBaoLanhBH",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "SoChungTuBaoLanhHD",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "SoTienBaoLanhBH",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "SoTienBaoLanhHD",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "SoToTrinh",
                table: "HopDong_N13");

            migrationBuilder.CreateTable(
                name: "BaoLanhBaoHanh_N13",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    FileDinhKem = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaHinhThucBaoLanh = table.Column<string>(nullable: true),
                    MaHopDong = table.Column<string>(nullable: true),
                    NganHangBaoLanh = table.Column<string>(nullable: true),
                    NgayHetHanChungTu = table.Column<string>(nullable: true),
                    SoChungTuBaoLanh = table.Column<string>(nullable: true),
                    SoTienBaoLanh = table.Column<float>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoLanhBaoHanh_N13", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaoLanhHopDong_N13",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    FileDinhKem = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaHinhThucBaoLanh = table.Column<string>(nullable: true),
                    MaHopDong = table.Column<string>(nullable: true),
                    NganHangBaoLanh = table.Column<string>(nullable: true),
                    NgayHetHanChungTu = table.Column<string>(nullable: true),
                    SoChungTuBaoLanh = table.Column<string>(nullable: true),
                    SoTienBaoLanh = table.Column<float>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoLanhHopDong_N13", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToTrinh_N13",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChiPhiDuyet = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    FileDinhKem = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaHopDong = table.Column<string>(nullable: true),
                    NgayKy = table.Column<string>(nullable: true),
                    NoiDungToTrinh = table.Column<string>(nullable: true),
                    SoToTrinh = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToTrinh_N13", x => x.Id);
                });
        }
    }
}
