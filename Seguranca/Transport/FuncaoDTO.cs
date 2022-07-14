using Seguranca.Config.Enums;
using Seguranca.Config.Infra;
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
    public class FuncaoDTO : BaseDTO<Funcao, FuncaoDTO>
    {
        public FuncaoDTO()
        {

        }

        public FuncaoDTO(Funcao model)
        {
            Id = model.Id;
            Nome = model.Nome;
            Codigo = model.Codigo;
            Descricao = model.Descricao;
            Rota = model.Rota;
            Visibilidade = model.Visibilidade;
            Permissao = model.Permissao;
            Ordem = model.Ordem;
            Situacao = model.Situacao;

            FuncaoPai = model.FuncaoPai?.ToDTO<Funcao, FuncaoDTO>();
            Modulo = model.Modulo?.ToDTO<Modulo, ModuloDTO>();
        }

        public override Funcao Modelo(IDbContext contexto)
        {
            Funcao model = new();
            if (Id.HasValue)
            {
                model = contexto.Conexao.Set<Funcao>().Find(Id);
            }

            model.Nome = Nome;
            model.Codigo = Codigo;
            model.Descricao = Descricao;
            model.Rota = Rota;
            model.Visibilidade = Visibilidade;
            model.Permissao = Permissao;
            model.Ordem = Ordem;
            model.Situacao = Situacao;

            model.Modulo = Modulo != null && Modulo.Id.HasValue ? contexto.Conexao.Set<Modulo>().FirstOrDefault(x => x.Id == Modulo.Id.Value) : null;
            model.FuncaoPai = FuncaoPai != null && FuncaoPai.Id.HasValue ? contexto.Conexao.Set<Funcao>().FirstOrDefault(x => x.Id == FuncaoPai.Id.Value) : null;

            model.IdFuncaoPai = model.FuncaoPai.Id;
            model.IdModulo = model.Modulo.Id.Value;

            return model;
        }

        public int? Id { get; set; }

        public string Nome { get; set; }
        
        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public string Rota { get; set; }

        public TipoVisibilidadeEnum Visibilidade { get; set; }

        public TipoAutenticacaoEnum Permissao { get; set; }

        public short Ordem { get; set; }

        public bool Situacao { get; set; }

        public virtual FuncaoDTO? FuncaoPai { get; set; }

        public virtual ModuloDTO Modulo { get; set; }
    }
}
