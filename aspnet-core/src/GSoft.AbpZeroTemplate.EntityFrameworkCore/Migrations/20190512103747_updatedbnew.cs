using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class updatedbnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoaiTaiSans");

            migrationBuilder.DropTable(
                name: "NhomTaiSans");

            migrationBuilder.DropTable(
                name: "TaiSan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiTaiSans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiTaiSans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhomTaiSans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomTaiSans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiSan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    DonViSuDung = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaLoaiTaiSan = table.Column<string>(nullable: true),
                    MaNhomTaiSan = table.Column<string>(nullable: true),
                    MaTaiSan = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NguoiSuDung = table.Column<string>(nullable: true),
                    NguyenGiaTaiSan = table.Column<long>(nullable: false),
                    ThongTinMoTa = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiSan", x => x.Id);
                });
        }
    }
}
