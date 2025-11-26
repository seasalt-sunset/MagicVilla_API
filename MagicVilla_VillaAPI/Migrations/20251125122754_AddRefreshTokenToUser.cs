using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpireDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 21982387,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 25, 12, 27, 54, 135, DateTimeKind.Utc).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 45897235,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 25, 12, 27, 54, 135, DateTimeKind.Utc).AddTicks(5524));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 65472345,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 25, 12, 27, 54, 135, DateTimeKind.Utc).AddTicks(5521));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 67234783,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 25, 12, 27, 54, 135, DateTimeKind.Utc).AddTicks(5526));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1155664488,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 25, 12, 27, 54, 135, DateTimeKind.Utc).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 25, 12, 27, 54, 135, DateTimeKind.Utc).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 25, 12, 27, 54, 135, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 25, 12, 27, 54, 135, DateTimeKind.Utc).AddTicks(5415));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 25, 12, 27, 54, 135, DateTimeKind.Utc).AddTicks(5417));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 25, 12, 27, 54, 135, DateTimeKind.Utc).AddTicks(5420));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpireDate",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 21982387,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 21, 9, 10, 26, 41, DateTimeKind.Utc).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 45897235,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 21, 9, 10, 26, 41, DateTimeKind.Utc).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 65472345,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 21, 9, 10, 26, 41, DateTimeKind.Utc).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 67234783,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 21, 9, 10, 26, 41, DateTimeKind.Utc).AddTicks(6104));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1155664488,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 21, 9, 10, 26, 41, DateTimeKind.Utc).AddTicks(6109));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 21, 9, 10, 26, 41, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 21, 9, 10, 26, 41, DateTimeKind.Utc).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 21, 9, 10, 26, 41, DateTimeKind.Utc).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 21, 9, 10, 26, 41, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 21, 9, 10, 26, 41, DateTimeKind.Utc).AddTicks(6004));
        }
    }
}
