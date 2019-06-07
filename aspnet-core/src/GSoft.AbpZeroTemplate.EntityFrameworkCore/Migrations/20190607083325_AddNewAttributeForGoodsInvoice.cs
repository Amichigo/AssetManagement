using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class AddNewAttributeForGoodsInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "GoodsInvoices",
                newName: "UnitCode");

            migrationBuilder.RenameColumn(
                name: "PlanName",
                table: "GoodsInvoices",
                newName: "UnitAddress");

            migrationBuilder.RenameColumn(
                name: "PlanCode",
                table: "GoodsInvoices",
                newName: "TotalPriceContractPayment");

            migrationBuilder.RenameColumn(
                name: "GoodsName",
                table: "GoodsInvoices",
                newName: "TotalPriceContract");

            migrationBuilder.RenameColumn(
                name: "ContractName",
                table: "GoodsInvoices",
                newName: "ReportReceiveDate");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "GoodsInvoices",
                newName: "ReportNumber");

            migrationBuilder.AddColumn<string>(
                name: "ContractCode",
                table: "GoodsInvoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractContent",
                table: "GoodsInvoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POCode",
                table: "GoodsInvoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PODate",
                table: "GoodsInvoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "POName",
                table: "GoodsInvoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportConfirmDate",
                table: "GoodsInvoices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractCode",
                table: "GoodsInvoices");

            migrationBuilder.DropColumn(
                name: "ContractContent",
                table: "GoodsInvoices");

            migrationBuilder.DropColumn(
                name: "POCode",
                table: "GoodsInvoices");

            migrationBuilder.DropColumn(
                name: "PODate",
                table: "GoodsInvoices");

            migrationBuilder.DropColumn(
                name: "POName",
                table: "GoodsInvoices");

            migrationBuilder.DropColumn(
                name: "ReportConfirmDate",
                table: "GoodsInvoices");

            migrationBuilder.RenameColumn(
                name: "UnitCode",
                table: "GoodsInvoices",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "UnitAddress",
                table: "GoodsInvoices",
                newName: "PlanName");

            migrationBuilder.RenameColumn(
                name: "TotalPriceContractPayment",
                table: "GoodsInvoices",
                newName: "PlanCode");

            migrationBuilder.RenameColumn(
                name: "TotalPriceContract",
                table: "GoodsInvoices",
                newName: "GoodsName");

            migrationBuilder.RenameColumn(
                name: "ReportReceiveDate",
                table: "GoodsInvoices",
                newName: "ContractName");

            migrationBuilder.RenameColumn(
                name: "ReportNumber",
                table: "GoodsInvoices",
                newName: "Amount");
        }
    }
}
