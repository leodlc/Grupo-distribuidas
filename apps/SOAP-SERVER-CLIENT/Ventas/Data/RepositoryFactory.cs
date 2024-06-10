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
            var Context = new VentasEntities();
            Context.Configuration.ProxyCreationEnabled = false; 
            return new EFRepository(Context);
        }
    }
}
