using BappDominio.Entidades;
using BappDominio.ObjetosValor.Barbero;
using BappDominio.ObjetosValor.Cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;


namespace BarberyApp.Infraestructura;

public partial class ContextoBarberyApp : DbContext
{
    public ContextoBarberyApp()
    {
    }

    public ContextoBarberyApp(DbContextOptions<ContextoBarberyApp> options)
        : base(options)
    {
    }

    public virtual DbSet<Barbero> Barberos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<EstiloCorte> EstiloCorte { get; set; }
    public virtual DbSet<Localbarbero> LocalBarbero { get; set; }
    public virtual DbSet<Cita> Citas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barbero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Barberos_Id");

            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.Rol)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("usuario");
                                                                    


            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasConversion(
                    v => v.ToString(), 
                    v => new NombreBarbero(v) 
                );


            entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasConversion(
                    v => v.ToString(), 
                    v => new ApellidoBarbero(v) 
                );

         
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasConversion(
                    v => v.ToString(), 
                    v => new EmailBarbero(v) 
                );


            entity.Property(e => e.Contraseña)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnType("varchar(255)")
                .HasConversion(
                    v => v.ToString(),
                    v => new Contraseñabarbero(v) 
                );
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Clientes");

            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasConversion(
                    v => v.ToString(), 
                    v => new ClienteNombre(v) 
                );


            entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasConversion(
                    v => v.ToString(),
                    v => new ClienteApellido(v) 
                );


            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasConversion(
                    v => v.ToString(), 
                    v => new ClienteEmail(v) 
                );


            entity.Property(e => e.Contraseña)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasConversion(
                    v => v.ToString(), 
                    v => new ClienteContraseña(v) 
                );
        });


        modelBuilder.Entity<EstiloCorte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EstiloCo__3214EC076AFB17AD");
            entity.Property(e => e.Id).HasColumnName("Id").HasColumnType("uniqueidentifier");
            entity.Property(e => e.LocalId).HasColumnName("LocalId").HasColumnType("uniqueidentifier");
            entity.Property(e => e.Nombre).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Descripcion).HasColumnType("nvarchar(max)");
            entity.Property(e => e.GaleriaFotos).HasColumnType("nvarchar(max)").HasConversion( v => string.Join(',', v), v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList() 
            );
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            entity.HasOne(d => d.LocalBarbero).WithMany().HasForeignKey(d => d.LocalId).HasConstraintName("FK_EstiloCorte_LocalBarbero_ID");
        });




        modelBuilder.Entity<Localbarbero>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_LocalBarbero");
                entity.Property(e => e.Id).HasColumnName("Id").HasColumnType("uniqueidentifier");
                entity.Property(e => e.BarberoId).HasColumnName("BarberoId").HasColumnType("uniqueidentifier");
                entity.Property(e => e.NombreBarberia).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Descripcion).HasColumnType("nvarchar(max)");
                entity.Property(e => e.Ubicacion).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.NumeroContacto).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Horario).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Foto).IsUnicode(false);
                entity.HasOne(d => d.Barbero).WithMany().HasForeignKey(d => d.BarberoId).HasConstraintName("FK__LocalBarb__Barbe__18EBB532");
            });
        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.ToTable("Citas");
            entity.HasKey(e => e.Id).HasName("PK_Citas");

            // Mapeo de propiedades
            entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entity.Property(e => e.LocalBarberoId).HasColumnName("localbarbero_id").IsRequired();
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id").IsRequired();
            entity.Property(e => e.FechaHora).HasColumnName("fecha_hora").IsRequired();
            entity.Property(e => e.Estado).HasColumnName("estado").IsRequired();
            entity.Property(e => e.Comentarios).HasColumnName("comentarios");
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.FechaActualizacion).HasColumnName("fecha_actualizacion").HasDefaultValueSql("GETDATE()");
            //entity.Ignore(e => e.FechaActualizacion);

            // Definición de restricciones de clave foránea
            entity.HasOne<Localbarbero>()
                .WithMany()
                .HasForeignKey(d => d.LocalBarberoId)
                .HasConstraintName("FK_Citas_LocalBarbero");

            entity.HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Citas_Cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
