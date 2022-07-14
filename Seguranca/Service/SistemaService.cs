using Seguranca.Config.Infra;
using Seguranca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Base;

namespace Seguranca.Service
{
    public class SistemaService : ServiceBase<Sistema>
    {
        public SistemaService()
            : base(new ContextoSeguranca())
        {
        }
    }
}
