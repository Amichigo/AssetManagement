using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class updateColumnThanhToanN13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NgayThanhToan",
                table: "ThanhToan_N13",
                nullable: true,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "NgayThanhToan",
                table: "ThanhToan_N13",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
