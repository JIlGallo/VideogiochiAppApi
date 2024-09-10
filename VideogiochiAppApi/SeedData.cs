//using Microsoft.EntityFrameworkCore;
//using VideogiochiAppApi.Model;

//namespace VideogiochiAppApi.Data
//{
//    public class SeedData
//    {
//        public static void Initialize(DataContext context)
//        {
//            // Verifica se il database è già popolato
//            if (context.Videogiochi.Any() || context.Proprietari.Any() || context.Paesi.Any() || context.VideogiocoProprietari.Any())
//            {
//                return; // Non fare nulla se il database è già popolato
//            }

//            // Crea alcuni Paesi
//            var paesi = new List<Paese>
//            {
//                new Paese { Name = "Italia" },
//                new Paese { Name = "Stati Uniti" },
//                new Paese { Name = "Giappone" }
//            };
//            context.Paesi.AddRange(paesi);
//            context.SaveChanges();

//            // Crea alcuni Proprietari
//            var proprietari = new List<Proprietario>
//            {
//                new Proprietario { Nome = "Mario Rossi", Età = 30, IdPaese = paesi.FirstOrDefault(p => p.Name == "Italia")?.IdPaese },
//                new Proprietario { Nome = "Luigi Verdi", Età = 25, IdPaese = paesi.FirstOrDefault(p => p.Name == "Stati Uniti")?.IdPaese },
//                new Proprietario { Nome = "Sara Bianchi", Età = 28, IdPaese = paesi.FirstOrDefault(p => p.Name == "Giappone")?.IdPaese }
//            };
//            context.Proprietari.AddRange(proprietari);
//            context.SaveChanges();

//            // Crea alcuni Videogiochi
//            var videogiochi = new List<Videogioco>
//            {
//                new Videogioco { Nome = "Super Mario Odyssey", DataDiRilascio = new DateOnly(2017, 10, 27) },
//                new Videogioco { Nome = "The Legend of Zelda: Breath of the Wild", DataDiRilascio = new DateOnly(2017, 3, 3) },
//                new Videogioco { Nome = "Animal Crossing: New Horizons", DataDiRilascio = new DateOnly(2020, 3, 20) }
//            };
//            context.Videogiochi.AddRange(videogiochi);
//            context.SaveChanges();

//            // Crea alcuni VideogiocoProprietario
//            var videogameoproprietario = new List<VideogiocoProprietario>
//            {
//                new VideogiocoProprietario { IdVideogioco = videogiochi.FirstOrDefault(v => v.Nome == "Super Mario Odyssey")?.IdVideogioco, IdProprietario = proprietari.FirstOrDefault(p => p.Nome == "Mario Rossi")?.IdProprietario },
//                new VideogiocoProprietario { IdVideogioco = videogiochi.FirstOrDefault(v => v.Nome == "The Legend of Zelda: Breath of the Wild")?.IdVideogioco, IdProprietario = proprietari.FirstOrDefault(p => p.Nome == "Luigi Verdi")?.IdProprietario },
//                new VideogiocoProprietario { IdVideogioco = videogiochi.FirstOrDefault(v => v.Nome == "Animal Crossing: New Horizons")?.IdVideogioco, IdProprietario = proprietari.FirstOrDefault(p => p.Nome == "Sara Bianchi")?.IdProprietario },
//            };
//            context.VideogiocoProprietari.AddRange(videogameoproprietario);
//            context.SaveChanges();
//        }
//    }
//}