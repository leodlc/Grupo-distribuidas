using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LAutor
    {
        public AUTOR Create(AUTOR autor)
        {
            AUTOR result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                AUTOR autorTemp = r.Retrieve<AUTOR>(a => a.NOMBREAUTOR == autor.NOMBREAUTOR && a.APELLIDOAUTOR == autor.APELLIDOAUTOR);
                if (autorTemp == null)
                {
                    result = r.Create(autor);
                }
                else
                {
                    // Caso negativo, el autor ya existe
                }
            }
            return result;
        }

        public AUTOR RetrieveById(int id)
        {
            AUTOR result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<AUTOR>(a => a.IDAUTOR == id);
            }
            return result;
        }

        public bool Update(AUTOR autor)
        {
            bool result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                AUTOR autorTemp = r.Retrieve<AUTOR>(a => a.IDAUTOR == autor.IDAUTOR);
                if (autorTemp != null)
                {
                    result = r.Update(autor);
                }
                else
                {
                    // Caso negativo, el autor no existe
                }
            }
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var autorTemp = RetrieveById(id);
            if (autorTemp != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Delete(autorTemp);
                }
            }
            else
            {
                // Caso negativo, el autor no existe
            }
            return result;
        }

        public List<AUTOR> RetrieveAll()
        {
            List<AUTOR> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Filter<AUTOR>(a => true); // Obtener todos los autores
            }
            return result;
        }
    }
}
