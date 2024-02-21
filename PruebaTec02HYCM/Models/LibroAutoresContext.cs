using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaTec02HYCM.Models
{
    public partial class LibroAutoresContext : DbContext
    {
        public LibroAutoresContext()
        {
        }

        public LibroAutoresContext(DbContextOptions<LibroAutoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-OAO2BUA;Database =LibroAutores;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autore>(entity =>
            {
                entity.HasKey(e => e.AutorId)
                    .HasName("PK__Autores__F58AE9290FCF1D58");

                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.GeneroLite)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.AutorId)
                    .HasConstraintName("FK__Libros__AutorId__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
