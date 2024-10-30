using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using backend_MT.Models;
using Microsoft.VisualBasic;

namespace backend_MT.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Elevi { get; set; }
        public DbSet<Profesor> Profesori { get; set; }
        public DbSet<Material> Materiale { get; set; }
        public DbSet<Tema> Teme { get; set; }
        public DbSet<RaspunsTema> RaspunsuriTeme { get; set; }
        public DbSet<Support> Support { get; set; }
        public DbSet<Grupa> Grupe { get; set; }
        public DbSet<Curs> Cursuri { get; set; }
        public DbSet<Notificare> Notificari { get; set; }
        public DbSet<Sedinta> Sedinte { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Plata> Plati { get; set; }
        public DbSet<Mesaj> Mesaje { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tema>()
                .HasKey(i => i.TemaId);

            modelBuilder.Entity<Tema>()
                .HasOne(t => t.Profesor)
                .WithMany()
                .HasForeignKey(t => t.ProfesorId);

            modelBuilder.Entity<Material>()
                .HasKey(i => i.MaterialId);

            modelBuilder.Entity<Material>()
                .HasOne(m => m.Profesor)
                .WithMany()
                .HasForeignKey(m => m.ProfesorId);

            modelBuilder.Entity<RaspunsTema>()
                .HasKey(i => i.RaspunsTemaId);

            modelBuilder.Entity<RaspunsTema>()
                .HasOne(rt => rt.Tema)
                .WithMany()
                .HasForeignKey(rt => rt.TemaId);

            modelBuilder.Entity<Support>()
                .HasKey(i => i.SupportId);

            modelBuilder.Entity<Support>()
                .HasOne(s => s.Elev)
                .WithMany()
                .HasForeignKey(s => s.ElevId);

            modelBuilder.Entity<Grupa>()
                .HasKey(i => i.GrupaId);

            modelBuilder.Entity<Grupa>()
                .HasOne(g => g.Profesor)
                .WithMany()
                .HasForeignKey(g => g.ProfesorId);

            modelBuilder.Entity<Grupa>()
                .HasOne(g => g.Curs)
                .WithMany()
                .HasForeignKey(g => g.CursId);

            modelBuilder.Entity<Notificare>()
                .HasKey(i => i.NotificareId);

            modelBuilder.Entity<Notificare>()
                .HasOne(n => n.Receptor)
                .WithMany()
                .HasForeignKey(n => n.ReceptorId);

            modelBuilder.Entity<Sedinta>()
                .HasKey(i => i.SedintaId);

            modelBuilder.Entity<Sedinta>()
                .HasOne(s => s.Grupa)
                .WithMany()
                .HasForeignKey(s => s.GrupaId);

            modelBuilder.Entity<Feedback>()
                .HasKey(i => i.FeedbackId);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Sedinta)
                .WithMany()
                .HasForeignKey(f => f.SedintaId);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Elev)
                .WithMany()
                .HasForeignKey(f => f.ElevId);

            modelBuilder.Entity<Plata>()
                .HasKey(i => i.PlataId);

            modelBuilder.Entity<Plata>()
                .HasOne(p => p.Elev)
                .WithMany()
                .HasForeignKey(p => p.ElevId);

            modelBuilder.Entity<Plata>()
                .HasOne(p => p.Curs)
                .WithMany()
                .HasForeignKey(p => p.CursId);

            modelBuilder.Entity<Mesaj>()
                .HasKey(i => i.MesajId);

            modelBuilder.Entity<Mesaj>()
                .HasOne(m => m.Emitator)
                .WithMany()
                .HasForeignKey(m => m.EmitatorId);

            modelBuilder.Entity<Mesaj>()
                .HasOne(m => m.Receptor)
                .WithMany()
                .HasForeignKey(m => m.ReceptorId);
        }
    }
}
