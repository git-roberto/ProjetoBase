using Microsoft.EntityFrameworkCore;
using ProjetoBase.Model;
using Seguranca.Config.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.ORM;

namespace ProjetoBase.Config.Infra
{
    public class Contexto : ContextoSeguranca
    {
        public override DbContext Conexao => this;

        public DbSet<Cliente>? Cliente { get; set; }
    }
}
