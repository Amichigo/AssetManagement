using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class fixAssetDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaNhomTaiSan",
                table: "TaiSan",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "MaLoaiTaiSan",
                table: "TaiSan",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "MaTaiSan",
                table: "TaiSan",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaTinhTrangXayDung",
                table: "BatDongSans",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "MaTinhTrangSuDungDat",
                table: "BatDongSans",
                nullable: true,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaTaiSan",
                table: "TaiSan");

            migrationBuilder.AlterColumn<int>(
                name: "MaNhomTaiSan",
                table: "TaiSan",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaLoaiTaiSan",
                table: "TaiSan",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "MaTinhTrangXayDung",
                table: "BatDongSans",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "MaTinhTrangSuDungDat",
                table: "BatDongSans",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
