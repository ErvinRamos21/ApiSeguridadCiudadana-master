using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SeguridadCiudadana.Domain.Entities;

namespace SeguridadCiudadana.Infrastructure.Context
{
    public partial class SEGURIDADCIUDADANAContext : DbContext
    {
        public SEGURIDADCIUDADANAContext()
        {
        }

        public SEGURIDADCIUDADANAContext(DbContextOptions<SEGURIDADCIUDADANAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Categoriapeligro> Categoriapeligros { get; set; }
        public virtual DbSet<Direccione> Direcciones { get; set; }
        public virtual DbSet<Direccionessegura> Direccionesseguras { get; set; }
        public virtual DbSet<Estacion> Estacions { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Policia> Policias { get; set; }
        public virtual DbSet<Rango> Rangos { get; set; }
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-QFEKVLB1\\FERNS;Initial Catalog=SEGURIDADCIUDADANA;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.Idcargo)
                    .HasName("PK_IDCARGO");

                entity.ToTable("CARGOS");

                entity.Property(e => e.Idcargo).HasColumnName("IDCARGO");

                entity.Property(e => e.Nombrcargo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRCARGO");
            });

            modelBuilder.Entity<Categoriapeligro>(entity =>
            {
                entity.HasKey(e => e.Idpeligro)
                    .HasName("PK_IDPELIGRO");

                entity.ToTable("CATEGORIAPELIGRO");

                entity.Property(e => e.Idpeligro).HasColumnName("IDPELIGRO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Tipopeligro)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIPOPELIGRO");
            });

