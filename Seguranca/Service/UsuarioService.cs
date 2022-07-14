using Seguranca.Config.Infra;
using Seguranca.Model;
using Seguranca.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Base;

namespace Seguranca.Service
{
    public class UsuarioService : ServiceBase<Usuario>
    {
        public UsuarioService()
            : base(new ContextoSeguranca())
        {
        }
    }
}
