using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Seguranca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades;
using Utilidades.ORM;

namespace Seguranca.Config.Infra
{
    public class ContextoSeguranca : ContextoBase
    {
        public override DbContext Conexao => this;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = Conectar.BuscarConexao("ConexaoSeguranca");

            optionsBuilder.UseSqlServer(conn);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerfilUsuario>().HasKey(e => new { e.IdPerfil, e.IdUsuario });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Model.Funcao> Funcao { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<PerfilFuncao> PerfilFuncao { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public DbSet<Sistema> Sistema { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
