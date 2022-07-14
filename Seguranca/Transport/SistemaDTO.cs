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
    public class SistemaDTO : BaseDTO<Sistema, SistemaDTO>
    {
        public SistemaDTO()
        {

        }

        public SistemaDTO(Sistema model)
        {
            Id = model.Id;
            Nome = model.Nome;
            Codigo = model.Codigo;
            Descricao = model.Descricao;
            Situacao = model.Situacao;
        }

        public override Sistema Modelo(IDbContext contexto)
        {
            Sistema model = new();
            if (Id.HasValue)
            {
                model = contexto.Conexao.Set<Sistema>().Find(Id);
            }

            model.Nome = Nome;
            model.Codigo = Codigo;
            model.Descricao = Descricao;
            model.Situacao = Situacao;

            return model;
        }
        public int? Id { get; set; }

        public string Nome { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public bool Situacao { get; set; }
    }
}
