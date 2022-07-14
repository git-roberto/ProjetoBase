using Seguranca.Config.Enums;
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
    public class MenuDTO : BaseDTO<Funcao, MenuDTO>
    {
        public MenuDTO()
        {
            SubMenu = new List<MenuDTO>();
        }

        public MenuDTO(Funcao model)
        {
            Id = model.Id;
            Nome = model.Nome;
            Descricao = model.Descricao;
            Rota = model.Rota;
            Visibilidade = model.Visibilidade;
            Permissao = model.Permissao;
            Ordem = model.Ordem;
            Situacao = model.Situacao;

            Funcao = model?.ToDTO<Funcao, FuncaoDTO>();

            SubMenu = new List<MenuDTO>();
        }

        public override Funcao Modelo(IDbContext contexto)
        {
            return null;
        }

        public int? Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Rota { get; set; }

        public TipoVisibilidadeEnum Visibilidade { get; set; }

        public TipoAutenticacaoEnum Permissao { get; set; }

        public short Ordem { get; set; }

        public bool Situacao { get; set; }

        public FuncaoDTO Funcao { get; set; }

        public List<MenuDTO> SubMenu { get; set; }

    }
}
