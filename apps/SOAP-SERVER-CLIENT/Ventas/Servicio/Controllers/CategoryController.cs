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
    public class CategoryController : ApiController
    {
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

        [HttpPost]
        public Categoria Add(Categoria _categoria)
        {
            var negocio = new Negocio.LCategoria();
            var categoria = negocio.Create(_categoria);
            return categoria;

        }

        [HttpGet]
        public Categoria GetById(int id)
        {
            var negocio = new Negocio.LCategoria();
            var categoria = negocio.RetrievedBy(id);
            return categoria;
        }

        [HttpGet]
        public List<Categoria> GetAll()
        {
            var negocio = new Negocio.LCategoria();

            var categoria = negocio.RetrieveAll().ToList();
            return categoria;
        }

        [HttpPut]
        public Categoria Update(int id, Categoria _categoria)
        {
            var negocio = new Negocio.LCategoria();
            var categoria = negocio.Update(id, _categoria);
            return categoria;
        }


        [HttpDelete]
        public bool Delete(int id)
        {
            //bool result=false;
            var negocio = new Negocio.LCategoria();
            var result = negocio.Delete(id);
            return result;

        }

    }
}
