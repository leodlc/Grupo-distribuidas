using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LPrestamo
    {
        public PRESTAMO Create(PRESTAMO prestamo)
        {
            PRESTAMO result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                PRESTAMO prestamoTemp = r.Retrieve<PRESTAMO>(p => p.IDCLIENTE == prestamo.IDCLIENTE && p.IDLIBRO == prestamo.IDLIBRO && p.FECHAFINPREST == null);
                if (prestamoTemp == null)
                {
                    result = r.Create(prestamo);
                }
                else
                {
                    // Caso negativo, el préstamo ya existe o no se ha devuelto
                }
            }
            return result;
        }


        // Al parecer no existe un id para el prestamo asi que esta pendiente esta funcion
        /*public PRESTAMO RetrieveById(int id)
        {
            PRESTAMO result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<PRESTAMO>(p => p.idPrestamo == id);
            }
            return result;
        }

        public bool Update(PRESTAMO prestamo)
        {
            bool result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                PRESTAMO prestamoTemp = r.Retrieve<PRESTAMO>(p => p.idPrestamo == prestamo.idPrestamo);
                if (prestamoTemp != null)
                {
                    result = r.Update(prestamo);
                }
                else
                {
                    // Caso negativo, el préstamo no existe
                }
            }
            return result;
        }

        Aqui no se puede hacer el eliminar debido a que no se puede obtener el prestamo por id
        public bool Delete(int id)
        {
            bool result = false;
            var prestamoTemp = RetrieveById(id);
            if (prestamoTemp != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Delete(prestamoTemp);
                }
            }
            else
            {
                // Caso negativo, el préstamo no existe
            }
            return result;
        }*/

        public List<PRESTAMO> RetrieveAll()
        {
            List<PRESTAMO> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Filter<PRESTAMO>(p => true); // Obtener todos los préstamos
            }
            return result;
        }
    }
}
