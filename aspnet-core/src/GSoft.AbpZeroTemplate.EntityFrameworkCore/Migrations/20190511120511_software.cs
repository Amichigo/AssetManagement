using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSoft.AbpZeroTemplate.Migrations
{
    public partial class software : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Softwares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Cpuname = table.Column<string>(nullable: true),
                    Displayname = table.Column<string>(nullable: true),
                    DisplayVersion = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    Installdate = table.Column<string>(nullable: false),
                    InstallLocation = table.Column<string>(nullable: true),
                    InstallSource = table.Column<string>(nullable: true),
                    URLInfoAbout = table.Column<string>(nullable: true),
                    URLUpdateInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softwares", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Softwares");
        }
    }
}
