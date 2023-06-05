using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int? CategoriaId { get; set; }
        public string? DescripcionCategoria { get; set; }

        public int? Stock { get; set; }

        public string? Precio { get; set; }

        public int? EsActivo { get; set; }
    }
}
