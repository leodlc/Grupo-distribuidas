using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LCliente
    {
        public CLIENTE Create(CLIENTE cliente)
        {
            CLIENTE result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                CLIENTE clienteTemp = r.Retrieve<CLIENTE>(c => c.CEDULACLIENTE == cliente.CEDULACLIENTE);
                if (clienteTemp == null)
                {
                    result = r.Create(cliente);
                }
                else
                {
                    // Caso negativo, el cliente ya existe
                }
            }
            return result;
        }

        public CLIENTE RetrieveById(int id)
        {
            CLIENTE result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<CLIENTE>(c => c.IDCLIENTE == id);
            }
            return result;
        }

        public bool Update(CLIENTE cliente)
        {
            bool result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                CLIENTE clienteTemp = r.Retrieve<CLIENTE>(c => c.IDCLIENTE == cliente.IDCLIENTE);
                if (clienteTemp != null)
                {
                    result = r.Update(cliente);
                }
                else
                {
                    // Caso negativo, el cliente no existe
                }
            }
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var clienteTemp = RetrieveById(id);
            if (clienteTemp != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Delete(clienteTemp);
                }
            }
            else
            {
                // Caso negativo, el cliente no existe
            }
            return result;
        }

        public List<CLIENTE> RetrieveAll()
        {
            List<CLIENTE> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Filter<CLIENTE>(c => true); // Obtener todos los clientes
            }
            return result;
        }
    }

}
