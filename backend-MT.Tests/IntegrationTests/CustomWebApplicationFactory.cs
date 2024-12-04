using Microsoft.VisualStudio.TestPlatform.TestHost;

using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using System;
using System.Data.Common;
using System.Linq;
using backend_MT.Data; 
using backend_MT.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;

namespace backend_MT.Tests.IntegrationTests
{
   public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly string _databaseName;

        public CustomWebApplicationFactory()
        {
            // Generate a unique database name for each factory instance
            _databaseName = Guid.NewGuid().ToString();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");
            
            builder.ConfigureServices(services =>
            {
                // Remove the existing DbContext registration
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add in-memory database with the unique name
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase(_databaseName));

                // Add controllers with JSON options to ignore cycles
                services.AddControllers().AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

                // Build the service provider
                var serviceProvider = services.BuildServiceProvider();  

                // Create a scope to get a reference to the database context
                using (var scope = serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    // Ensure the database is created
                    dbContext.Database.EnsureCreated();

                    // Seed the database
                    SeedDatabase(dbContext);
                }
            });

            builder.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole(); // Outputs logs to the test output
            });
        }
        
        private void SeedDatabase(ApplicationDbContext db)
        {
            // Clear existing data
            db.prezenta.RemoveRange(db.prezenta);
            db.user.RemoveRange(db.user);
            db.grupa.RemoveRange(db.grupa);
            db.feedback.RemoveRange(db.feedback);
            db.tema.RemoveRange(db.tema);
            db.raspunsTema.RemoveRange(db.raspunsTema);
            db.sedinta.RemoveRange(db.sedinta);
            db.abonament.RemoveRange(db.abonament);
            db.curs.RemoveRange(db.curs);
            db.material.RemoveRange(db.material);
            db.support.RemoveRange(db.support);
            db.notificare.RemoveRange(db.notificare);
            db.mesaj.RemoveRange(db.mesaj);
            db.predare.RemoveRange(db.predare);
            db.participareGrupa.RemoveRange(db.participareGrupa);
            db.disponibilitate.RemoveRange(db.disponibilitate);

            db.SaveChanges();
            
            // Seed Users with all required properties populated
            db.user.AddRange(
                new User
                {
                    userId = 1,
                    username = "User1",
                    email = "user1@example.com",
                    nrTelefon = "1234567890",
                    nume = "Doe",
                    prenume = "John",
                    pozaProfil = "profile1.jpg" // Replace with a valid file path or URL if needed
                },
                new User
                {
                    userId = 2,
                    username = "User2",
                    email = "user2@example.com",
                    nrTelefon = "0987654321",
                    nume = "Smith",
                    prenume = "Jane",
                    pozaProfil = "profile2.jpg"
                }
            );

            // Seed Grupa
            db.grupa.AddRange(
                new Grupa
                {
                    grupaId = 1,
                    nume = "Grupa A",
                    nivelStudiu = "Incepator",
                    linkMeet = "https://meet.example.com/grupa-a",
                    userId = 1,
                    cursId = 1
                },
                new Grupa
                {
                    grupaId = 2,
                    nume = "Grupa B",
                    nivelStudiu = "Avansat",
                    linkMeet = "https://meet.example.com/grupa-b",
                    userId = 2,
                    cursId = 2
                }
            );

            // Seed Feedback
            db.feedback.AddRange(
                new Feedback
                {
                    feedbackId = 1,
                    mesaj = "Great session!",
                    sedintaId = 1,
                    userId = 1
                },
                new Feedback
                {
                    feedbackId = 2,
                    mesaj = "Very informative.",
                    sedintaId = 2,
                    userId = 2
                }
            );

            // Seed Tema
            db.tema.AddRange(
                new Tema { temaId = 1, titlu = "Tema 1", descriere = "Descriere 1", fisier = "file1.pdf", userId = 1 },
                new Tema { temaId = 2, titlu = "Tema 2", descriere = "Descriere 2", fisier = "file2.pdf", userId = 2 }
            );

            // Seed RaspunsTema
            db.raspunsTema.AddRange(
                new RaspunsTema { raspunsTemaId = 1, fisier = "response1.pdf", punctaj = 80, temaId = 1, userId = 1 },
                new RaspunsTema { raspunsTemaId = 2, fisier = "response2.pdf", punctaj = 90, temaId = 2, userId = 2 }
            );

            // Seed Sedinta
            db.sedinta.AddRange(
                new Sedinta
                {
                    sedintaId = 1,
                    titlu = "Sedinta 1",
                    zi = DateTime.Now,
                    oraIncepere = DateTime.Now.AddHours(1),
                    oraIncheiere = DateTime.Now.AddHours(2),
                    grupaId = 1
                },
                new Sedinta
                {
                    sedintaId = 2,
                    titlu = "Sedinta 2",
                    zi = DateTime.Now.AddDays(1),
                    oraIncepere = DateTime.Now.AddHours(3),
                    oraIncheiere = DateTime.Now.AddHours(4),
                    grupaId = 2
                }
            );

            // Seed Abonament
            db.abonament.AddRange(
                new Abonament { abonamentId = 1, userId = 1, cursId = 1 },
                new Abonament { abonamentId = 2, userId = 2, cursId = 2 }
            );

            // Seed Curs
            db.curs.AddRange(
                new Curs { cursId = 1, denumire = "Curs A", descriere = "Descriere A", nrSedinte = 10, pret = 200 },
                new Curs { cursId = 2, denumire = "Curs B", descriere = "Descriere B", nrSedinte = 15, pret = 300 }
            );

            // Seed Material
            db.material.AddRange(
                new Material { materialId = 1, titlu = "Material 1", descriere = "Descriere Material 1", userId = 1 },
                new Material { materialId = 2, titlu = "Material 2", descriere = "Descriere Material 2", userId = 2 }
            );

            // Seed Support
            db.support.AddRange(
                new Support { supportId = 1, mesaj = "Support message 1", userId = 1 },
                new Support { supportId = 2, mesaj = "Support message 2", userId = 2 }
            );

            // Seed Notificare
            db.notificare.AddRange(
                new Notificare
                {
                    notificareId = 1,
                    titlu = "Notification 1",
                    mesaj = "Message 1",
                    data = DateTime.Now,
                    tipNotificare = "General",
                    receptorId = 1
                },
                new Notificare
                {
                    notificareId = 2,
                    titlu = "Notification 2",
                    mesaj = "Message 2",
                    data = DateTime.Now.AddDays(1),
                    tipNotificare = "Important",
                    receptorId = 2
                }
            );

            // Seed Mesaj
            db.mesaj.AddRange(
                new Mesaj { mesajId = 1, mesajText = "Mesaj 1", tipMesaj = "Privat", emitatorId = 1, receptorId = 2 },
                new Mesaj { mesajId = 2, mesajText = "Mesaj 2", tipMesaj = "Grup", emitatorId = 2, receptorId = 1 }
            );

            // Seed Prezenta
            db.prezenta.AddRange(
                new Prezenta { prezentaId = 1, userId = 1, sedintaId = 1 },
                new Prezenta { prezentaId = 2, userId = 2, sedintaId = 2 }
            );

            // Seed Predare
            db.predare.AddRange(
                new Predare { predareId = 1, userId = 1, cursId = 1 },
                new Predare { predareId = 2, userId = 2, cursId = 2 }
            );

            // Seed ParticipareGrupa
            db.participareGrupa.AddRange(
                new ParticipareGrupa { participareGrupaId = 1, userId = 1, grupaId = 1 },
                new ParticipareGrupa { participareGrupaId = 2, userId = 2, grupaId = 2 }
            );

            // Seed Disponibilitate
            db.disponibilitate.AddRange(
                new Disponibilitate
                {
                    disponibilitateId = 1,
                    zi = DayOfWeek.Monday,
                    oraIncepere = new TimeSpan(9, 0, 0),
                    userId = 1
                },
                new Disponibilitate
                {
                    disponibilitateId = 2,
                    zi = DayOfWeek.Tuesday,
                    oraIncepere = new TimeSpan(10, 0, 0),
                    userId = 2
                }
            );

            db.SaveChanges();
        }


    }
}
