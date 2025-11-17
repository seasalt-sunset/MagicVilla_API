using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateLocalUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.UserName);
                });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 21982387,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 15, 49, 41, 720, DateTimeKind.Utc).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 45897235,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 15, 49, 41, 720, DateTimeKind.Utc).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 65472345,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 15, 49, 41, 720, DateTimeKind.Utc).AddTicks(2321));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 67234783,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 15, 49, 41, 720, DateTimeKind.Utc).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1155664488,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 15, 49, 41, 720, DateTimeKind.Utc).AddTicks(2331));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 15, 49, 41, 720, DateTimeKind.Utc).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 15, 49, 41, 720, DateTimeKind.Utc).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 15, 49, 41, 720, DateTimeKind.Utc).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 15, 49, 41, 720, DateTimeKind.Utc).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 15, 49, 41, 720, DateTimeKind.Utc).AddTicks(2235));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 21982387,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 45897235,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5466));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 65472345,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 67234783,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1155664488,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5472));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5331));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5386));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5392));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5395));
        }
    }
}
