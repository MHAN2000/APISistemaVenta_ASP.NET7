using System;
using System.Collections.Generic;

namespace SistemaVenta.Model;

public partial class DetalleVenta
{
    public int Id { get; set; }

    public int? VentaId { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Venta? Venta { get; set; }
}
