using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class updateBDSColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaiSans",
                table: "TaiSans");

            migrationBuilder.RenameTable(
                name: "TaiSans",
                newName: "TaiSan");

            migrationBuilder.AlterColumn<string>(
                name: "MaLoaiSoHuu",
                table: "BatDongSans",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "MaLoaiBDS",
                table: "BatDongSans",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "MaHienTrangPhapLy",
                table: "BatDongSans",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "BatDongSans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaBatDongSan",
                table: "BatDongSans",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaPhongGiaoDich",
                table: "BatDongSans",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaiSan",
                table: "TaiSan",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaiSan",
                table: "TaiSan");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "BatDongSans");

            migrationBuilder.DropColumn(
                name: "MaBatDongSan",
                table: "BatDongSans");

            migrationBuilder.DropColumn(
                name: "MaPhongGiaoDich",
                table: "BatDongSans");

            migrationBuilder.RenameTable(
                name: "TaiSan",
                newName: "TaiSans");

            migrationBuilder.AlterColumn<int>(
                name: "MaLoaiSoHuu",
                table: "BatDongSans",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaLoaiBDS",
                table: "BatDongSans",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaHienTrangPhapLy",
                table: "BatDongSans",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaiSans",
                table: "TaiSans",
                column: "Id");
        }
    }
}
