using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LGeneroLiterario
    {
       
        public GENEROLITERARIO Create(GENEROLITERARIO genero)
        {
            GENEROLITERARIO result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                GENEROLITERARIO generoTemp = r.Retrieve<GENEROLITERARIO>(g => g.NOMBREGL == genero.NOMBREGL);
                if (generoTemp == null)
                {
                    result = r.Create(genero);
                }
                else
                {
                    // Caso negativo, el género literario ya existe
                }
            }
            return result;
        }

        public GENEROLITERARIO RetrieveById(int id)
        {
            GENEROLITERARIO result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<GENEROLITERARIO>(g => g.IDGL == id);
            }
            return result;
        }

        public bool Update(GENEROLITERARIO genero)
        {
            bool result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                GENEROLITERARIO generoTemp = r.Retrieve<GENEROLITERARIO>(g => g.IDGL == genero.IDGL);
                if (generoTemp != null)
                {
                    result = r.Update(genero);
                }
                else
                {
                    // Caso negativo, el género literario no existe
                }
            }
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var generoTemp = RetrieveById(id);
            if (generoTemp != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Delete(generoTemp);
                }
            }
            else
            {
                // Caso negativo, el género literario no existe
            }
            return result;
        }

        public List<GENEROLITERARIO> RetrieveAll()
        {
            List<GENEROLITERARIO> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Filter<GENEROLITERARIO>(g => true); // Obtener todos los géneros literarios
            }
            return result;
        }
    }
}
