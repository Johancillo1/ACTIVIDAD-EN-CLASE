namespace Consultoria.Application.DTOs;

public class ProyectoDto
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
}

public class CreateProyectoDto
{
    public int IdCliente { get; set; }
    public int IdResponsable { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Objetivos { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public decimal PresupuestoEstimado { get; set; }
    public string? Estado { get; set; }
}

public class UpdateProyectoDto
{
    public int IdCliente { get; set; }
    public int IdResponsable { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Objetivos { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public decimal PresupuestoEstimado { get; set; }
    public string? Estado { get; set; }
}
