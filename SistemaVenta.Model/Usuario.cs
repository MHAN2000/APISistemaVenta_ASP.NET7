using System;
using System.Collections.Generic;

namespace SistemaVenta.Model;

public partial class Usuario
{
    public int Id { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Correo { get; set; }

    public int? RoleId { get; set; }

    public string? Clave { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Role? Role { get; set; }
}
