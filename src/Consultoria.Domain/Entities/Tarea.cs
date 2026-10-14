namespace Consultoria.Domain.Entities;

public class Tarea
{
    public int IdTarea { get; set; }
    public int IdProyecto { get; set; }
    public int? IdHito { get; set; }
    public int IdEmpleado { get; set; }
    public string Titulo { get; set; } = null!;
    public string? Descripcion { get; set; }
    public DateOnly FechaLimite { get; set; }
    public int? PorcentajeProgreso { get; set; }
    public string? Estado { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
    public virtual Hito? IdHitoNavigation { get; set; }
    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
}
