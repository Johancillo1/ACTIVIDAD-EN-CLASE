namespace Consultoria.Application.DTOs;

public class EmpleadoDto
{
    public int IdEmpleado { get; set; }
    public string Nombre { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Rol { get; set; } = null!;
    public bool? Activo { get; set; }
}

public class CreateEmpleadoDto
{
    public string Nombre { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Rol { get; set; } = null!;
    public bool? Activo { get; set; } = true;
}

public class UpdateEmpleadoDto
{
    public string Nombre { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Rol { get; set; } = null!;
    public bool? Activo { get; set; }
}