            modelBuilder.Entity<Direccione>(entity =>
            {
                entity.HasKey(e => e.Iddireccion)
                    .HasName("PK_IDDIRECCION");

                entity.ToTable("DIRECCIONES");

                entity.Property(e => e.Iddireccion).HasColumnName("IDDIRECCION");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CALLE");

                entity.Property(e => e.Colonia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COLONIA");

                entity.Property(e => e.Cruzamientos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CRUZAMIENTOS");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO");

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MUNICIPIO");
            });

            modelBuilder.Entity<Direccionessegura>(entity =>
            {
                entity.HasKey(e => e.Iddireccionsegura)
                    .HasName("PK_IDDIRECCIONSEGURA");

                entity.ToTable("DIRECCIONESSEGURAS");

                entity.Property(e => e.Iddireccionsegura).HasColumnName("IDDIRECCIONSEGURA");

                entity.Property(e => e.Idpeligro).HasColumnName("IDPELIGRO");

                entity.Property(e => e.Latitud).HasColumnName("LATITUD");

                entity.Property(e => e.Longitud).HasColumnName("LONGITUD");

                entity.HasOne(d => d.IdpeligroNavigation)
                    .WithMany(p => p.Direccionesseguras)
                    .HasForeignKey(d => d.Idpeligro)
                    .HasConstraintName("FK_IDPELIGRO");
            });

            modelBuilder.Entity<Estacion>(entity =>
            {
                entity.HasKey(e => e.Idestacion)
                    .HasName("PK_IDESTACION");

                entity.ToTable("ESTACION");

                entity.Property(e => e.Idestacion).HasColumnName("IDESTACION");

                entity.Property(e => e.Iddireccion).HasColumnName("IDDIRECCION");

                entity.Property(e => e.Nombreestacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREESTACION");

                entity.HasOne(d => d.IddireccionNavigation)
                    .WithMany(p => p.Estacions)
                    .HasForeignKey(d => d.Iddireccion)
                    .HasConstraintName("FK_IDDIRECCIONESTACION");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.Idgenero)
                    .HasName("PK_IDGENERO");

                entity.ToTable("GENEROS");

                entity.Property(e => e.Idgenero).HasColumnName("IDGENERO");

                entity.Property(e => e.Tipigenero)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIPIGENERO");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Idpersona);

                entity.ToTable("PERSONA");

                entity.Property(e => e.Idpersona).HasColumnName("IDPERSONA");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOS");

                entity.Property(e => e.Edad).HasColumnName("EDAD");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Policia>(entity =>
            {
                entity.HasKey(e => e.Idpolicias)
                    .HasName("PK_IDPOLICIAS");

                entity.ToTable("POLICIAS");

                entity.Property(e => e.Idpolicias).HasColumnName("IDPOLICIAS");

                entity.Property(e => e.Iddireccion).HasColumnName("IDDIRECCION");

                entity.Property(e => e.Idestacion).HasColumnName("IDESTACION");

                entity.Property(e => e.Idgenero).HasColumnName("IDGENERO");

                entity.Property(e => e.Idpersona).HasColumnName("IDPERSONA");

                entity.Property(e => e.Idrango).HasColumnName("IDRANGO");

                entity.Property(e => e.Idtipousuario).HasColumnName("IDTIPOUSUARIO");

                entity.Property(e => e.Numeroplaca).HasColumnName("NUMEROPLACA");

                entity.HasOne(d => d.IddireccionNavigation)
                    .WithMany(p => p.Policia)
                    .HasForeignKey(d => d.Iddireccion)
                    .HasConstraintName("FK_IDDIRECCIONPOLICIA");

                entity.HasOne(d => d.IdestacionNavigation)
                    .WithMany(p => p.Policia)
                    .HasForeignKey(d => d.Idestacion)
                    .HasConstraintName("FK_IDESTACIONPOLICIA");

                entity.HasOne(d => d.IdgeneroNavigation)
                    .WithMany(p => p.Policia)
                    .HasForeignKey(d => d.Idgenero)
                    .HasConstraintName("FK_IDGENEROPOLICIA");

                entity.HasOne(d => d.IdpersonaNavigation)
                    .WithMany(p => p.Policia)
                    .HasForeignKey(d => d.Idpersona)
                    .HasConstraintName("FK_IDPERSONAPOLICIA");

                entity.HasOne(d => d.IdrangoNavigation)
                    .WithMany(p => p.Policia)
                    .HasForeignKey(d => d.Idrango)
                    .HasConstraintName("FK_IDRANGOPOLICIA");

                entity.HasOne(d => d.IdtipousuarioNavigation)
                    .WithMany(p => p.Policia)
                    .HasForeignKey(d => d.Idtipousuario)
                    .HasConstraintName("FK_IDTIPOUSUARIOPOLICIA");
            });

            modelBuilder.Entity<Rango>(entity =>
            {
                entity.HasKey(e => e.Idrango)
                    .HasName("PK_IDRANGO");

                entity.ToTable("RANGO");

                entity.Property(e => e.Idrango).HasColumnName("IDRANGO");

                entity.Property(e => e.Tipoderango)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIPODERANGO");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.Idtipousuario)
                    .HasName("PK_IDTIPOUSUARIO");

                entity.ToTable("TIPOUSUARIOS");

                entity.Property(e => e.Idtipousuario).HasColumnName("IDTIPOUSUARIO");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASEÑA");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Idcargo).HasColumnName("IDCARGO");

                entity.HasOne(d => d.IdcargoNavigation)
                    .WithMany(p => p.Tipousuarios)
                    .HasForeignKey(d => d.Idcargo)
                    .HasConstraintName("FK_IDCARGO");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK_IDUSUARIO");

                entity.ToTable("USUARIO");

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.Iddireccion).HasColumnName("IDDIRECCION");

                entity.Property(e => e.Idgenero).HasColumnName("IDGENERO");

                entity.Property(e => e.Idpersona).HasColumnName("IDPERSONA");

                entity.Property(e => e.Idtipousuario).HasColumnName("IDTIPOUSUARIO");

                entity.HasOne(d => d.IddireccionNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Iddireccion)
                    .HasConstraintName("FK_IDDIRECCION");

                entity.HasOne(d => d.IdgeneroNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idgenero)
                    .HasConstraintName("FK_IDGENERO");

                entity.HasOne(d => d.IdpersonaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idpersona)
                    .HasConstraintName("FK_IDPERSONA");

                entity.HasOne(d => d.IdtipousuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idtipousuario)
                    .HasConstraintName("FK_IDTIPOUSUARIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
