using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.Model;

namespace SistemaVenta.BLL.Servicios
{
    public class RoleService : IRoleService
    {
        private readonly IGenericRepository<Role> _roleRepositorio;
        private readonly IMapper _mapper;

        public RoleService(IGenericRepository<Role> roleRepositorio, IMapper mapper)
        {
            _roleRepositorio = roleRepositorio;
            _mapper = mapper;
        }

        public async Task<List<RoleDTO>> Lista()
        {
            try
            {
                var listaRoles = await _roleRepositorio.Consultar();
                return _mapper.Map<List<RoleDTO>>(listaRoles.ToList());
            }
            catch
            {
                throw;
            }
        }
    }
}
