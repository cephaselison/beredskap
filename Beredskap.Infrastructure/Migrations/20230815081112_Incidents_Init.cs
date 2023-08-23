using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beredskap.Infrastructure.Migrations
{
    public partial class Incidents_Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncidentStatus = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "297af0a9-060d-4ac7-b014-e421588150a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f1922c1-9c46-4026-ac8e-7d8359f3d7ce", "AQAAAAIAAYagAAAAEEUaV3pzi0DY3nDYF7ZGw9vXunBXfmSTZb0F+TG7OJcB75nCjHE6rU2ARw/orFSKWA==", "b41a4314-51e9-4746-8b08-e3ae66a7fbd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "297af0a9-060d-4ac7-b014-e421588150a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e25dc514-9468-43a5-8099-d805243c08f6", "AQAAAAIAAYagAAAAEFbOF/DU5wwY/ArBBiUWX04hr/+3wEnlGnupCfoYZAQx1QJuTyYg09fFqi7cKb5RZQ==", "9a1d867c-b51a-434e-9c63-0b988e1c7e61" });
        }
    }
}
