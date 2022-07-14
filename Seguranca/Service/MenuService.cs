using Seguranca.Config.Enums;
using Seguranca.Config.Helpers;
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
    public class MenuService : ServiceBase<Funcao>
    {
        public MenuService()
            : base(new ContextoSeguranca())
        {
        }
    }
}
