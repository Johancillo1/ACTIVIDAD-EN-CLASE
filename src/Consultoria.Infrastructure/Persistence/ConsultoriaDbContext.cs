using Consultoria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Consultoria.Infrastructure.Persistence;

public class ConsultoriaDbContext : DbContext
{
    public ConsultoriaDbContext(DbContextOptions<ConsultoriaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Empleado> Empleados { get; set; }
    public virtual DbSet<GastosProyecto> GastosProyectos { get; set; }
    public virtual DbSet<Hito> Hitos { get; set; }
    public virtual DbSet<InteraccionesCliente> InteraccionesClientes { get; set; }
    public virtual DbSet<Proyecto> Proyectos { get; set; }
    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");
            entity.ToTable("clientes");
            entity.HasIndex(e => e.Email, "email").IsUnique();
            entity.Property(e => e.IdCliente).HasColumnType("int(11)").HasColumnName("id_cliente");
            entity.Property(e => e.Email).HasMaxLength(100).HasColumnName("email");
            entity.Property(e => e.Empresa).HasMaxLength(100).HasColumnName("empresa");
            entity.Property(e => e.NombreContacto).HasMaxLength(100).HasColumnName("nombre_contacto");
            entity.Property(e => e.Telefono).HasMaxLength(20).HasColumnName("telefono");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PRIMARY");
            entity.ToTable("empleados");
            entity.HasIndex(e => e.Email, "email").IsUnique();
            entity.Property(e => e.IdEmpleado).HasColumnType("int(11)").HasColumnName("id_empleado");
            entity.Property(e => e.Activo).HasDefaultValueSql("'1'").HasColumnName("activo");
            entity.Property(e => e.Email).HasMaxLength(100).HasColumnName("email");
            entity.Property(e => e.Nombre).HasMaxLength(100).HasColumnName("nombre");
            entity.Property(e => e.Rol).HasMaxLength(50).HasColumnName("rol");
        });

        modelBuilder.Entity<GastosProyecto>(entity =>
        {
            entity.HasKey(e => e.IdGasto).HasName("PRIMARY");
            entity.ToTable("gastos_proyecto");
            entity.HasIndex(e => e.IdProyecto, "id_proyecto");
            entity.Property(e => e.IdGasto).HasColumnType("int(11)").HasColumnName("id_gasto");
            entity.Property(e => e.Categoria).HasMaxLength(50).HasColumnName("categoria");
            entity.Property(e => e.Concepto).HasMaxLength(150).HasColumnName("concepto");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdProyecto).HasColumnType("int(11)").HasColumnName("id_proyecto");
            entity.Property(e => e.MontoReal).HasPrecision(10, 2).HasColumnName("monto_real");
            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.GastosProyectos)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("gastos_proyecto_ibfk_1");
        });

        modelBuilder.Entity<Hito>(entity =>
        {
            entity.HasKey(e => e.IdHito).HasName("PRIMARY");
            entity.ToTable("hitos");
            entity.HasIndex(e => e.IdProyecto, "id_proyecto");
            entity.Property(e => e.IdHito).HasColumnType("int(11)").HasColumnName("id_hito");
            entity.Property(e => e.Estado).HasMaxLength(20).HasDefaultValueSql("'Pendiente'").HasColumnName("estado");
            entity.Property(e => e.FechaAlcanzada).HasColumnName("fecha_alcanzada");
            entity.Property(e => e.FechaPlanificada).HasColumnName("fecha_planificada");
            entity.Property(e => e.IdProyecto).HasColumnType("int(11)").HasColumnName("id_proyecto");
            entity.Property(e => e.Nombre).HasMaxLength(100).HasColumnName("nombre");
            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Hitos)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("hitos_ibfk_1");
        });

        modelBuilder.Entity<InteraccionesCliente>(entity =>
        {
            entity.HasKey(e => e.IdInteraccion).HasName("PRIMARY");
            entity.ToTable("interacciones_cliente");
            entity.HasIndex(e => e.IdCliente, "id_cliente");
            entity.HasIndex(e => e.IdEmpleado, "id_empleado");
            entity.HasIndex(e => e.IdProyecto, "id_proyecto");
            entity.Property(e => e.IdInteraccion).HasColumnType("int(11)").HasColumnName("id_interaccion");
            entity.Property(e => e.FechaHora)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora");
            entity.Property(e => e.IdCliente).HasColumnType("int(11)").HasColumnName("id_cliente");
            entity.Property(e => e.IdEmpleado).HasColumnType("int(11)").HasColumnName("id_empleado");
            entity.Property(e => e.IdProyecto).HasColumnType("int(11)").HasColumnName("id_proyecto");
            entity.Property(e => e.Resumen).HasColumnType("text").HasColumnName("resumen");
            entity.Property(e => e.Tipo).HasMaxLength(20).HasColumnName("tipo");
            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.InteraccionesClientes)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("interacciones_cliente_ibfk_1");
            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.InteraccionesClientes)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("interacciones_cliente_ibfk_3");
            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.InteraccionesClientes)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("interacciones_cliente_ibfk_2");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PRIMARY");
            entity.ToTable("proyectos");
            entity.HasIndex(e => e.IdCliente, "id_cliente");
            entity.HasIndex(e => e.IdResponsable, "id_responsable");
            entity.Property(e => e.IdProyecto).HasColumnType("int(11)").HasColumnName("id_proyecto");
            entity.Property(e => e.Estado).HasMaxLength(20).HasDefaultValueSql("'Planificado'").HasColumnName("estado");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdCliente).HasColumnType("int(11)").HasColumnName("id_cliente");
            entity.Property(e => e.IdResponsable).HasColumnType("int(11)").HasColumnName("id_responsable");
            entity.Property(e => e.Nombre).HasMaxLength(100).HasColumnName("nombre");
            entity.Property(e => e.Objetivos).HasColumnType("text").HasColumnName("objetivos");
            entity.Property(e => e.PresupuestoEstimado).HasPrecision(12, 2).HasColumnName("presupuesto_estimado");
            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyectos_ibfk_1");
            entity.HasOne(d => d.IdResponsableNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdResponsable)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyectos_ibfk_2");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PRIMARY");
            entity.ToTable("tareas");
            entity.HasIndex(e => e.IdEmpleado, "id_empleado");
            entity.HasIndex(e => e.IdHito, "id_hito");
            entity.HasIndex(e => e.IdProyecto, "id_proyecto");
            entity.Property(e => e.IdTarea).HasColumnType("int(11)").HasColumnName("id_tarea");
            entity.Property(e => e.Descripcion).HasColumnType("text").HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasMaxLength(20).HasDefaultValueSql("'Pendiente'").HasColumnName("estado");
            entity.Property(e => e.FechaLimite).HasColumnName("fecha_limite");
            entity.Property(e => e.IdEmpleado).HasColumnType("int(11)").HasColumnName("id_empleado");
            entity.Property(e => e.IdHito).HasColumnType("int(11)").HasColumnName("id_hito");
            entity.Property(e => e.IdProyecto).HasColumnType("int(11)").HasColumnName("id_proyecto");
            entity.Property(e => e.PorcentajeProgreso)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("porcentaje_progreso");
            entity.Property(e => e.Titulo).HasMaxLength(100).HasColumnName("titulo");
            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tareas_ibfk_3");
            entity.HasOne(d => d.IdHitoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdHito)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tareas_ibfk_2");
            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("tareas_ibfk_1");
        });
    }
}
