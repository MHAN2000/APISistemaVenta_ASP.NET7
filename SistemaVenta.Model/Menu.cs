using System;
using System.Collections.Generic;

namespace SistemaVenta.Model;

public partial class Menu
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Icono { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<MenuRole> MenuRoles { get; } = new List<MenuRole>();
}
