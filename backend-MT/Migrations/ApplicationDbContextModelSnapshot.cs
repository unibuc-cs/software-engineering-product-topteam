﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend_MT.Data;

#nullable disable

namespace backend_MT.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("backend_MT.Models.Curs", b =>
                {
                    b.Property<int>("cursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("cursId"));

                    b.Property<string>("denumire")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("descriere")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("nrSedinte")
                        .HasColumnType("integer");

                    b.Property<int>("pret")
                        .HasColumnType("integer");

                    b.HasKey("cursId");

                    b.ToTable("curs");
                });

            modelBuilder.Entity("backend_MT.Models.Disponibilitate", b =>
                {
                    b.Property<int>("disponibilitateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("disponibilitateId"));

                    b.Property<TimeSpan>("oraIncepere")
                        .HasColumnType("interval");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.Property<int>("zi")
                        .HasColumnType("integer");

                    b.HasKey("disponibilitateId");

                    b.HasIndex("userId");

                    b.ToTable("disponibilitate");
                });

            modelBuilder.Entity("backend_MT.Models.Feedback", b =>
                {
                    b.Property<int>("feedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("feedbackId"));

                    b.Property<string>("mesaj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("sedintaId")
                        .HasColumnType("integer");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("feedbackId");

                    b.HasIndex("sedintaId");

                    b.HasIndex("userId");

                    b.ToTable("feedback");
                });

            modelBuilder.Entity("backend_MT.Models.Grupa", b =>
                {
                    b.Property<int>("grupaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("grupaId"));

                    b.Property<int>("cursId")
                        .HasColumnType("integer");

                    b.Property<string>("linkMeet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nivelStudiu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nume")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("userProfesorId")
                        .HasColumnType("integer");

                    b.HasKey("grupaId");

                    b.HasIndex("cursId");

                    b.HasIndex("userProfesorId");

                    b.ToTable("grupa");
                });

            modelBuilder.Entity("backend_MT.Models.Material", b =>
                {
                    b.Property<int>("materialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("materialId"));

                    b.Property<string>("descriere")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("titlu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("materialId");

                    b.HasIndex("userId");

                    b.ToTable("material");
                });

            modelBuilder.Entity("backend_MT.Models.Mesaj", b =>
                {
                    b.Property<int>("mesajId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("mesajId"));

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("emitatorId")
                        .HasColumnType("integer");

                    b.Property<string>("mesajText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("receptorId")
                        .HasColumnType("integer");

                    b.Property<string>("tipMesaj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("mesajId");

                    b.HasIndex("UserId");

                    b.HasIndex("emitatorId");

                    b.HasIndex("receptorId");

                    b.ToTable("mesaj");
                });

            modelBuilder.Entity("backend_MT.Models.Notificare", b =>
                {
                    b.Property<int>("notificareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("notificareId"));

                    b.Property<DateTime>("data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("mesaj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tipNotificare")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("titlu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("notificareId");

                    b.HasIndex("userId");

                    b.ToTable("notificare");
                });

            modelBuilder.Entity("backend_MT.Models.ParticipareGrupa", b =>
                {
                    b.Property<int>("participareGrupaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("participareGrupaId"));

                    b.Property<int>("grupaId")
                        .HasColumnType("integer");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("participareGrupaId");

                    b.HasIndex("grupaId");

                    b.HasIndex("userId");

                    b.ToTable("participareGrupa");
                });

            modelBuilder.Entity("backend_MT.Models.Plata", b =>
                {
                    b.Property<int>("plataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("plataId"));

                    b.Property<int>("cursId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("suma")
                        .HasColumnType("integer");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("plataId");

                    b.HasIndex("cursId");

                    b.HasIndex("userId");

                    b.ToTable("plata");
                });

            modelBuilder.Entity("backend_MT.Models.Prezenta", b =>
                {
                    b.Property<int>("prezentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("prezentaId"));

                    b.Property<int>("sedintaId")
                        .HasColumnType("integer");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("prezentaId");

                    b.HasIndex("sedintaId");

                    b.HasIndex("userId");

                    b.ToTable("prezenta");
                });

            modelBuilder.Entity("backend_MT.Models.RaspunsTema", b =>
                {
                    b.Property<int>("raspunsTemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("raspunsTemaId"));

                    b.Property<string>("fisier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("punctaj")
                        .HasColumnType("integer");

                    b.Property<int>("temaId")
                        .HasColumnType("integer");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("raspunsTemaId");

                    b.HasIndex("temaId");

                    b.HasIndex("userId");

                    b.ToTable("raspunsTema");
                });

            modelBuilder.Entity("backend_MT.Models.Sedinta", b =>
                {
                    b.Property<int>("sedintaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("sedintaId"));

                    b.Property<int>("grupaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("oraIncepere")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("oraIncheiere")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("titlu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("zi")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("sedintaId");

                    b.HasIndex("grupaId");

                    b.ToTable("sedinta");
                });

            modelBuilder.Entity("backend_MT.Models.Support", b =>
                {
                    b.Property<int>("supportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("supportId"));

                    b.Property<string>("mesaj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("supportId");

                    b.HasIndex("userId");

                    b.ToTable("support");
                });

            modelBuilder.Entity("backend_MT.Models.Tema", b =>
                {
                    b.Property<int>("temaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("temaId"));

                    b.Property<string>("descriere")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fisier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("titlu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("temaId");

                    b.HasIndex("userId");

                    b.ToTable("tema");
                });

            modelBuilder.Entity("backend_MT.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("nivel")
                        .HasColumnType("text");

                    b.Property<string>("nume")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("pozaProfil")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("prenume")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("profesorVerificat")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("backend_MT.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("backend_MT.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend_MT.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("backend_MT.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend_MT.Models.Disponibilitate", b =>
                {
                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("disponibilitate")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("backend_MT.Models.Feedback", b =>
                {
                    b.HasOne("backend_MT.Models.Sedinta", "sedinta")
                        .WithMany("feedbackuri")
                        .HasForeignKey("sedintaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("feedbackuri")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("sedinta");

                    b.Navigation("user");
                });

            modelBuilder.Entity("backend_MT.Models.Grupa", b =>
                {
                    b.HasOne("backend_MT.Models.Curs", "curs")
                        .WithMany()
                        .HasForeignKey("cursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend_MT.Models.User", "userProfesor")
                        .WithMany("grupa")
                        .HasForeignKey("userProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("curs");

                    b.Navigation("userProfesor");
                });

            modelBuilder.Entity("backend_MT.Models.Material", b =>
                {
                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("materiale")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("backend_MT.Models.Mesaj", b =>
                {
                    b.HasOne("backend_MT.Models.User", null)
                        .WithMany("mesaje")
                        .HasForeignKey("UserId");

                    b.HasOne("backend_MT.Models.User", "emitator")
                        .WithMany()
                        .HasForeignKey("emitatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend_MT.Models.User", "receptor")
                        .WithMany()
                        .HasForeignKey("receptorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("emitator");

                    b.Navigation("receptor");
                });

            modelBuilder.Entity("backend_MT.Models.Notificare", b =>
                {
                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("notificari")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("backend_MT.Models.ParticipareGrupa", b =>
                {
                    b.HasOne("backend_MT.Models.Grupa", "grupa")
                        .WithMany("participariGrupa")
                        .HasForeignKey("grupaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("participariGrupa")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("grupa");

                    b.Navigation("user");
                });

            modelBuilder.Entity("backend_MT.Models.Plata", b =>
                {
                    b.HasOne("backend_MT.Models.Curs", "curs")
                        .WithMany()
                        .HasForeignKey("cursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("plati")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("curs");

                    b.Navigation("user");
                });

            modelBuilder.Entity("backend_MT.Models.Prezenta", b =>
                {
                    b.HasOne("backend_MT.Models.Sedinta", "sedinta")
                        .WithMany("prezente")
                        .HasForeignKey("sedintaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("prezente")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("sedinta");

                    b.Navigation("user");
                });

            modelBuilder.Entity("backend_MT.Models.RaspunsTema", b =>
                {
                    b.HasOne("backend_MT.Models.Tema", "tema")
                        .WithMany("raspunsuriTema")
                        .HasForeignKey("temaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("raspunsuriTema")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("tema");

                    b.Navigation("user");
                });

            modelBuilder.Entity("backend_MT.Models.Sedinta", b =>
                {
                    b.HasOne("backend_MT.Models.Grupa", "grupa")
                        .WithMany()
                        .HasForeignKey("grupaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("grupa");
                });

            modelBuilder.Entity("backend_MT.Models.Support", b =>
                {
                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("supporturi")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("backend_MT.Models.Tema", b =>
                {
                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("teme")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("backend_MT.Models.Grupa", b =>
                {
                    b.Navigation("participariGrupa");
                });

            modelBuilder.Entity("backend_MT.Models.Sedinta", b =>
                {
                    b.Navigation("feedbackuri");

                    b.Navigation("prezente");
                });

            modelBuilder.Entity("backend_MT.Models.Tema", b =>
                {
                    b.Navigation("raspunsuriTema");
                });

            modelBuilder.Entity("backend_MT.Models.User", b =>
                {
                    b.Navigation("disponibilitate");

                    b.Navigation("feedbackuri");

                    b.Navigation("grupa");

                    b.Navigation("materiale");

                    b.Navigation("mesaje");

                    b.Navigation("notificari");

                    b.Navigation("participariGrupa");

                    b.Navigation("plati");

                    b.Navigation("prezente");

                    b.Navigation("raspunsuriTema");

                    b.Navigation("supporturi");

                    b.Navigation("teme");
                });
#pragma warning restore 612, 618
        }
    }
}
