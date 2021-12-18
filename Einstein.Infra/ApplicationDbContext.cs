using Einstein.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Einstein.Infra
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasQueryFilter(x => x.Ativo);
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(entity => entity.Id);

                entity.HasQueryFilter(x => x.Ativo);
            });

            modelBuilder.Entity<IdentityUser<Guid>>(entity =>
            {
                entity.Property(x => x.UserName).HasMaxLength(100).HasColumnType("varchar").IsRequired();
                entity.Property(x => x.NormalizedUserName).HasMaxLength(100).HasColumnType("varchar").IsRequired();
                entity.Property(x => x.PhoneNumber).HasMaxLength(15).HasColumnType("varchar").IsRequired();
                entity.Property(x => x.PasswordHash).HasMaxLength(300).IsRequired();
                entity.Property(x => x.SecurityStamp).HasMaxLength(300);
                entity.Property(x => x.ConcurrencyStamp).HasMaxLength(300);
                entity.Property(x => x.Email).HasMaxLength(150).HasColumnType("varchar").IsRequired();
                entity.Property(x => x.NormalizedEmail).HasMaxLength(150).HasColumnType("varchar").IsRequired();
            });

            modelBuilder.Entity<IdentityRole<Guid>>(entity => 
            {
                entity.Property(x => x.Name).HasMaxLength(100).HasColumnType("varchar").IsRequired();
                entity.Property(x => x.NormalizedName).HasMaxLength(100).HasColumnType("varchar").IsRequired();
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
}
