using System;
using System.Collections.Generic;
using Einstein.Core.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Einstein.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnoConclusaoEnsinoMedio = table.Column<int>(type: "integer", nullable: true),
                    JaRealizouEnem = table.Column<bool>(type: "boolean", nullable: false),
                    MediaGeralEnem = table.Column<float>(type: "real", nullable: true),
                    NotaRedacaoEnem = table.Column<float>(type: "real", nullable: true),
                    NotaExatasEnem = table.Column<float>(type: "real", nullable: true),
                    NotaCienciasDaNaturezaEnem = table.Column<float>(type: "real", nullable: true),
                    NotaHumanasEnem = table.Column<float>(type: "real", nullable: true),
                    NotaLinguagensEnem = table.Column<float>(type: "real", nullable: true),
                    EstaEmpregado = table.Column<bool>(type: "boolean", nullable: false),
                    ExAluno = table.Column<bool>(type: "boolean", nullable: false),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CEP = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Logradouro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<int>(type: "integer", nullable: true),
                    Complemento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UF = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Latitude = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Longitude = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Facebook = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Instagram = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    RG = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NormalizedName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    SecurityStamp = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Graduacao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TrabalhaEmOutroLocal = table.Column<bool>(type: "boolean", nullable: false),
                    LocalOndeTrabalha = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CargaHorariaSemanal = table.Column<float>(type: "real", nullable: false),
                    Horario = table.Column<ICollection<ProfessorHorario>>(type: "jsonb", nullable: true),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CEP = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Logradouro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<int>(type: "integer", nullable: true),
                    Complemento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UF = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Latitude = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Longitude = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Facebook = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Instagram = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    RG = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("54aa4e4e-cea2-441d-a988-4dc87fe1790f"), "d92ec6f0-d4e9-4cf1-8010-5ddf960bb08c", "Professor", "PROFESSOR" },
                    { new Guid("6320e648-8fb6-4ed1-a5bd-8d789d4003ac"), "3dfa4ee9-dc1f-4ad7-bd63-a02f1534d36c", "Secretaria", "SECRETARIA" },
                    { new Guid("bed12cf3-5050-436b-9c9e-134dc9a1660b"), "5da8be1a-ad83-4e99-b041-069b2d48b057", "Admin", "ADMIN" },
                    { new Guid("c5889c26-0d06-42c6-b588-1ba19130b5d3"), "b6bb3d87-7ffc-41db-aa41-322fa3a1b61e", "Aluno", "ALUNO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

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
                name: "Professor");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
