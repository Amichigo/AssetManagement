using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class GoodsInvoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodsInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    PlanCode = table.Column<string>(nullable: true),
                    PlanName = table.Column<string>(nullable: true),
                    ContractName = table.Column<string>(nullable: true),
                    UnitName = table.Column<string>(nullable: true),
                    GoodsName = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    PaymentProcess = table.Column<string>(nullable: true),
                    ShippingProcess = table.Column<string>(nullable: true),
                    BillStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsInvoices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsInvoices");
        }
    }
}
