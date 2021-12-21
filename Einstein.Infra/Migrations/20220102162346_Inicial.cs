using System;
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
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modalidade",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotivoAusencia",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivoAusencia", x => x.Id);
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
                    ValorHoraAula = table.Column<decimal>(type: "numeric", nullable: false),
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
                name: "ProfessorFrequencia",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfessorConfiguracaoHorarioId = table.Column<int>(type: "integer", nullable: false),
                    Presente = table.Column<bool>(type: "boolean", nullable: false),
                    MotivoAusenciaId = table.Column<short>(type: "smallint", nullable: true),
                    Observacoes = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorFrequencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "AlunoCurso",
                columns: table => new
                {
                    AlunoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CursoId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoCurso", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunoCurso_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoCurso_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimentoFinanceiro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoMovimentoFinanceiro = table.Column<int>(type: "integer", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Parcelas = table.Column<short>(type: "smallint", nullable: false),
                    ValorEntrada = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorDesconto = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorPago = table.Column<decimal>(type: "numeric", nullable: false),
                    FormaPagamentoId = table.Column<short>(type: "smallint", nullable: false),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentoFinanceiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentoFinanceiro_FormaPagamento_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoModalidade",
                columns: table => new
                {
                    CursoId = table.Column<short>(type: "smallint", nullable: false),
                    ModalidadeId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoModalidade", x => new { x.CursoId, x.ModalidadeId });
                    table.ForeignKey(
                        name: "FK_CursoModalidade_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoModalidade_Modalidade_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoProfessor",
                columns: table => new
                {
                    CursoId = table.Column<short>(type: "smallint", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoProfessor", x => new { x.CursoId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_CursoProfessor_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoProfessor_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaProfessor",
                columns: table => new
                {
                    DisciplinaId = table.Column<short>(type: "smallint", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaProfessor", x => new { x.DisciplinaId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_DisciplinaProfessor_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaProfessor_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorConfiguracao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CursoId = table.Column<short>(type: "smallint", nullable: false),
                    DisciplinaId = table.Column<short>(type: "smallint", nullable: false),
                    ModalidadeId = table.Column<short>(type: "smallint", nullable: false),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorConfiguracao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorConfiguracao_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorConfiguracao_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorConfiguracao_Modalidade_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorConfiguracao_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoTurno",
                columns: table => new
                {
                    CursoId = table.Column<short>(type: "smallint", nullable: false),
                    TurnoId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoTurno", x => new { x.CursoId, x.TurnoId });
                    table.ForeignKey(
                        name: "FK_CursoTurno_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoTurno_Turno_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorarioConfiguracao",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DiaDaSemana = table.Column<int>(type: "integer", nullable: false),
                    HoraInicio = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    HoraFim = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    TurnoId = table.Column<short>(type: "smallint", nullable: false),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioConfiguracao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioConfiguracao_Turno_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorConfiguracaoHorario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfessorConfiguracaoId = table.Column<int>(type: "integer", nullable: false),
                    HorarioConfiguracaoId = table.Column<short>(type: "smallint", nullable: false),
                    IP = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorConfiguracaoHorario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorConfiguracaoHorario_HorarioConfiguracao_HorarioCon~",
                        column: x => x.HorarioConfiguracaoId,
                        principalTable: "HorarioConfiguracao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorConfiguracaoHorario_ProfessorConfiguracao_Professo~",
                        column: x => x.ProfessorConfiguracaoId,
                        principalTable: "ProfessorConfiguracao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("377bd054-2c01-4489-8e0d-86d2fedc2bed"), "5801b13b-b181-4ca0-90ba-08ed5d563531", "Secretaria", "SECRETARIA" },
                    { new Guid("9add3f7d-ad05-4adb-8743-cbf895555517"), "a26339e2-371e-43b7-bb27-960ab42a8f0e", "Aluno", "ALUNO" },
                    { new Guid("c8ddb606-0256-46f6-bbaf-4a6215a72ad9"), "10c66ab3-65b2-4a30-9ae4-5945ee6ed1f8", "Professor", "PROFESSOR" },
                    { new Guid("d591d926-0e57-45aa-a2f7-33348a346116"), "7883ab1e-6f44-4c76-8c22-73fa2108e900", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Ativo", "DataAlteracao", "DataCriacao", "IP", "Nome", "UsuarioAlteracaoId", "UsuarioCriacaoId" },
                values: new object[,]
                {
                    { (short)1, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(1613), "localhost", "Extensivo", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)2, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(1616), "localhost", "Intensivo", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)3, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(1617), "localhost", "Super Intensivo", null, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "Id", "Ativo", "DataAlteracao", "DataCriacao", "IP", "Nome", "UsuarioAlteracaoId", "UsuarioCriacaoId" },
                values: new object[,]
                {
                    { (short)1, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(2448), "localhost", "Português", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)2, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(2449), "localhost", "Matemática", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)3, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(2450), "localhost", "Geografia", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)4, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(2451), "localhost", "História", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)5, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(2451), "localhost", "Física", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)6, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(2452), "localhost", "Química", null, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "FormaPagamento",
                columns: new[] { "Id", "Ativo", "DataAlteracao", "DataCriacao", "Descricao", "IP", "UsuarioAlteracaoId", "UsuarioCriacaoId" },
                values: new object[,]
                {
                    { (short)1, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 228, DateTimeKind.Local).AddTicks(7969), "Dinheiro", "localhost", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)2, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 228, DateTimeKind.Local).AddTicks(7977), "Boleto", "localhost", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)3, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 228, DateTimeKind.Local).AddTicks(7978), "Cartão de Crédito", "localhost", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)4, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 228, DateTimeKind.Local).AddTicks(7979), "Cartão de Débito", "localhost", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)5, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 228, DateTimeKind.Local).AddTicks(7979), "Pix", "localhost", null, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Modalidade",
                columns: new[] { "Id", "Ativo", "DataAlteracao", "DataCriacao", "IP", "Nome", "UsuarioAlteracaoId", "UsuarioCriacaoId" },
                values: new object[,]
                {
                    { (short)1, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(2168), "localhost", "Presencial", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)2, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(2170), "localhost", "Online", null, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Turno",
                columns: new[] { "Id", "Ativo", "DataAlteracao", "DataCriacao", "IP", "Nome", "UsuarioAlteracaoId", "UsuarioCriacaoId" },
                values: new object[,]
                {
                    { (short)1, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(1867), "localhost", "Matutino", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)2, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(1870), "localhost", "Vespertino", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { (short)3, true, null, new DateTime(2022, 1, 2, 13, 23, 46, 229, DateTimeKind.Local).AddTicks(1870), "localhost", "Noturno", null, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCurso_CursoId",
                table: "AlunoCurso",
                column: "CursoId");

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

            migrationBuilder.CreateIndex(
                name: "IX_CursoModalidade_ModalidadeId",
                table: "CursoModalidade",
                column: "ModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoProfessor_ProfessorId",
                table: "CursoProfessor",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoTurno_TurnoId",
                table: "CursoTurno",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaProfessor_ProfessorId",
                table: "DisciplinaProfessor",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioConfiguracao_TurnoId",
                table: "HorarioConfiguracao",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoFinanceiro_FormaPagamentoId",
                table: "MovimentoFinanceiro",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorConfiguracao_CursoId",
                table: "ProfessorConfiguracao",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorConfiguracao_DisciplinaId",
                table: "ProfessorConfiguracao",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorConfiguracao_ModalidadeId",
                table: "ProfessorConfiguracao",
                column: "ModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorConfiguracao_ProfessorId",
                table: "ProfessorConfiguracao",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorConfiguracaoHorario_HorarioConfiguracaoId",
                table: "ProfessorConfiguracaoHorario",
                column: "HorarioConfiguracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorConfiguracaoHorario_ProfessorConfiguracaoId",
                table: "ProfessorConfiguracaoHorario",
                column: "ProfessorConfiguracaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoCurso");

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
                name: "CursoModalidade");

            migrationBuilder.DropTable(
                name: "CursoProfessor");

            migrationBuilder.DropTable(
                name: "CursoTurno");

            migrationBuilder.DropTable(
                name: "DisciplinaProfessor");

            migrationBuilder.DropTable(
                name: "MotivoAusencia");

            migrationBuilder.DropTable(
                name: "MovimentoFinanceiro");

            migrationBuilder.DropTable(
                name: "ProfessorConfiguracaoHorario");

            migrationBuilder.DropTable(
                name: "ProfessorFrequencia");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FormaPagamento");

            migrationBuilder.DropTable(
                name: "HorarioConfiguracao");

            migrationBuilder.DropTable(
                name: "ProfessorConfiguracao");

            migrationBuilder.DropTable(
                name: "Turno");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Modalidade");

            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
