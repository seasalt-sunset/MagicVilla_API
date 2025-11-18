using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLocalUserKeyToID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LocalUsers",
                table: "LocalUsers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LocalUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocalUsers",
                table: "LocalUsers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 21982387,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 8, 30, 15, 701, DateTimeKind.Utc).AddTicks(4990));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 45897235,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 8, 30, 15, 701, DateTimeKind.Utc).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 65472345,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 8, 30, 15, 701, DateTimeKind.Utc).AddTicks(4983));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 67234783,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 8, 30, 15, 701, DateTimeKind.Utc).AddTicks(4988));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1155664488,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 8, 30, 15, 701, DateTimeKind.Utc).AddTicks(4992));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 8, 30, 15, 701, DateTimeKind.Utc).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 8, 30, 15, 701, DateTimeKind.Utc).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 8, 30, 15, 701, DateTimeKind.Utc).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 8, 30, 15, 701, DateTimeKind.Utc).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 18, 8, 30, 15, 701, DateTimeKind.Utc).AddTicks(4899));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LocalUsers",
                table: "LocalUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LocalUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocalUsers",
                table: "LocalUsers",
                column: "UserName");

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
    }
}
