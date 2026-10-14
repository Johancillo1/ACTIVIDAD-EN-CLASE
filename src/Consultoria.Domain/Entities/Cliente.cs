namespace Consultoria.Domain.Entities;

public class Cliente
{
    public int IdCliente { get; set; }
    public string NombreContacto { get; set; } = null!;
    public string Empresa { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Telefono { get; set; }

    public virtual ICollection<InteraccionesCliente> InteraccionesClientes { get; set; } = new List<InteraccionesCliente>();
    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
