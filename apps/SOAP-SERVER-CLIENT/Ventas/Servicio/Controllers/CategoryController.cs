using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Data;

namespace Servicio.Controllers
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con categorías.
    /// </summary>
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        /// <summary>
        /// Envía una categoría para que se almacene en la base de datos.
        /// </summary>
        /// <param name="_categoria">La categoría a agregar.</param>
        /// <returns>La nueva categoría ingresada.</returns>
        [HttpPost]
        public Categoria Add(Categoria _categoria)
        {
            var negocio = new Negocio.LCategoria();
            var categoria = negocio.Create(_categoria);
            return categoria;
        }

        /// <summary>
        /// Obtiene una categoría por su ID.
        /// </summary>
        /// <param name="id">El ID de la categoría a obtener.</param>
        /// <returns>La categoría con el ID especificado.</returns>
        [HttpGet]
        public Categoria GetById(int id)
        {
            var negocio = new Negocio.LCategoria();
            var categoria = negocio.RetrievedBy(id);
            return categoria;
        }

        /// <summary>
        /// Obtiene todas las categorías.
        /// </summary>
        /// <returns>Una lista de todas las categorías.</returns>
        [HttpGet]
        public List<Categoria> GetAll()
        {
            var negocio = new Negocio.LCategoria();
            var categoria = negocio.RetrieveAll().ToList();
            return categoria;
        }

        /// <summary>
        /// Actualiza una categoría existente.
        /// </summary>
        /// <param name="id">El ID de la categoría a actualizar.</param>
        /// <param name="_categoria">Los datos actualizados de la categoría.</param>
        /// <returns>La categoría actualizada.</returns>
        [HttpPut]
        public Categoria Update(int id, Categoria _categoria)
        {
            var negocio = new Negocio.LCategoria();
            var categoria = negocio.Update(id, _categoria);
            return categoria;
        }

        /// <summary>
        /// Elimina una categoría por su ID.
        /// </summary>
        /// <param name="id">El ID de la categoría a eliminar.</param>
        /// <returns>Verdadero si la categoría fue eliminada; de lo contrario, falso.</returns>
        [HttpDelete]
        public bool Delete(int id)
        {
            var negocio = new Negocio.LCategoria();
            var result = negocio.Delete(id);
            return result;
        }
    }
}
