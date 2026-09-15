using System;
using System.Collections.Generic;

namespace Actividad_semana5.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual ICollection<InteraccionesCliente> InteraccionesClientes { get; set; } = new List<InteraccionesCliente>();

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
