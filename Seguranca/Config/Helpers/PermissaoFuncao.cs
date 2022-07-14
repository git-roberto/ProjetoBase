using Seguranca.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguranca.Config.Helpers
{
    [NotMapped]
    public class PermissaoFuncao
    {
        public virtual bool Consultar { get; set; }
        public virtual bool Inserir { get; set; }
        public virtual bool Alterar { get; set; }
        public virtual bool Excluir { get; set; }
        public virtual bool Visualizar { get; set; }
        public virtual Funcao Funcao { get; set; }
    }
}
