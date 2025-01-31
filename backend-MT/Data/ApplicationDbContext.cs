using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using backend_MT.Models;
using Microsoft.VisualBasic;

namespace backend_MT.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> user { get; set; }
        public DbSet<Material> material { get; set; }
        public DbSet<Tema> tema { get; set; }
        public DbSet<RaspunsTema> raspunsTema { get; set; }
        public DbSet<Support> support { get; set; }
        public DbSet<Grupa> grupa { get; set; }
        public DbSet<Curs> curs { get; set; }
        public DbSet<Notificare> notificare { get; set; }
        public DbSet<Sedinta> sedinta { get; set; }
        public DbSet<Feedback> feedback { get; set; }
        public DbSet<Plata> plata { get; set; }
        public DbSet<Mesaj> mesaj { get; set; }
        public DbSet<Prezenta> prezenta {  get; set; }
        public DbSet<ParticipareGrupa> participareGrupa {  get; set; }
        public DbSet<Disponibilitate> disponibilitate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Mesaj>()
            .HasOne(m => m.emitator)
            .WithMany()
            .HasForeignKey(m => m.emitatorId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Mesaj>()
                .HasOne(m => m.receptor)
                .WithMany()
                .HasForeignKey(m => m.receptorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RaspunsTema>()
                .HasOne(rt => rt.user)
                .WithMany(u => u.raspunsuriTema)
                .HasForeignKey(rt => rt.userId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RaspunsTema>()
                .HasOne(rt => rt.tema)
                .WithMany(t => t.raspunsuriTema)
                .HasForeignKey(rt => rt.temaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tema>()
                .HasOne(t => t.user)                 
                .WithMany(u => u.teme)               
                .HasForeignKey(t => t.userId)         
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ParticipareGrupa>()
                .HasOne(pg => pg.user)
                .WithMany(u => u.participariGrupa)
                .HasForeignKey(pg => pg.userId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ParticipareGrupa>()
                .HasOne(pg => pg.grupa)
                .WithMany(g => g.participariGrupa)
                .HasForeignKey(pg => pg.grupaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.sedinta)
                .WithMany(s => s.feedbackuri)
                .HasForeignKey(f => f.sedintaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.user)
                .WithMany(u => u.feedbackuri)
                .HasForeignKey(f => f.userId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prezenta>()
                .HasOne(p => p.user)
                .WithMany(u => u.prezente)
                .HasForeignKey(p => p.userId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prezenta>()
                .HasOne(p => p.sedinta)
                .WithMany(s => s.prezente)
                .HasForeignKey(p => p.sedintaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
