using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beredskap.Infrastructure.Migrations
{
    public partial class IncidentsInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "297af0a9-060d-4ac7-b014-e421588150a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e25dc514-9468-43a5-8099-d805243c08f6", "AQAAAAIAAYagAAAAEFbOF/DU5wwY/ArBBiUWX04hr/+3wEnlGnupCfoYZAQx1QJuTyYg09fFqi7cKb5RZQ==", "9a1d867c-b51a-434e-9c63-0b988e1c7e61" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "297af0a9-060d-4ac7-b014-e421588150a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c714f9a-890c-4919-97fc-53fd2d661094", "AQAAAAEAACcQAAAAEIEGR4n5S60zP4+AON1SKju6/tlP/sv3pUUutojaQM83v15bJtCxM8Njak388NN2qg==", "4dab1165-4c3c-42c5-9504-d10971398bfe" });
        }
    }
}
