namespace Consultoria.Application.DTOs;

public class ClienteDto
{
    public int IdCliente { get; set; }
    public string NombreContacto { get; set; } = null!;
    public string Empresa { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Telefono { get; set; }
}

public class CreateClienteDto
{
    public string NombreContacto { get; set; } = null!;
    public string Empresa { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Telefono { get; set; }
}

public class UpdateClienteDto
{
    public string NombreContacto { get; set; } = null!;
    public string Empresa { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Telefono { get; set; }
}
