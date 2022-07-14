using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.ORM
{
    public class ContextoBase : DbContext, IDbContext
    {
        public virtual DbContext Conexao => this;

        public ContextoBase()
            : base()
        {

        }

        public ContextoBase(DbContextOptions<ContextoBase> options)
            : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = Conectar.BuscarConexao("Conexao");

            optionsBuilder.UseSqlServer(conn);
        }
    }
}
