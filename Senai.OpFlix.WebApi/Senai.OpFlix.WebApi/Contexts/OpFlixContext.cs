using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GeneroDomain> Genero { get; set; }
        public virtual DbSet<LancamentoDomain> Lancamento { get; set; }
        public virtual DbSet<TipoMetragemDomain> TipoMetragem { get; set; }
        public virtual DbSet<TipoUsuarioDomain> TipoUsuario { get; set; }
        public virtual DbSet<UsuarioDomain> Usuario { get; set; }

        // Unable to generate entity type for table 'dbo.LancamentoFavorito'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=M_Opflix;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneroDomain>(entity =>
            {
                entity.HasKey(e => e.IdGenero);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Genero__7D8FE3B292049137")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LancamentoDomain>(entity =>
            {
                entity.HasKey(e => e.IdLancamento);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Lancamen__7D8FE3B21B71E11C")
                    .IsUnique();

                entity.HasIndex(e => e.Sinopse)
                    .HasName("UQ__Lancamen__F4016225D2C00E51")
                    .IsUnique();

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Lancamento)
                    .HasForeignKey(d => d.IdGenero)
                    .HasConstraintName("FK__Lancament__IdGen__625A9A57");

                entity.HasOne(d => d.IdTipoMetragemNavigation)
                    .WithMany(p => p.Lancamento)
                    .HasForeignKey(d => d.IdTipoMetragem)
                    .HasConstraintName("FK__Lancament__IdTip__634EBE90");
            });

            modelBuilder.Entity<TipoMetragemDomain>(entity =>
            {
                entity.HasKey(e => e.IdTipoMetragem);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TipoMetr__7D8FE3B229709D6C")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuarioDomain>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TipoUsua__7D8FE3B27DA98DB1")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuarioDomain>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D105345780A444")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Usuario__7D8FE3B2EF7E0A8B")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__308E3499");
            });
        }
    }
}
