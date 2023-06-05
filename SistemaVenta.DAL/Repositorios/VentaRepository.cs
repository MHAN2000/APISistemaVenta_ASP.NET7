using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SistemaVenta.DAL.DBContext;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.Model;

namespace SistemaVenta.DAL.Repositorios
{
    public class VentaRepository : IGenericRepository<Venta>, IVentaRepository
    {
        private readonly DbVentaContext _dbContext;

        public VentaRepository(DbVentaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IQueryable<Venta>> Consultar(Expression<Func<Venta, bool>> filtro = null)
        {
            throw new NotImplementedException();
        }

        public Task<Venta> Crear(Venta modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(Venta modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(Venta modelo)
        {
            throw new NotImplementedException();
        }

        public Task<Venta> Obtener(Expression<Func<Venta, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();
            //Crear una transaccion, de tal manera que si falla algo, regresar todos los cambios
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //Iterar cada detalle venta, para asi restar el stock de cada producto contenido en ese detalle venta
                    foreach (DetalleVenta dv in modelo.DetalleVenta)
                    {
                        //Encontrar el producto contenido en detalle venta
                        Producto productoEncontrado = _dbContext.Productos.Where(p => p.Id == dv.ProductoId).First();
                        //Restar el stock de detalle venta al producto
                        productoEncontrado.Stock -= dv.Cantidad;
                        //Hacer un update del producto, para despues Guardarlos
                        _dbContext.Productos.Update(productoEncontrado);
                    }
                    //Guardar todos los cambios
                    await _dbContext.SaveChangesAsync();
                    //Empezar a formar el folio que tendra la Venta, para eso nos traemos el numero total de registros
                    //que existen en la base de datos del modelo Venta
                    string numeroMaximo = (_dbContext.Venta.Count() + 1).ToString();
                    //Definir la cantidad de digitos que tendra nuestro folio
                    int cantidadDigitos = 4;
                    //Agregar un padding a nuestro folio es decir si nuestro numero maximo es 4, agregara 3 ceros a la
                    //izquierda, esto para cumplir con el formato del folio, o 0043 seria otro ejemplo
                    string numeroVenta = numeroMaximo.PadLeft(cantidadDigitos, '0');
                    //Establecer nuestro folio al modelo Venta
                    modelo.NumeroDocumento = numeroVenta;
                    //Agregar el nuevo registro Venta a la base de datos
                    await _dbContext.Venta.AddAsync(modelo);
                    //Guardar los cambios
                    await _dbContext.SaveChangesAsync();

                    ventaGenerada = modelo;
                    //Si todo salio bien, ejecutar la transaccion
                    transaction.Commit();
                }
                catch
                {
                    //Si algo fallo, regresar todos los cambios
                    transaction.Rollback();
                    throw;
                }
                return ventaGenerada;
            }
        }
    }
}
