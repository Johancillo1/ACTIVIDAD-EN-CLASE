using System;
using System.Collections.Generic;

namespace Actividad_semana5.Models;

public partial class GastosProyecto
{
    public int IdGasto { get; set; }

    public int IdProyecto { get; set; }

    public string Concepto { get; set; } = null!;

    public decimal MontoReal { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string? Categoria { get; set; }

    public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
}
