using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "SqrMeters", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Cucina, bagno, divano, Guspini, Lycamobile, Senigallia, Mandolini, contenziosi, Bullitta, mostarda, Lerdammer, Final Fantasy XV, Morra cinese 2", new DateTime(2025, 11, 10, 11, 40, 39, 601, DateTimeKind.Utc).AddTicks(7368), "Ecce ego, ecce vere ego ipse adsum, amici! Ite, aperiamus. Videamus quid in hac capsa sit, quis sit rex cereali. Bene inquadra, bene inquadra, quia non videtur.\r\n\r\nErgo… Super Mario, Super Mario, quis habet? Tu non. Isti? Uh, legere vix possum… ah ah!\r\nEt videamus—uh, rice krispies caerulei et rubei. Quis habet? Nemo, amici. Isti cum leone? Nemo. Isti? Cheerios cinnamomi. Nemo. O Deus! Lucky Charme. Nemo, amici. Ecce alter! O meum Deum!\r\n\r\nMagnum mercatum fecimus, comparema. Ecce hic! Donuts?! Uh, donuts, ita! Oreo aurea forma familiae, ita! “Novum” scriptum est, ahah! O meum Deum, chips ahoy… Amici, rex cereali, rex cereali!\r\n\r\nNon possum desinere, quia adsunt etiam illi Dora Exploratricis! Non credo, non credo—etiam illi Dorae! Grex, magne comparema, magnae nuntiae! Skuu!", "https://www.startpage.com/av/proxy-image?piurl=https%3A%2F%2Fi.ytimg.com%2Fvi%2FKUzORBTuIF4%2Fmaxresdefault.jpg&sp=1762773241T20f5a809ef08e73392b8810aa4df87b204e24a89472826ba586cc256bcddd862", "Gleriona", 5, 250000.98999999999, 400, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Cucina, bagno, divano, Guspini, Lycamobile, Senigallia, Mandolini, contenziosi, Bullitta, mostarda, Lerdammer, Final Fantasy XV, Morra cinese 2", new DateTime(2025, 11, 10, 11, 40, 39, 601, DateTimeKind.Utc).AddTicks(7450), "Ecce ego, ecce vere ego ipse adsum, amici! Ite, aperiamus. Videamus quid in hac capsa sit, quis sit rex cereali. Bene inquadra, bene inquadra, quia non videtur.\r\n\r\nErgo… Super Mario, Super Mario, quis habet? Tu non. Isti? Uh, legere vix possum… ah ah!\r\nEt videamus—uh, rice krispies caerulei et rubei. Quis habet? Nemo, amici. Isti cum leone? Nemo. Isti? Cheerios cinnamomi. Nemo. O Deus! Lucky Charme. Nemo, amici. Ecce alter! O meum Deum!\r\n\r\nMagnum mercatum fecimus, comparema. Ecce hic! Donuts?! Uh, donuts, ita! Oreo aurea forma familiae, ita! “Novum” scriptum est, ahah! O meum Deum, chips ahoy… Amici, rex cereali, rex cereali!\r\n\r\nNon possum desinere, quia adsunt etiam illi Dora Exploratricis! Non credo, non credo—etiam illi Dorae! Grex, magne comparema, magnae nuntiae! Skuu!", "https://i.redd.it/4t1tkl6hq13d1.jpeg", "Super Mesa Boogie", 120, 6000000.9900000002, 5500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Cucina, bagno, divano, Guspini, Lycamobile, Senigallia, Mandolini, contenziosi, Bullitta, mostarda, Lerdammer, Final Fantasy XV, Morra cinese 2", new DateTime(2025, 11, 10, 11, 40, 39, 601, DateTimeKind.Utc).AddTicks(7455), "Ecce ego, ecce vere ego ipse adsum, amici! Ite, aperiamus. Videamus quid in hac capsa sit, quis sit rex cereali. Bene inquadra, bene inquadra, quia non videtur.\r\n\r\nErgo… Super Mario, Super Mario, quis habet? Tu non. Isti? Uh, legere vix possum… ah ah!\r\nEt videamus—uh, rice krispies caerulei et rubei. Quis habet? Nemo, amici. Isti cum leone? Nemo. Isti? Cheerios cinnamomi. Nemo. O Deus! Lucky Charme. Nemo, amici. Ecce alter! O meum Deum!\r\n\r\nMagnum mercatum fecimus, comparema. Ecce hic! Donuts?! Uh, donuts, ita! Oreo aurea forma familiae, ita! “Novum” scriptum est, ahah! O meum Deum, chips ahoy… Amici, rex cereali, rex cereali!\r\n\r\nNon possum desinere, quia adsunt etiam illi Dora Exploratricis! Non credo, non credo—etiam illi Dorae! Grex, magne comparema, magnae nuntiae! Skuu!", "https://i.redd.it/4t1tkl6hq13d1.jpeg", "Mimmo Ultra Instinct", 0, 1.99, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Città, prato e altre cose", new DateTime(2025, 11, 10, 11, 40, 39, 601, DateTimeKind.Utc).AddTicks(7460), "Sondrio", "https://it.wikipedia.org/wiki/Sondrio#/media/File:Sondrio_panorama.jpg", "Sondrio", 21504, 2.0, 20880, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Cucina, bagno, divano, Guspini, Lycamobile, Senigallia, Mandolini, contenziosi, Bullitta, mostarda, Lerdammer, Final Fantasy XV, Morra cinese 2", new DateTime(2025, 11, 10, 11, 40, 39, 601, DateTimeKind.Utc).AddTicks(7465), "Ecce ego, ecce vere ego ipse adsum, amici! Ite, aperiamus. Videamus quid in hac capsa sit, quis sit rex cereali. Bene inquadra, bene inquadra, quia non videtur.\r\n\r\nErgo… Super Mario, Super Mario, quis habet? Tu non. Isti? Uh, legere vix possum… ah ah!\r\nEt videamus—uh, rice krispies caerulei et rubei. Quis habet? Nemo, amici. Isti cum leone? Nemo. Isti? Cheerios cinnamomi. Nemo. O Deus! Lucky Charme. Nemo, amici. Ecce alter! O meum Deum!\r\n\r\nMagnum mercatum fecimus, comparema. Ecce hic! Donuts?! Uh, donuts, ita! Oreo aurea forma familiae, ita! “Novum” scriptum est, ahah! O meum Deum, chips ahoy… Amici, rex cereali, rex cereali!\r\n\r\nNon possum desinere, quia adsunt etiam illi Dora Exploratricis! Non credo, non credo—etiam illi Dorae! Grex, magne comparema, magnae nuntiae! Skuu!", "https://i.redd.it/4t1tkl6hq13d1.jpeg", "Sferionisdiolla", 3, 600000.0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
