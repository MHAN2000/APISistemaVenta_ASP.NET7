using System;
using System.Collections.Generic;

namespace SistemaVenta.Model;

public partial class Role
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<MenuRole> MenuRoles { get; } = new List<MenuRole>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
