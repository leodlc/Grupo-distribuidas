﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web.Http;
using Data;

namespace Servicio.Controllers
{
    public class ProductController : ApiController
    {
        [HttpPost]
        public Producto Add(Producto _producto)
        {
            var negocio = new Negocio.LProducto();
            var producto = negocio.Create(_producto);
            return producto;
        }

      

        [HttpGet]
        public Producto GetById(int id) {
            var negocio=new Negocio.LProducto();
            var producto = negocio.RetrievedBy(id);
            return producto;
        }


        [HttpGet]
        public List<Producto> GetAll()
        {
            var negocio = new Negocio.LProducto();

            var producto = negocio.RetrieveAll().ToList();
            return producto;
        }

   

        [HttpGet]
        public List<Producto> GetByCategory(int id)
        {
            var negocio = new Negocio.LProducto();
            var producto=negocio.FilterByCategoryId(id);
            return producto;
        }
        
        [HttpPut]
        public Producto Update(int id,Producto _producto)
        {
            var negocio = new Negocio.LProducto();
            var producto = negocio.Update(id,_producto);
            return producto;
        }

       



        [HttpDelete]
        public bool Delete(int id)
        {
            //bool result=false;
            var negocio = new Negocio.LProducto();
            var result = negocio.Delete(id);
            return result;

        }

    }
}