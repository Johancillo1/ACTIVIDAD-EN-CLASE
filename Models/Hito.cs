using System;
using System.Collections.Generic;

namespace Actividad_semana5.Models;

public partial class Hito
{
    public int IdHito { get; set; }

    public int IdProyecto { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaPlanificada { get; set; }

    public DateOnly? FechaAlcanzada { get; set; }

    public string? Estado { get; set; }

    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
