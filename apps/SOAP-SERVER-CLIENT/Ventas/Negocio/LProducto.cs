using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Data.Entity;

namespace Negocio
{
    public class LProducto
    {
        public Producto Create(Producto product)
        {
            Producto result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Producto productTemp = r.Retrieve<Producto>(p => p.ProductoNombre == product.ProductoNombre);
                if (productTemp == null)
                {
                    result = r.Create(product);
                }
                else
                {
                }
            }
            return result;
        }

        public Producto RetrievedBy(int id)
        {
            Producto result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                try
                {
                    result = r.Retrieve<Producto>(p => p.ProductoId == id);
                }
                catch (Exception ex)
                {
                }
            }
            return result;
        }

        public List<Producto> RetrieveAll()
        {
            List<Producto> result = null;
            try
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Filter<Producto>(p => true).ToList();
                }
            }
            catch (Exception ex)
            {
                throw; 
            }
            return result;
        }

        public Producto Update(int id, Producto producto)
        {
            Producto result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                var productoTemp = r.Retrieve<Producto>(p => p.ProductoId == id);
                if (productoTemp != null)
                {
                    productoTemp.ProductoNombre = producto.ProductoNombre;
                    productoTemp.PrecioUnitario = producto.PrecioUnitario;
                    productoTemp.EnStock = producto.EnStock;
                    productoTemp.CategoriaId = producto.CategoriaId;

                    r.Update(productoTemp);
                    result = productoTemp; 
                }
            }
            return result;
        }

        public List<Producto> FilterByCategoryId(int categoryId)
        {
            List<Producto> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Filter<Producto>(p => p.CategoriaId == categoryId).ToList();

                foreach (var producto in result)
                {
                    producto.Categoria = r.Retrieve<Categoria>(c => c.CategoriaId == producto.CategoriaId);
                }
            }
            return result;
        }


        public bool Delete(int id)
        {
            bool result = false;
            var productTemp = RetrievedBy(id);
            if (productTemp != null)
            {
                if (productTemp.EnStock == 0)
                {
                    using (var r = RepositoryFactory.CreateRepository())
                    {
                        result = r.Delete(productTemp);
                    }

                }
                else
                {
                }
            }
            return result;
        }

        public int CountByCategoryId(int categoryId)
        {
            int count = 0;
            using (var r = RepositoryFactory.CreateRepository())
            {
                count = r.Count<Producto>(p => p.CategoriaId == categoryId);
            }
            return count;
        }
    }
}
