using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web.Http;
using Data;

namespace Servicio.Controllers
{
    public class ServiceController : ApiController
    {
        [HttpPost]
        public Producto CrearProducto(Producto _producto)
        {
            var negocio = new Negocio.LProducto();
            var producto = negocio.Create(_producto);
            return producto;
        }

        [HttpPost]
        public Categoria CrearCategoria(Categoria _categoria)
        {
            var negocio = new Negocio.LCategoria();
            var categoria = negocio.Create(_categoria);
            return categoria;

        }

        [HttpGet]
        public Producto GetProducto(int id) {
            var negocio=new Negocio.LProducto();
            var producto = negocio.RetrievedBy(id);
            return producto;
        }

        [HttpGet]
        public Categoria GetCategoria(int id)
        {
            var negocio = new Negocio.LCategoria();
            var categoria = negocio.RetrievedBy(id);
            return categoria;
        }

        [HttpGet]
        public List<Producto> GetAllProductos()
        {
            var negocio = new Negocio.LProducto();

            var producto = negocio.RetrieveAll().ToList();
            return producto;
        }

        [HttpGet]
        public List<Categoria> GetAllCategorias()
        {
            var negocio = new Negocio.LCategoria();

            var categoria = negocio.RetrieveAll().ToList();
            return categoria;
        }

        [HttpGet]
        public List<Producto> GetProductByCategory(int id)
        {
            var negocio = new Negocio.LProducto();
            var producto=negocio.FilterByCategoryId(id);
            return producto;
        }
        
        [HttpPut]
        public Producto ActualizarProducto(int id,Producto _producto)
        {
            var negocio = new Negocio.LProducto();
            var producto = negocio.Update(id,_producto);
            return producto;
        }

        [HttpPut]
        public Categoria ActualizarCategoria(int id, Categoria _categoria)
        {
            var negocio = new Negocio.LCategoria();
            var categoria = negocio.Update(id, _categoria);
            return categoria;
        }

        [HttpDelete]
        public bool DeleteCategoria(int id) { 
            //bool result=false;
            var negocio=new Negocio.LCategoria();
            var result=negocio.Delete(id);
            return result;
            
        }


        [HttpDelete]
        public bool DeleteProducto(int id)
        {
            //bool result=false;
            var negocio = new Negocio.LProducto();
            var result = negocio.Delete(id);
            return result;

        }

    }
}
