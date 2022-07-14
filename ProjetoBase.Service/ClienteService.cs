using ProjetoBase.Config.Infra;
using ProjetoBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Base;
using Utilidades.ORM;

namespace ProjetoBase.Service
{
    public class ClienteService : ServiceBase<Cliente>
    {
        public ClienteService() 
            : base(new Contexto())
        {
        }
    }
}
