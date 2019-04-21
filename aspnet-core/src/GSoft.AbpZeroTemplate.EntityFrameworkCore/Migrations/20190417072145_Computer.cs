using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class Computer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelDemos");

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Domain1 = table.Column<string>(nullable: true),
                    DNSHostName = table.Column<string>(nullable: true),
                    Cpuname = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Ram1Manufacturer = table.Column<string>(nullable: true),
                    Ram1PartNumber = table.Column<string>(nullable: true),
                    Ram1Total = table.Column<string>(nullable: true),
                    Ram2Manufacturer = table.Column<string>(nullable: true),
                    Ram2PartNumber = table.Column<string>(nullable: true),
                    Ram2Total = table.Column<string>(nullable: true),
                    MonitorType = table.Column<string>(nullable: true),
                    HDD1Type = table.Column<string>(nullable: true),
                    HDD1Size = table.Column<string>(nullable: true),
                    HDD2Type = table.Column<string>(nullable: true),
                    HDD2Size = table.Column<string>(nullable: true),
                    OS = table.Column<string>(nullable: true),
                    OSA = table.Column<string>(nullable: true),
                    LocalIp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");

        }
    }
}
