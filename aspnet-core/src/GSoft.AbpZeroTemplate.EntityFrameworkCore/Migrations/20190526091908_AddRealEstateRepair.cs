using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class AddRealEstateRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NgayMuaBatDongSan",
                table: "RealEstates_9",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RealEstateRepairs_9",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    MaBatDongSan = table.Column<string>(nullable: true),
                    NgayDeXuat = table.Column<string>(nullable: true),
                    NgaySuaChua = table.Column<string>(nullable: true),
                    NgayDuKienSuaXong = table.Column<string>(nullable: true),
                    KhuVuc = table.Column<string>(nullable: true),
                    MaDonVi = table.Column<string>(nullable: true),
                    PhongGiaoDich = table.Column<string>(nullable: true),
                    ChiPhiSua = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateRepairs_9", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstateRepairs_9");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayMuaBatDongSan",
                table: "RealEstates_9",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
