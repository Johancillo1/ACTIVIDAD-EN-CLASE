namespace Consultoria.Domain.Entities;

public class Proyecto
{
    public int IdProyecto { get; set; }
    public int IdCliente { get; set; }
    public int IdResponsable { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Objetivos { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public decimal PresupuestoEstimado { get; set; }
    public string? Estado { get; set; }

    public virtual ICollection<GastosProyecto> GastosProyectos { get; set; } = new List<GastosProyecto>();
    public virtual ICollection<Hito> Hitos { get; set; } = new List<Hito>();
    public virtual Cliente IdClienteNavigation { get; set; } = null!;
    public virtual Empleado IdResponsableNavigation { get; set; } = null!;
    public virtual ICollection<InteraccionesCliente> InteraccionesClientes { get; set; } = new List<InteraccionesCliente>();
    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
