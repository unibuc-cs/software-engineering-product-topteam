﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend_MT.Data;

#nullable disable

namespace backend_MT.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241031004030_2 Migration")]
    partial class _2Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("backend_MT.Models.Abonament", b =>
                {
                    b.Property<int>("abonamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("abonamentId"));

                    b.Property<int>("cursId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("abonamentId");

                    b.HasIndex("cursId");

                    b.HasIndex("userId");

                    b.ToTable("abonament");
                });

            modelBuilder.Entity("backend_MT.Models.Curs", b =>
                {
                    b.Property<int>("cursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cursId"));

                    b.Property<string>("denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nrSedinte")
                        .HasColumnType("int");

                    b.Property<int>("pret")
                        .HasColumnType("int");

                    b.HasKey("cursId");

                    b.ToTable("curs");
                });

            modelBuilder.Entity("backend_MT.Models.Disponibilitate", b =>
                {
                    b.Property<int>("disponibilitateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("disponibilitateId"));

                    b.Property<TimeSpan>("oraIncepere")
                        .HasColumnType("time");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int>("zi")
                        .HasColumnType("int");

                    b.HasKey("disponibilitateId");

                    b.HasIndex("userId");

                    b.ToTable("Disponibilitate");
                });

            modelBuilder.Entity("backend_MT.Models.Feedback", b =>
                {
                    b.Property<int>("feedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("feedbackId"));

                    b.Property<string>("mesaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sedintaId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("feedbackId");

                    b.HasIndex("sedintaId");

                    b.HasIndex("userId");

                    b.ToTable("feedback");
                });

            modelBuilder.Entity("backend_MT.Models.Grupa", b =>
                {
                    b.Property<int>("grupaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("grupaId"));

                    b.Property<int>("cursId")
                        .HasColumnType("int");

                    b.Property<string>("linkMeet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nivelStudiu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("grupaId");

                    b.HasIndex("cursId");

                    b.HasIndex("userId");

                    b.ToTable("grupa");
                });

            modelBuilder.Entity("backend_MT.Models.Material", b =>
                {
                    b.Property<int>("materialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("materialId"));

                    b.Property<string>("descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titlu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("materialId");

                    b.HasIndex("userId");

                    b.ToTable("material");
                });

            modelBuilder.Entity("backend_MT.Models.Mesaj", b =>
                {
                    b.Property<int>("mesajId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("mesajId"));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("emitatorId")
                        .HasColumnType("int");

                    b.Property<string>("mesajText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("receptorId")
                        .HasColumnType("int");

                    b.Property<string>("tipMesaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("notificareId"));

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("grupaId")
                        .HasColumnType("int");

                    b.Property<string>("mesaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("receptorId")
                        .HasColumnType("int");

                    b.Property<string>("tipNotificare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titlu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("notificareId");

                    b.HasIndex("grupaId");

                    b.HasIndex("userId");

                    b.ToTable("notificare");
                });

            modelBuilder.Entity("backend_MT.Models.ParticipareGrupa", b =>
                {
                    b.Property<int>("participareGrupaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("participareGrupaId"));

                    b.Property<int>("grupaId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("participareGrupaId");

                    b.HasIndex("grupaId");

                    b.HasIndex("userId");

                    b.ToTable("participareGrupa");
                });

            modelBuilder.Entity("backend_MT.Models.Plata", b =>
                {
                    b.Property<int>("plataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("plataId"));

                    b.Property<int>("cursId")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<int>("suma")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("plataId");

                    b.HasIndex("cursId");

                    b.HasIndex("userId");

                    b.ToTable("plata");
                });

            modelBuilder.Entity("backend_MT.Models.Predare", b =>
                {
                    b.Property<int>("predareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("predareId"));

                    b.Property<int>("cursId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("predareId");

                    b.HasIndex("cursId");

                    b.HasIndex("userId");

                    b.ToTable("predare");
                });

            modelBuilder.Entity("backend_MT.Models.Prezenta", b =>
                {
                    b.Property<int>("prezentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("prezentaId"));

                    b.Property<int>("sedintaId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("prezentaId");

                    b.HasIndex("sedintaId");

                    b.HasIndex("userId");

                    b.ToTable("prezenta");
                });

            modelBuilder.Entity("backend_MT.Models.RaspunsTema", b =>
                {
                    b.Property<int>("raspunsTemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("raspunsTemaId"));

                    b.Property<string>("fisier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("punctaj")
                        .HasColumnType("int");

                    b.Property<int>("temaId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("raspunsTemaId");

                    b.HasIndex("temaId");

                    b.HasIndex("userId");

                    b.ToTable("raspunsTema");
                });

            modelBuilder.Entity("backend_MT.Models.Sedinta", b =>
                {
                    b.Property<int>("sedintaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sedintaId"));

                    b.Property<int>("grupaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("oraIncepere")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("oraIncheiere")
                        .HasColumnType("datetime2");

                    b.Property<string>("titlu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("zi")
                        .HasColumnType("datetime2");

                    b.HasKey("sedintaId");

                    b.HasIndex("grupaId");

                    b.ToTable("sedinta");
                });

            modelBuilder.Entity("backend_MT.Models.Support", b =>
                {
                    b.Property<int>("supportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("supportId"));

                    b.Property<string>("mesaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("supportId");

                    b.HasIndex("userId");

                    b.ToTable("support");
                });

            modelBuilder.Entity("backend_MT.Models.Tema", b =>
                {
                    b.Property<int>("temaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("temaId"));

                    b.Property<string>("descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fisier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titlu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("temaId");

                    b.HasIndex("userId");

                    b.ToTable("tema");
                });

            modelBuilder.Entity("backend_MT.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("nivel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pozaProfil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("profesorVerificat")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

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

            modelBuilder.Entity("backend_MT.Models.Abonament", b =>
                {
                    b.HasOne("backend_MT.Models.Curs", "curs")
                        .WithMany("abonamente")
                        .HasForeignKey("cursId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("abonamente")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("curs");

                    b.Navigation("user");
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

                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("grupa")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("curs");

                    b.Navigation("user");
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
                    b.HasOne("backend_MT.Models.Grupa", "grupa")
                        .WithMany()
                        .HasForeignKey("grupaId");

                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("notificari")
                        .HasForeignKey("userId");

                    b.Navigation("grupa");

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

            modelBuilder.Entity("backend_MT.Models.Predare", b =>
                {
                    b.HasOne("backend_MT.Models.Curs", "curs")
                        .WithMany()
                        .HasForeignKey("cursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend_MT.Models.User", "user")
                        .WithMany("predare")
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

            modelBuilder.Entity("backend_MT.Models.Curs", b =>
                {
                    b.Navigation("abonamente");
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
                    b.Navigation("abonamente");

                    b.Navigation("disponibilitate");

                    b.Navigation("feedbackuri");

                    b.Navigation("grupa");

                    b.Navigation("materiale");

                    b.Navigation("mesaje");

                    b.Navigation("notificari");

                    b.Navigation("participariGrupa");

                    b.Navigation("plati");

                    b.Navigation("predare");

                    b.Navigation("prezente");

                    b.Navigation("raspunsuriTema");

                    b.Navigation("supporturi");

                    b.Navigation("teme");
                });
#pragma warning restore 612, 618
        }
    }
}
