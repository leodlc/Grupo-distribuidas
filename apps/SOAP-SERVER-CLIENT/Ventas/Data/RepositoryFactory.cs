using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RepositoryFactory
    {
        public static IRepository CreateRepository()
        {
            return new EFRepository(new VentasEntities());
        }
    }
}
