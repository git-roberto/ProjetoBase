using Seguranca.Config.Enums;
using Seguranca.Config.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguranca.Service
{
    public class AcessoService
    {
        public static bool Buscar(PermissaoFuncao x, Permissao permissao)
        {
            switch (permissao)
            {
                case Permissao.Consultar:
                    return x.Consultar;
                case Permissao.Alterar:
                    return x.Alterar;
                case Permissao.Inserir:
                    return x.Inserir;
                case Permissao.Excluir:
                    return x.Excluir;
                case Permissao.Visualizar:
                    return x.Visualizar;
                default:
                    return false;
            }
        }
    }
}
