using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Negocio
{
    public class LCategoria
    {
        public Categoria Create(Categoria categoria)
        {
            Categoria result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Categoria categoriaTemp = r.Retrieve<Categoria>(c => c.CategoriaNombre == categoria.CategoriaNombre);
                if (categoriaTemp == null)
                {
                    result = r.Create(categoria);

                }
                else
                {

                }
            }
            return result;

        }

        public Categoria RetrievedBy(int id)
        {
            /*
               string criteria = Console.ReadLine();

            using (var r = RepositoryFactory.CreateRepository())
            {
                var products = r.Filter<Producto>(p => p.ProductoNombre.Contains(criteria));
                foreach (var product in products)
                {
                    Console.WriteLine($"Id: {product.ProductoId}, Nombre: {product.ProductoNombre}, Precio: {product.PrecioUnitario}, En Stock: {product.EnStock}");
                }
            }*/
             Categoria result = null;
           
            try
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Retrieve<Categoria>(c => c.CategoriaId == id);
                    
                }
            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"Ocurrió un error al obtener la categoría: {ex.Message}");
            }
            return result;
        }
 

        public List<Categoria> RetrieveAll()
        {
            List<Categoria> result = null;
            try
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Filter<Categoria>(c => true).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Categoria Update(int id, Categoria categoria)
        {
            Categoria result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                var categoriaTemp = r.Retrieve<Categoria>(c => c.CategoriaId == id);
                if (categoriaTemp != null)
                {
                    categoriaTemp.CategoriaNombre = categoria.CategoriaNombre;
                    categoriaTemp.Detalle = categoria.Detalle;

                    r.Update(categoriaTemp);
                    result = categoriaTemp; 
                }
            }
            return result;
        }



        public bool Delete(int id)
        {
            bool result = false;
            var categoryTemp = RetrievedBy(id);
            if (categoryTemp != null)
            {
               
                    using (var r = RepositoryFactory.CreateRepository())
                    {
                        result = r.Delete(categoryTemp);
                    }
            }
            return result;
        }

    }
}
