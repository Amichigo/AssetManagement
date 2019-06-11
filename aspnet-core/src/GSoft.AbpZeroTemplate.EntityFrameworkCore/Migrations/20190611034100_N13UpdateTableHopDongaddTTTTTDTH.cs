using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class N13UpdateTableHopDongaddTTTTTDTH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TienDoThucHien",
                table: "HopDong_N13",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TongTienThanhToan",
                table: "HopDong_N13",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TienDoThucHien",
                table: "HopDong_N13");

            migrationBuilder.DropColumn(
                name: "TongTienThanhToan",
                table: "HopDong_N13");
        }
    }
}
