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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

                entity.Property(x => x.Horario).HasColumnType("jsonb");
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
