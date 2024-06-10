using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using Newtonsoft.Json;

namespace Service.Controllers
{
    public class LoanController : ApiController
    {
        private JsonSerializerSettings jsonSettings;

        public LoanController()
        {
            // Configuración para ignorar las referencias circulares
            jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }
        /*  [HttpGet]

    public IHttpActionResult GetLoanById(int id)
       {
           var negocio = new Negocio.LPrestamo();
           var prestamo = negocio.RetrieveById(id);
           return Json(prestamo, jsonSettings);
       }*/
        [HttpPost]
        public PRESTAMO AddLoan(PRESTAMO _prestamo)
        {
            var negocio = new Negocio.LPrestamo();
            var prestamo = negocio.Create(_prestamo);
            return prestamo;
        }


        [HttpGet]
        public IHttpActionResult GetAllLoans()
        {
            var negocio = new Negocio.LPrestamo();
            var prestamo = negocio.RetrieveAll();
            return Json(prestamo, jsonSettings);
        }
        /*

        [HttpPut]
        public bool UpdateBook(int id, LIBRO _libro)
        {
            var negocio = new Negocio.LLibro();
            var result = negocio.Update(_libro, id);
            return result;
        }

        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var negocio = new Negocio.LLibro();
            var result = negocio.Delete(id);
            if (result)
            {
                return Ok("Libro eliminado correctamente.");
            }
            else
            {
                return BadRequest("No se pudo eliminar el libro.");
            }
        }*/
    }
}
