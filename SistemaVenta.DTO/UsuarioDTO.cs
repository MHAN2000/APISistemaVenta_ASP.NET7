using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string? NombreCompleto { get; set; }

        public string? Correo { get; set; }

        public int? RoleId { get; set; }

        public string RoleDescripcion { get; set; }

        public string? Clave { get; set; }

        public int? EsActivo { get; set; }
    }
}
