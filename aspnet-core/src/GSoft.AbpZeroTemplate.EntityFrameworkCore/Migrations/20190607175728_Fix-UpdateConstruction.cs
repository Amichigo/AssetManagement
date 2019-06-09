using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class FixUpdateConstruction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChiPhiCongTrinh",
                table: "Constructions_9");

            migrationBuilder.AddColumn<int>(
                name: "ChiPhiDeXuat",
                table: "Constructions_9",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChiPhiDuocDuyet",
                table: "Constructions_9",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChiPhiTrinh",
                table: "Constructions_9",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NamThucHien",
                table: "Constructions_9",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChiPhiDeXuat",
                table: "Constructions_9");

            migrationBuilder.DropColumn(
                name: "ChiPhiDuocDuyet",
                table: "Constructions_9");

            migrationBuilder.DropColumn(
                name: "ChiPhiTrinh",
                table: "Constructions_9");

            migrationBuilder.DropColumn(
                name: "NamThucHien",
                table: "Constructions_9");

            migrationBuilder.AddColumn<string>(
                name: "ChiPhiCongTrinh",
                table: "Constructions_9",
                nullable: true);
        }
    }
}
