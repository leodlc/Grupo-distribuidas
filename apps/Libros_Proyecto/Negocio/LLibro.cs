using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LLibro
    {
        public LIBRO Create(LIBRO libro)
        {
            LIBRO result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                LIBRO libroTemp = r.Retrieve<LIBRO>(l => l.ISBNLIBRO == libro.ISBNLIBRO);
                if (libroTemp == null)
                {
                    result = r.Create(libro);
                }
                else
                {
                    // Caso negativo, el libro ya existe
                }
            }
            return result;
        }

        public LIBRO RetrieveById(int id)
        {
            LIBRO result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<LIBRO>(l => l.IDLIBRO == id);
            }
            return result;
        }

        public bool Update(LIBRO libro)
        {
            bool result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                LIBRO libroTemp = r.Retrieve<LIBRO>(l => l.IDLIBRO == libro.IDLIBRO);
                if (libroTemp != null)
                {
                    result = r.Update(libro);
                }
                else
                {
                    // Caso negativo, el libro no existe
                }
            }
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var libroTemp = RetrieveById(id);
            if (libroTemp != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Delete(libroTemp);
                }
            }
            else
            {
                // Caso negativo, el libro no existe
            }
            return result;
        }

        public List<LIBRO> RetrieveAll()
        {
            List<LIBRO> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Filter<LIBRO>(l => true); // Obtener todos los libros
            }
            return result;
        }
    }

}
