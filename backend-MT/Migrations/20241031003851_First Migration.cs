﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_MT.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pozaProfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "curs",
                columns: table => new
                {
                    cursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nrSedinte = table.Column<int>(type: "int", nullable: false),
                    pret = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curs", x => x.cursId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disponibilitate",
                columns: table => new
                {
                    disponibilitateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zi = table.Column<int>(type: "int", nullable: false),
                    oraIncepere = table.Column<TimeSpan>(type: "time", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilitate", x => x.disponibilitateId);
                    table.ForeignKey(
                        name: "FK_Disponibilitate_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "material",
                columns: table => new
                {
                    materialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titlu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_material", x => x.materialId);
                    table.ForeignKey(
                        name: "FK_material_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mesaj",
                columns: table => new
                {
                    mesajId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mesajText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipMesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emitatorId = table.Column<int>(type: "int", nullable: false),
                    receptorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesaj", x => x.mesajId);
                    table.ForeignKey(
                        name: "FK_mesaj_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_mesaj_AspNetUsers_emitatorId",
                        column: x => x.emitatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mesaj_AspNetUsers_receptorId",
                        column: x => x.receptorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "support",
                columns: table => new
                {
                    supportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_support", x => x.supportId);
                    table.ForeignKey(
                        name: "FK_support_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tema",
                columns: table => new
                {
                    temaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titlu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fisier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tema", x => x.temaId);
                    table.ForeignKey(
                        name: "FK_tema_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "abonament",
                columns: table => new
                {
                    abonamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    cursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abonament", x => x.abonamentId);
                    table.ForeignKey(
                        name: "FK_abonament_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_abonament_curs_cursId",
                        column: x => x.cursId,
                        principalTable: "curs",
                        principalColumn: "cursId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "grupa",
                columns: table => new
                {
                    grupaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nivelStudiu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    linkMeet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    cursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupa", x => x.grupaId);
                    table.ForeignKey(
                        name: "FK_grupa_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grupa_curs_cursId",
                        column: x => x.cursId,
                        principalTable: "curs",
                        principalColumn: "cursId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "plata",
                columns: table => new
                {
                    plataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    suma = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    cursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plata", x => x.plataId);
                    table.ForeignKey(
                        name: "FK_plata_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_plata_curs_cursId",
                        column: x => x.cursId,
                        principalTable: "curs",
                        principalColumn: "cursId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "predare",
                columns: table => new
                {
                    predareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    cursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_predare", x => x.predareId);
                    table.ForeignKey(
                        name: "FK_predare_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_predare_curs_cursId",
                        column: x => x.cursId,
                        principalTable: "curs",
                        principalColumn: "cursId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "raspunsTema",
                columns: table => new
                {
                    raspunsTemaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fisier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    punctaj = table.Column<int>(type: "int", nullable: false),
                    temaId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raspunsTema", x => x.raspunsTemaId);
                    table.ForeignKey(
                        name: "FK_raspunsTema_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_raspunsTema_tema_temaId",
                        column: x => x.temaId,
                        principalTable: "tema",
                        principalColumn: "temaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notificare",
                columns: table => new
                {
                    notificareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titlu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipNotificare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receptorId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    grupaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificare", x => x.notificareId);
                    table.ForeignKey(
                        name: "FK_notificare_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_notificare_grupa_grupaId",
                        column: x => x.grupaId,
                        principalTable: "grupa",
                        principalColumn: "grupaId");
                });

            migrationBuilder.CreateTable(
                name: "participareGrupa",
                columns: table => new
                {
                    participareGrupaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    grupaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participareGrupa", x => x.participareGrupaId);
                    table.ForeignKey(
                        name: "FK_participareGrupa_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_participareGrupa_grupa_grupaId",
                        column: x => x.grupaId,
                        principalTable: "grupa",
                        principalColumn: "grupaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sedinta",
                columns: table => new
                {
                    sedintaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titlu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    oraIncepere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    oraIncheiere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    grupaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sedinta", x => x.sedintaId);
                    table.ForeignKey(
                        name: "FK_sedinta_grupa_grupaId",
                        column: x => x.grupaId,
                        principalTable: "grupa",
                        principalColumn: "grupaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feedback",
                columns: table => new
                {
                    feedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sedintaId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback", x => x.feedbackId);
                    table.ForeignKey(
                        name: "FK_feedback_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_feedback_sedinta_sedintaId",
                        column: x => x.sedintaId,
                        principalTable: "sedinta",
                        principalColumn: "sedintaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "prezenta",
                columns: table => new
                {
                    prezentaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    sedintaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prezenta", x => x.prezentaId);
                    table.ForeignKey(
                        name: "FK_prezenta_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_prezenta_sedinta_sedintaId",
                        column: x => x.sedintaId,
                        principalTable: "sedinta",
                        principalColumn: "sedintaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_abonament_cursId",
                table: "abonament",
                column: "cursId");

            migrationBuilder.CreateIndex(
                name: "IX_abonament_userId",
                table: "abonament",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilitate_userId",
                table: "Disponibilitate",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_sedintaId",
                table: "feedback",
                column: "sedintaId");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_userId",
                table: "feedback",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_grupa_cursId",
                table: "grupa",
                column: "cursId");

            migrationBuilder.CreateIndex(
                name: "IX_grupa_userId",
                table: "grupa",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_material_userId",
                table: "material",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_mesaj_emitatorId",
                table: "mesaj",
                column: "emitatorId");

            migrationBuilder.CreateIndex(
                name: "IX_mesaj_receptorId",
                table: "mesaj",
                column: "receptorId");

            migrationBuilder.CreateIndex(
                name: "IX_mesaj_UserId",
                table: "mesaj",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_notificare_grupaId",
                table: "notificare",
                column: "grupaId");

            migrationBuilder.CreateIndex(
                name: "IX_notificare_userId",
                table: "notificare",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_participareGrupa_grupaId",
                table: "participareGrupa",
                column: "grupaId");

            migrationBuilder.CreateIndex(
                name: "IX_participareGrupa_userId",
                table: "participareGrupa",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_plata_cursId",
                table: "plata",
                column: "cursId");

            migrationBuilder.CreateIndex(
                name: "IX_plata_userId",
                table: "plata",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_predare_cursId",
                table: "predare",
                column: "cursId");

            migrationBuilder.CreateIndex(
                name: "IX_predare_userId",
                table: "predare",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_prezenta_sedintaId",
                table: "prezenta",
                column: "sedintaId");

            migrationBuilder.CreateIndex(
                name: "IX_prezenta_userId",
                table: "prezenta",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_raspunsTema_temaId",
                table: "raspunsTema",
                column: "temaId");

            migrationBuilder.CreateIndex(
                name: "IX_raspunsTema_userId",
                table: "raspunsTema",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_sedinta_grupaId",
                table: "sedinta",
                column: "grupaId");

            migrationBuilder.CreateIndex(
                name: "IX_support_userId",
                table: "support",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_tema_userId",
                table: "tema",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abonament");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Disponibilitate");

            migrationBuilder.DropTable(
                name: "feedback");

            migrationBuilder.DropTable(
                name: "material");

            migrationBuilder.DropTable(
                name: "mesaj");

            migrationBuilder.DropTable(
                name: "notificare");

            migrationBuilder.DropTable(
                name: "participareGrupa");

            migrationBuilder.DropTable(
                name: "plata");

            migrationBuilder.DropTable(
                name: "predare");

            migrationBuilder.DropTable(
                name: "prezenta");

            migrationBuilder.DropTable(
                name: "raspunsTema");

            migrationBuilder.DropTable(
                name: "support");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "sedinta");

            migrationBuilder.DropTable(
                name: "tema");

            migrationBuilder.DropTable(
                name: "grupa");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "curs");
        }
    }
}
