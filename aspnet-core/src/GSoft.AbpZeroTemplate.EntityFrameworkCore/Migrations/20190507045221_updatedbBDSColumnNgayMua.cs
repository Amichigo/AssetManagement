using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class updatedbBDSColumnNgayMua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NgayMuaBatDongSan",
                table: "BatDongSans",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayMuaBatDongSan",
                table: "BatDongSans",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
