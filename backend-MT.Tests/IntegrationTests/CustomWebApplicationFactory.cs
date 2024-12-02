namespace backend_MT.Tests.IntegrationTests;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using backend_MT.Data; 
using backend_MT.Models;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove the existing DbContext registration
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // Register an in-memory database for testing
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TestDatabase"));

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();

            // Create a new scope for seeding the database
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                // Ensure the database is created
                db.Database.EnsureCreated();

                // Seed the database with test data
                SeedDatabase(db);
            }
        });
    }

    private void SeedDatabase(ApplicationDbContext db)
    {
        // Seed Users
        db.Users.AddRange(
            new User { userId = 1, userName = "User1" },
            new User { userId = 2, userName = "User2" }
        );

        // Seed Grupa
        db.Grupa.AddRange(
            new Grupa { grupaId = 1, numeGrupa = "Grupa A" },
            new Grupa { grupaId = 2, numeGrupa = "Grupa B" }
        );

        // Seed Tema
        db.Tema.AddRange(
            new Tema { temaId = 1, titlu = "Tema 1", descriere = "Descriere 1", fisier = "file1.pdf", userId = 1 },
            new Tema { temaId = 2, titlu = "Tema 2", descriere = "Descriere 2", fisier = "file2.pdf", userId = 2 }
        );

        // Seed RaspunsTema
        db.RaspunsTema.AddRange(
            new RaspunsTema { raspunsTemaId = 1, fisier = "response1.pdf", punctaj = 80, temaId = 1, userId = 1 },
            new RaspunsTema { raspunsTemaId = 2, fisier = "response2.pdf", punctaj = 90, temaId = 2, userId = 2 }
        );

        // Seed Sedinta
        db.Sedinta.AddRange(
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
        db.Abonament.AddRange(
            new Abonament { abonamentId = 1, userId = 1, cursId = 1 },
            new Abonament { abonamentId = 2, userId = 2, cursId = 2 }
        );

        // Seed Curs
        db.Curs.AddRange(
            new Curs { cursId = 1, denumire = "Curs A", descriere = "Descriere A", nrSedinte = 10, pret = 200 },
            new Curs { cursId = 2, denumire = "Curs B", descriere = "Descriere B", nrSedinte = 15, pret = 300 }
        );

        // Seed Support
        db.Support.AddRange(
            new Support { supportId = 1, mesaj = "Support message 1", userId = 1 },
            new Support { supportId = 2, mesaj = "Support message 2", userId = 2 }
        );

        // Seed Notificare
        db.Notificare.AddRange(
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

        // Add other entities here as needed...

        db.SaveChanges();
    }
}
