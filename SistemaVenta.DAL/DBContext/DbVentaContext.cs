using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.DBContext;

public partial class DbVentaContext : DbContext
{
    public DbVentaContext()
    {
    }

    public DbVentaContext(DbContextOptions<DbVentaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRole> MenuRoles { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3213E83FC7A0A1CD");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("es_activo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleV__3213E83F95F73029");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.VentaId).HasColumnName("venta_id");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__DetalleVe__produ__17F790F9");

            entity.HasOne(d => d.Venta).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("FK__DetalleVe__venta__17036CC0");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("icono");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<MenuRole>(entity =>
        {
            entity.ToTable("MenuRole");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuRoles)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK_MenuRole_Menu");

            entity.HasOne(d => d.Role).WithMany(p => p.MenuRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_MenuRole_Role");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3213E83F2AEDB8AE");

            entity.ToTable("Producto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("es_activo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Producto__catego__123EB7A3");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3213E83F63514F73");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83FF94C5D4F");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clave)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("es_activo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Usuario__role_id__02FC7413");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venta__3213E83FFBAED8A1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("numero_documento");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_pago");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
