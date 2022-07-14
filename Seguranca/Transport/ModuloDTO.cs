using Seguranca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Base;
using Utilidades.ORM;

namespace Seguranca.Transport
{
    public class ModuloDTO : BaseDTO<Modulo, ModuloDTO>
    {
        public ModuloDTO()
        {

        }

        public ModuloDTO(Modulo model)
        {
            Id = model.Id;
            Nome = model.Nome;
            Codigo = model.Codigo;
            Descricao = model.Descricao;
            Situacao = model.Situacao;

            Sistema = model.Sistema?.ToDTO<Sistema, SistemaDTO>();
        }

        public override Modulo Modelo(IDbContext contexto)
        {
            Modulo model = new();
            if (Id.HasValue)
            {
                model = contexto.Conexao.Set<Modulo>().Find(Id);
            }

            model.Nome = Nome;
            model.Codigo = Codigo;
            model.Descricao = Descricao;
            model.Situacao = Situacao;

            model.Sistema = Sistema != null && Sistema.Id.HasValue ? contexto.Conexao.Set<Sistema>().FirstOrDefault(x => x.Id == Sistema.Id.Value) : null;
            model.IdSistema = model.Sistema.Id.Value;

            return model;
        }
        public int? Id { get; set; }

        public string Nome { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public bool Situacao { get; set; }

        public virtual SistemaDTO Sistema { get; set; }
    }
}
