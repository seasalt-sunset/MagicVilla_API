using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateForeignKeyVillaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaId",
                table: "VillaNumbers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 21982387,
                columns: new[] { "CreatedDate", "VillaId" },
                values: new object[] { new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5470), 2 });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 45897235,
                columns: new[] { "CreatedDate", "VillaId" },
                values: new object[] { new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5466), 4 });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 65472345,
                columns: new[] { "CreatedDate", "VillaId" },
                values: new object[] { new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5463), 5 });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 67234783,
                columns: new[] { "CreatedDate", "VillaId" },
                values: new object[] { new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5468), 3 });

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1155664488,
                columns: new[] { "CreatedDate", "VillaId" },
                values: new object[] { new DateTime(2025, 11, 14, 8, 6, 20, 727, DateTimeKind.Utc).AddTicks(5472), 1 });

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

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_Villas_VillaId",
                table: "VillaNumbers",
                column: "VillaId",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villas_VillaId",
                table: "VillaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers");

            migrationBuilder.DropColumn(
                name: "VillaId",
                table: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 21982387,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 12, 15, 45, 3, 506, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 45897235,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 12, 15, 45, 3, 506, DateTimeKind.Utc).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 65472345,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 12, 15, 45, 3, 506, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 67234783,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 12, 15, 45, 3, 506, DateTimeKind.Utc).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "VillaNumbers",
                keyColumn: "VillaNo",
                keyValue: 1155664488,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 12, 15, 45, 3, 506, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 12, 15, 45, 3, 506, DateTimeKind.Utc).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 12, 15, 45, 3, 506, DateTimeKind.Utc).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 12, 15, 45, 3, 506, DateTimeKind.Utc).AddTicks(1909));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 12, 15, 45, 3, 506, DateTimeKind.Utc).AddTicks(1912));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 11, 12, 15, 45, 3, 506, DateTimeKind.Utc).AddTicks(1915));
        }
    }
}
