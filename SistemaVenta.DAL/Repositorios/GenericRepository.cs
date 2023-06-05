using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SistemaVenta.DAL.Repositorios
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly DbVentaContext _dbContext;

        public GenericRepository(DbVentaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro)
        {
            try
            {
                TModel modelo = await _dbContext.Set<TModel>().FirstOrDefaultAsync(filtro);
                return modelo;
            } catch
            {
                throw;
            }
        }
        public async Task<TModel> Crear(TModel modelo)
        {
            try
            {
                _dbContext.Set<TModel>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Editar(TModel modelo)
        {
            try
            {
                _dbContext.Set<TModel>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(TModel modelo)
        {
            try
            {
                _dbContext.Set<TModel>().Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModel> queryModelo = (filtro == null ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(filtro));
                return queryModelo;
            }
            catch
            {
                throw;
            }
        }
    }
}
