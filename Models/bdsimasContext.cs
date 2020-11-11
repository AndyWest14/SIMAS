using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SIMAS.Models
{
    public partial class bdsimasContext : DbContext
    {
        public bdsimasContext()
        {
        }

        public bdsimasContext(DbContextOptions<bdsimasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<Noticias> Noticias { get; set; }
        public virtual DbSet<Subcategorias> Subcategorias { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost; user id=root; password=root; database=bdsimas;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.ToTable("categorias");

                entity.Property(e => e.IdCategoria).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDocumento);

                entity.ToTable("documento");

                entity.HasIndex(e => e.IdCategoria)
                    .HasName("IdCategoriaDocumento_idx");

                entity.HasIndex(e => e.IdSubCategoria)
                    .HasName("IdSubCategoriaDocumento_idx");

                entity.Property(e => e.IdDocumento).HasColumnType("int(11)");

                entity.Property(e => e.IdCategoria).HasColumnType("int(11)");

                entity.Property(e => e.IdSubCategoria).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Documento)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdCategoriaDocumento");

                entity.HasOne(d => d.IdSubCategoriaNavigation)
                    .WithMany(p => p.Documento)
                    .HasForeignKey(d => d.IdSubCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdSubCategoriaDocumento");
            });

            modelBuilder.Entity<Noticias>(entity =>
            {
                entity.HasKey(e => e.IdNoticias);

                entity.ToTable("noticias");

                entity.Property(e => e.IdNoticias)
                    .HasColumnName("idNoticias")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Autor).HasColumnType("varchar(45)");

                entity.Property(e => e.Cuerpo)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.DescripcionCorta)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.Encabezado)
                    .IsRequired()
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.VideoUrl)
                    .HasColumnName("VideoURL")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Subcategorias>(entity =>
            {
                entity.HasKey(e => e.Idsubcategorias);

                entity.ToTable("subcategorias");

                entity.HasIndex(e => e.IdCategoria)
                    .HasName("IdCategoria_idx");

                entity.Property(e => e.Idsubcategorias).HasColumnType("int(11)");

                entity.Property(e => e.IdCategoria).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Subcategorias)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdCategoria");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Rol).HasColumnType("varchar(45)");
            });
        }
    }
}
