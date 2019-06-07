using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class AddNewField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractBank",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractConfirmNumber",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractExpire",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractForm",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractPrice",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractRatio",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuaranteeBank",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuaranteeConfirmNumber",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuaranteeExpire",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuaranteeForm",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuaranteePrice",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuaranteeRatio",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalPrice",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalPricePay",
                table: "Contracts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContractPayments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    ContractPaymentCode = table.Column<string>(nullable: true),
                    TimePayment = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<string>(nullable: true),
                    Ratio = table.Column<string>(nullable: true),
                    Money = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ContractCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractPayments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ContractBank",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ContractConfirmNumber",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ContractExpire",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ContractForm",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ContractPrice",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ContractRatio",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "GuaranteeBank",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "GuaranteeConfirmNumber",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "GuaranteeExpire",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "GuaranteeForm",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "GuaranteePrice",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "GuaranteeRatio",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "TotalPricePay",
                table: "Contracts");
        }
    }
}
