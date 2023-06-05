using System;
using System.Collections.Generic;

namespace SistemaVenta.Model;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? CategoriaId { get; set; }

    public int? Stock { get; set; }

    public decimal? Precio { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; } = new List<DetalleVenta>();
}
