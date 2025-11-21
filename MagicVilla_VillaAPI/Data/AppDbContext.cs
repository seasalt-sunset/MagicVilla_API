using MagicVilla_VillaAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Villa>(entity =>
            {
                entity.HasData(
                    new Villa
                    {
                        Id = 1,
                        Name = "Gleriona",
                        Details = "Ecce ego, ecce vere ego ipse adsum, amici! Ite, aperiamus. Videamus quid in hac capsa sit, quis sit rex cereali. Bene inquadra, bene inquadra, quia non videtur.\r\n\r\nErgo… Super Mario, Super Mario, quis habet? Tu non. Isti? Uh, legere vix possum… ah ah!\r\nEt videamus—uh, rice krispies caerulei et rubei. Quis habet? Nemo, amici. Isti cum leone? Nemo. Isti? Cheerios cinnamomi. Nemo. O Deus! Lucky Charme. Nemo, amici. Ecce alter! O meum Deum!\r\n\r\nMagnum mercatum fecimus, comparema. Ecce hic! Donuts?! Uh, donuts, ita! Oreo aurea forma familiae, ita! “Novum” scriptum est, ahah! O meum Deum, chips ahoy… Amici, rex cereali, rex cereali!\r\n\r\nNon possum desinere, quia adsunt etiam illi Dora Exploratricis! Non credo, non credo—etiam illi Dorae! Grex, magne comparema, magnae nuntiae! Skuu!",
                        Rate = 250000.99,
                        SqrMeters = 400,
                        Occupancy = 5,
                        ImageUrl = "https://www.startpage.com/av/proxy-image?piurl=https%3A%2F%2Fi.ytimg.com%2Fvi%2FKUzORBTuIF4%2Fmaxresdefault.jpg&sp=1762773241T20f5a809ef08e73392b8810aa4df87b204e24a89472826ba586cc256bcddd862",
                        Amenity = "Cucina, bagno, divano, Guspini, Lycamobile, Senigallia, Mandolini, contenziosi, Bullitta, mostarda, Lerdammer, Final Fantasy XV, Morra cinese 2",
                        CreatedDate = DateTime.Now.ToUniversalTime()
                    },

                    new Villa
                    {
                        Id = 2,
                        Name = "Super Mesa Boogie",
                        Details = "Ecce ego, ecce vere ego ipse adsum, amici! Ite, aperiamus. Videamus quid in hac capsa sit, quis sit rex cereali. Bene inquadra, bene inquadra, quia non videtur.\r\n\r\nErgo… Super Mario, Super Mario, quis habet? Tu non. Isti? Uh, legere vix possum… ah ah!\r\nEt videamus—uh, rice krispies caerulei et rubei. Quis habet? Nemo, amici. Isti cum leone? Nemo. Isti? Cheerios cinnamomi. Nemo. O Deus! Lucky Charme. Nemo, amici. Ecce alter! O meum Deum!\r\n\r\nMagnum mercatum fecimus, comparema. Ecce hic! Donuts?! Uh, donuts, ita! Oreo aurea forma familiae, ita! “Novum” scriptum est, ahah! O meum Deum, chips ahoy… Amici, rex cereali, rex cereali!\r\n\r\nNon possum desinere, quia adsunt etiam illi Dora Exploratricis! Non credo, non credo—etiam illi Dorae! Grex, magne comparema, magnae nuntiae! Skuu!",
                        Rate = 6000000.99,
                        SqrMeters = 5500,
                        Occupancy = 120,
                        ImageUrl = "https://i.redd.it/4t1tkl6hq13d1.jpeg",
                        Amenity = "Cucina, bagno, divano, Guspini, Lycamobile, Senigallia, Mandolini, contenziosi, Bullitta, mostarda, Lerdammer, Final Fantasy XV, Morra cinese 2",
                        CreatedDate = DateTime.Now.ToUniversalTime()
                    },

                    new Villa
                    {
                        Id = 3,
                        Name = "Mimmo Ultra Instinct",
                        Details = "Ecce ego, ecce vere ego ipse adsum, amici! Ite, aperiamus. Videamus quid in hac capsa sit, quis sit rex cereali. Bene inquadra, bene inquadra, quia non videtur.\r\n\r\nErgo… Super Mario, Super Mario, quis habet? Tu non. Isti? Uh, legere vix possum… ah ah!\r\nEt videamus—uh, rice krispies caerulei et rubei. Quis habet? Nemo, amici. Isti cum leone? Nemo. Isti? Cheerios cinnamomi. Nemo. O Deus! Lucky Charme. Nemo, amici. Ecce alter! O meum Deum!\r\n\r\nMagnum mercatum fecimus, comparema. Ecce hic! Donuts?! Uh, donuts, ita! Oreo aurea forma familiae, ita! “Novum” scriptum est, ahah! O meum Deum, chips ahoy… Amici, rex cereali, rex cereali!\r\n\r\nNon possum desinere, quia adsunt etiam illi Dora Exploratricis! Non credo, non credo—etiam illi Dorae! Grex, magne comparema, magnae nuntiae! Skuu!",
                        Rate = 1.99,
                        SqrMeters = 5,
                        Occupancy = 0,
                        ImageUrl = "https://i.redd.it/4t1tkl6hq13d1.jpeg",
                        Amenity = "Cucina, bagno, divano, Guspini, Lycamobile, Senigallia, Mandolini, contenziosi, Bullitta, mostarda, Lerdammer, Final Fantasy XV, Morra cinese 2",
                        CreatedDate = DateTime.Now.ToUniversalTime()
                    },

                    new Villa
                    {
                        Id = 4,
                        Name = "Sondrio",
                        Details = "Sondrio",
                        Rate = 2,
                        SqrMeters = 20880,
                        Occupancy = 21504,
                        ImageUrl = "https://it.wikipedia.org/wiki/Sondrio#/media/File:Sondrio_panorama.jpg",
                        Amenity = "Città, prato e altre cose",
                        CreatedDate = DateTime.Now.ToUniversalTime()
                    },

                    new Villa
                    {
                        Id = 5,
                        Name = "Sferionisdiolla",
                        Details = "Ecce ego, ecce vere ego ipse adsum, amici! Ite, aperiamus. Videamus quid in hac capsa sit, quis sit rex cereali. Bene inquadra, bene inquadra, quia non videtur.\r\n\r\nErgo… Super Mario, Super Mario, quis habet? Tu non. Isti? Uh, legere vix possum… ah ah!\r\nEt videamus—uh, rice krispies caerulei et rubei. Quis habet? Nemo, amici. Isti cum leone? Nemo. Isti? Cheerios cinnamomi. Nemo. O Deus! Lucky Charme. Nemo, amici. Ecce alter! O meum Deum!\r\n\r\nMagnum mercatum fecimus, comparema. Ecce hic! Donuts?! Uh, donuts, ita! Oreo aurea forma familiae, ita! “Novum” scriptum est, ahah! O meum Deum, chips ahoy… Amici, rex cereali, rex cereali!\r\n\r\nNon possum desinere, quia adsunt etiam illi Dora Exploratricis! Non credo, non credo—etiam illi Dorae! Grex, magne comparema, magnae nuntiae! Skuu!",
                        Rate = 600000,
                        SqrMeters = 1,
                        Occupancy = 3,
                        ImageUrl = "https://i.redd.it/4t1tkl6hq13d1.jpeg",
                        Amenity = "Cucina, bagno, divano, Guspini, Lycamobile, Senigallia, Mandolini, contenziosi, Bullitta, mostarda, Lerdammer, Final Fantasy XV, Morra cinese 2",
                        CreatedDate = DateTime.Now.ToUniversalTime()
                    }
                    );
            });

            modelbuilder.Entity<VillaNumber>(entity =>
            {
                entity.HasData(
                    new VillaNumber
                    {
                        VillaNo = 65472345,
                        SpecialDetails = "On fire",
                        CreatedDate = DateTime.Now.ToUniversalTime(),
                        VillaId = 5
                    },

                    new VillaNumber
                    {
                        VillaNo = 45897235,
                        SpecialDetails = "Susanna 8",
                        CreatedDate = DateTime.Now.ToUniversalTime(),
                        VillaId = 4
                    },

                    new VillaNumber
                    {
                        VillaNo = 67234783,
                        SpecialDetails = "Subbuteo",
                        CreatedDate = DateTime.Now.ToUniversalTime(),
                        VillaId = 3
                    },
                    new VillaNumber
                    {
                        VillaNo = 21982387,
                        SpecialDetails = "Tuple varie e altri collezionabili",
                        CreatedDate = DateTime.Now.ToUniversalTime(),
                        VillaId = 2
                    },

                    new VillaNumber
                    {
                        VillaNo = 1155664488,
                        SpecialDetails = "Highway In The Sky... For Final Rush",
                        CreatedDate = DateTime.Now.ToUniversalTime(),
                        VillaId = 1
                    }
                );
            });
        }
    }
}
