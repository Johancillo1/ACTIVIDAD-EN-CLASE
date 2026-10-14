namespace Consultoria.Domain.Entities;

public class InteraccionesCliente
{
    public int IdInteraccion { get; set; }
    public int IdCliente { get; set; }
    public int? IdProyecto { get; set; }
    public int IdEmpleado { get; set; }
    public string Tipo { get; set; } = null!;
    public DateTime? FechaHora { get; set; }
    public string? Resumen { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
    public virtual Proyecto? IdProyectoNavigation { get; set; }
}
