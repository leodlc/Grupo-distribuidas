using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using System.Web.Http.Cors;

namespace Servicio.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con productos.
    /// </summary>
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        /// <summary>
        /// Envía un producto para que se almacene en la base de datos.
        /// </summary>
        /// <param name="_producto">El producto a agregar.</param>
        /// <returns>El producto nuevo ingresado.</returns>
        [HttpPost]
        public Producto Add(Producto _producto)
        {
            var negocio = new Negocio.LProducto();
            var producto = negocio.Create(_producto);
            return producto;
        }

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto a obtener.</param>
        /// <returns>El producto con el ID especificado.</returns>
        [HttpGet]
        public Producto GetById(int id)
        {
            var negocio = new Negocio.LProducto();
            var producto = negocio.RetrievedBy(id);
            return producto;
        }

        /// <summary>
        /// Obtiene todos los productos.
        /// </summary>
        /// <returns>Una lista de todos los productos.</returns>
        [HttpGet]
        public List<Producto> GetAll()
        {
            var negocio = new Negocio.LProducto();
            var producto = negocio.RetrieveAll().ToList();
            return producto;
        }

        /// <summary>
        /// Obtiene productos por categoría.
        /// </summary>
        /// <param name="id">El ID de la categoría.</param>
        /// <returns>Una lista de productos que pertenecen a la categoría especificada.</returns>
        [HttpGet]
        public List<Producto> GetByCategory(int id)
        {
            var negocio = new Negocio.LProducto();
            var producto = negocio.FilterByCategoryId(id);
            return producto;
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="id">El ID del producto a actualizar.</param>
        /// <param name="_producto">Los datos actualizados del producto.</param>
        /// <returns>El producto actualizado.</returns>
        [HttpPut]
        public Producto Update(int id, Producto _producto)
        {
            var negocio = new Negocio.LProducto();
            var producto = negocio.Update(id, _producto);
            return producto;
        }

        /// <summary>
        /// Cuenta los productos en una categoría.
        /// </summary>
        /// <param name="id">El ID de la categoría.</param>
        /// <returns>El número de productos en la categoría especificada.</returns>
        [HttpGet]
        public int CountByCategory(int id)
        {
            var negocio = new Negocio.LProducto();
            var count = negocio.CountByCategoryId(id);
            return count;
        }

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto a eliminar.</param>
        /// <returns>Verdadero si el producto fue eliminado; de lo contrario, falso.</returns>
        [HttpDelete]
        public bool Delete(int id)
        {
            var negocio = new Negocio.LProducto();
            var result = negocio.Delete(id);
            return result;
        }
    }
}
