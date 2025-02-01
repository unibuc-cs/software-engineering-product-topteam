using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend_MT.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grupa_AspNetUsers_userId",
                table: "grupa");

            migrationBuilder.DropForeignKey(
                name: "FK_notificare_AspNetUsers_userId",
                table: "notificare");

            migrationBuilder.DropForeignKey(
                name: "FK_notificare_grupa_grupaId",
                table: "notificare");

            migrationBuilder.DropTable(
                name: "abonament");

            migrationBuilder.DropTable(
                name: "predare");

            migrationBuilder.DropIndex(
                name: "IX_notificare_grupaId",
                table: "notificare");

            migrationBuilder.DropColumn(
                name: "grupaId",
                table: "notificare");

            migrationBuilder.DropColumn(
                name: "receptorId",
                table: "notificare");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "grupa",
                newName: "userProfesorId");

            migrationBuilder.RenameIndex(
                name: "IX_grupa_userId",
                table: "grupa",
                newName: "IX_grupa_userProfesorId");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "AspNetUsers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "AspNetUsers",
                newName: "Email");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "notificare",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_grupa_AspNetUsers_userProfesorId",
                table: "grupa",
                column: "userProfesorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notificare_AspNetUsers_userId",
                table: "notificare",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grupa_AspNetUsers_userProfesorId",
                table: "grupa");

            migrationBuilder.DropForeignKey(
                name: "FK_notificare_AspNetUsers_userId",
                table: "notificare");

            migrationBuilder.RenameColumn(
                name: "userProfesorId",
                table: "grupa",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_grupa_userProfesorId",
                table: "grupa",
                newName: "IX_grupa_userId");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "AspNetUsers",
                newName: "email");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "notificare",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "grupaId",
                table: "notificare",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "receptorId",
                table: "notificare",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "abonament",
                columns: table => new
                {
                    abonamentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cursId = table.Column<int>(type: "integer", nullable: false),
                    userId = table.Column<int>(type: "integer", nullable: false)
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
                name: "predare",
                columns: table => new
                {
                    predareId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cursId = table.Column<int>(type: "integer", nullable: false),
                    userId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_notificare_grupaId",
                table: "notificare",
                column: "grupaId");

            migrationBuilder.CreateIndex(
                name: "IX_abonament_cursId",
                table: "abonament",
                column: "cursId");

            migrationBuilder.CreateIndex(
                name: "IX_abonament_userId",
                table: "abonament",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_predare_cursId",
                table: "predare",
                column: "cursId");

            migrationBuilder.CreateIndex(
                name: "IX_predare_userId",
                table: "predare",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_grupa_AspNetUsers_userId",
                table: "grupa",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notificare_AspNetUsers_userId",
                table: "notificare",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_notificare_grupa_grupaId",
                table: "notificare",
                column: "grupaId",
                principalTable: "grupa",
                principalColumn: "grupaId");
        }
    }
}
