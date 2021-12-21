using Einstein.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Einstein.Infra
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Aluno> Aluno { get; set; } = default!;
        public virtual DbSet<Professor> Professor { get; set; } = default!;
        public virtual DbSet<FormaPagamento> FormaPagamento { get; set; } = default!;
        public virtual DbSet<MovimentoFinanceiro> MovimentoFinanceiro { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovimentoFinanceiro>(entity =>
            {
                entity.HasQueryFilter(x => x.Ativo);

                entity.Property(x => x.DataHora).HasColumnType("timestamp");

                entity.Property(x => x.IP).HasMaxLength(20);
                entity.Property(x => x.DataCriacao).HasColumnType("timestamp");
                entity.Property(x => x.DataAlteracao).HasColumnType("timestamp");
            });

            modelBuilder.Entity<FormaPagamento>(entity =>
            {
                entity.HasQueryFilter(x => x.Ativo);

                entity.Property(x => x.IP).HasMaxLength(20);
                entity.Property(x => x.DataCriacao).HasColumnType("timestamp");
                entity.Property(x => x.DataAlteracao).HasColumnType("timestamp");

                entity.HasData(new[]
                {
                    new FormaPagamento
                    {
                        Id = 1,
                        Descricao = "Dinheiro",                        
                    },
                    new FormaPagamento
                    {
                        Id = 2,
                        Descricao = "Boleto",
                    },
                    new FormaPagamento
                    {
                        Id = 3,
                        Descricao = "Cartão de Crédito",
                    },
                    new FormaPagamento
                    {
                        Id = 4,
                        Descricao = "Cartão de Débito",
                    },
                    new FormaPagamento
                    {
                        Id = 5,
                        Descricao = "Pix",
                    },                    
                });
            });

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasQueryFilter(x => x.Ativo);

                entity.ConfigurarPropriedadesComunsDePessoaFisica();
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(entity => entity.Id);

                entity.HasQueryFilter(x => x.Ativo);

                entity.ConfigurarPropriedadesComunsDePessoaFisica();

                entity.Property(x => x.Graduacao).HasMaxLength(100);
                entity.Property(x => x.LocalOndeTrabalha).HasMaxLength(100);                
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(x => x.Nome).HasMaxLength(100).IsRequired();

                entity.Property(x => x.IP).HasMaxLength(20);
                entity.Property(x => x.DataCriacao).HasColumnType("timestamp");
                entity.Property(x => x.DataAlteracao).HasColumnType("timestamp");

                entity.HasData(new[]
                {
                    new Curso
                    {
                        Id = 1,
                        Nome = "Extensivo",
                    },
                    new Curso
                    {
                        Id = 2,
                        Nome = "Intensivo",
                    },
                    new Curso
                    {
                        Id = 3,
                        Nome = "Super Intensivo",
                    },
                });
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.Property(x => x.Nome).HasMaxLength(100).IsRequired();

                entity.Property(x => x.IP).HasMaxLength(20);
                entity.Property(x => x.DataCriacao).HasColumnType("timestamp");
                entity.Property(x => x.DataAlteracao).HasColumnType("timestamp");

                entity.HasData(new[]
                {
                    new Turno
                    {
                        Id = 1,
                        Nome = "Matutino",
                    },
                    new Turno
                    {
                        Id = 2,
                        Nome = "Vespertino",
                    },
                    new Turno
                    {
                        Id = 3,
                        Nome = "Noturno",
                    },
                });
            });

            modelBuilder.Entity<Modalidade>(entity =>
            {
                entity.Property(x => x.Nome).HasMaxLength(100).IsRequired();

                entity.Property(x => x.IP).HasMaxLength(20);
                entity.Property(x => x.DataCriacao).HasColumnType("timestamp");
                entity.Property(x => x.DataAlteracao).HasColumnType("timestamp");

                entity.HasData(new[]
                {
                    new Modalidade
                    {
                        Id = 1,
                        Nome = "Presencial",
                    },
                    new Modalidade
                    {
                        Id = 2,
                        Nome = "Online",
                    },
                });
            });

            modelBuilder.Entity<Disciplina>(entity =>
            {
                entity.Property(x => x.Nome).HasMaxLength(100).IsRequired();

                entity.Property(x => x.IP).HasMaxLength(20);
                entity.Property(x => x.DataCriacao).HasColumnType("timestamp");
                entity.Property(x => x.DataAlteracao).HasColumnType("timestamp");

                entity.HasData(new[]
                {
                    new Disciplina
                    {
                        Id = 1,
                        Nome = "Português",
                    },
                    new Disciplina
                    {
                        Id = 2,
                        Nome = "Matemática",
                    },
                    new Disciplina
                    {
                        Id = 3,
                        Nome = "Geografia",
                    },
                    new Disciplina
                    {
                        Id = 4,
                        Nome = "História",
                    },
                    new Disciplina
                    {
                        Id = 5,
                        Nome = "Física",
                    },
                    new Disciplina
                    {
                        Id = 6,
                        Nome = "Química",
                    },
                });
            });

            modelBuilder.Entity<HorarioConfiguracao>(entity =>
            {
                entity.Property(x => x.Descricao).HasMaxLength(100).IsRequired();

                entity.Property(x => x.IP).HasMaxLength(20);
                entity.Property(x => x.DataCriacao).HasColumnType("timestamp");
                entity.Property(x => x.DataAlteracao).HasColumnType("timestamp");
            });

            modelBuilder.Entity<ProfessorConfiguracao>(entity =>
            {                
                entity.Property(x => x.IP).HasMaxLength(20);
                entity.Property(x => x.DataCriacao).HasColumnType("timestamp");
                entity.Property(x => x.DataAlteracao).HasColumnType("timestamp");
            });

            modelBuilder.Entity<ProfessorConfiguracaoHorario>(entity =>
            {
                entity.Property(x => x.IP).HasMaxLength(20);
                entity.Property(x => x.DataCriacao).HasColumnType("timestamp");
                entity.Property(x => x.DataAlteracao).HasColumnType("timestamp");
            });

            modelBuilder.Entity<ProfessorFrequencia>(entity =>
            {
                entity.Property(x => x.Observacoes).HasMaxLength(300);

                entity.Property(x => x.IP).HasMaxLength(20);
                entity.Property(x => x.DataCriacao).HasColumnType("timestamp");
                entity.Property(x => x.DataAlteracao).HasColumnType("timestamp");
            });

            modelBuilder.Entity<MotivoAusencia>(entity =>
            {
                entity.Property(x => x.Descricao).HasMaxLength(100);

                entity.Property(x => x.IP).HasMaxLength(20);
                entity.Property(x => x.DataCriacao).HasColumnType("timestamp");
                entity.Property(x => x.DataAlteracao).HasColumnType("timestamp");
            });

            modelBuilder.Entity<IdentityUser<Guid>>(entity =>
            {
                entity.Property(x => x.UserName).HasMaxLength(100).IsRequired();
                entity.Property(x => x.NormalizedUserName).HasMaxLength(100).IsRequired();
                entity.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();
                entity.Property(x => x.PasswordHash).HasMaxLength(300).IsRequired();
                entity.Property(x => x.SecurityStamp).HasMaxLength(300);
                entity.Property(x => x.ConcurrencyStamp).HasMaxLength(300);
                entity.Property(x => x.Email).HasMaxLength(150).IsRequired();
                entity.Property(x => x.NormalizedEmail).HasMaxLength(150).IsRequired();
            });

            modelBuilder.Entity<IdentityRole<Guid>>(entity =>
            {
                entity.Property(x => x.Name).HasMaxLength(100).IsRequired();
                entity.Property(x => x.NormalizedName).HasMaxLength(100).IsRequired();
                entity.Property(x => x.ConcurrencyStamp).HasMaxLength(300);

                entity.HasData(new IdentityRole<Guid>[]
                {
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "Admin",
                        NormalizedName = "Admin".ToUpper(),
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "Professor",
                        NormalizedName = "Professor".ToUpper(),
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "Aluno",
                        NormalizedName = "Aluno".ToUpper(),
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "Secretaria",
                        NormalizedName = "Secretaria".ToUpper(),
                    },
                });
            });
        }
    }

    public static class EntitiesConfigExtensions
    {
        public static void ConfigurarPropriedadesComunsDePessoaFisica<T>(this Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> entity) where T : PessoaFisica
        {
            entity.Property(x => x.Email).HasMaxLength(150).IsRequired();
            entity.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Sobrenome).HasMaxLength(100).IsRequired();
            entity.Property(x => x.DataNascimento).HasColumnType("date").IsRequired();
            entity.Property(x => x.RG).HasMaxLength(20);
            entity.Property(x => x.CPF).HasMaxLength(14);

            entity.Property(x => x.Instagram).HasMaxLength(300);
            entity.Property(x => x.Facebook).HasMaxLength(300);

            entity.Property(x => x.Telefone).HasMaxLength(20);
            entity.Property(x => x.Celular).HasMaxLength(20);

            entity.Property(x => x.CEP).HasMaxLength(10);
            entity.Property(x => x.UF).HasMaxLength(2);
            entity.Property(x => x.Cidade).HasMaxLength(100);
            entity.Property(x => x.Bairro).HasMaxLength(100);
            entity.Property(x => x.Logradouro).HasMaxLength(100);
            entity.Property(x => x.Complemento).HasMaxLength(100);

            entity.Property(x => x.IP).HasMaxLength(20);
            entity.Property(x => x.DataCriacao).HasColumnType("timestamp");
            entity.Property(x => x.DataAlteracao).HasColumnType("timestamp");

            entity.Property(x => x.Latitude).HasMaxLength(20);
            entity.Property(x => x.Longitude).HasMaxLength(20);
        }
    }
}
