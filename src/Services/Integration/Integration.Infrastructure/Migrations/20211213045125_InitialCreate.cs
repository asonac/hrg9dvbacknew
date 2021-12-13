using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Integration.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Integrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowName = table.Column<bool>(type: "bit", nullable: false),
                    ShowAge = table.Column<bool>(type: "bit", nullable: false),
                    ShowPhone = table.Column<bool>(type: "bit", nullable: false),
                    ShowEmailAddress = table.Column<bool>(type: "bit", nullable: false),
                    SendEmailToUser = table.Column<bool>(type: "bit", nullable: false),
                    EmailTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmailTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomEmailTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayloadShowName = table.Column<bool>(type: "bit", nullable: false),
                    PayloadShowAge = table.Column<bool>(type: "bit", nullable: false),
                    PayloadShowPhone = table.Column<bool>(type: "bit", nullable: false),
                    PayloadShowEmailAddress = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Integrations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Integrations");
        }
    }
}
