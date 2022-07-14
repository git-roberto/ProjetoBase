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
    public class PerfilFuncaoDTO : BaseDTO<PerfilFuncao, PerfilFuncaoDTO>
    {

        public PerfilFuncaoDTO()
        {

        }

        public PerfilFuncaoDTO(PerfilFuncao model)
        {
            Id = model.Id;
            Consultar = model.Consultar;
            Inserir = model.Inserir;
            Alterar = model.Alterar;
            Excluir = model.Excluir;
            Visualizar = model.Visualizar;


            Funcao = model.Funcao?.ToDTO<Funcao, FuncaoDTO>();
        }

        public override PerfilFuncao Modelo(IDbContext contexto)
        {
            PerfilFuncao model = new PerfilFuncao();
            if (Id.HasValue)
            {
                model = contexto.Conexao.Set<PerfilFuncao>().Find(Id);
            }

            model.Consultar = Consultar;
            model.Inserir = Inserir;
            model.Alterar = Alterar;
            model.Excluir = Excluir;
            model.Visualizar = Visualizar;

            model.Funcao = Funcao != null && Funcao.Id.HasValue ? contexto.Conexao.Set<Funcao>().FirstOrDefault(x => x.Id == Funcao.Id.Value) : null;
            model.Perfil = Perfil != null && Perfil.Id.HasValue ? contexto.Conexao.Set<Perfil>().FirstOrDefault(x => x.Id == Perfil.Id.Value) : null;

            model.IdPerfil = model.Perfil.Id.Value;
            model.IdFuncao = model.Funcao.Id.Value;

            return model;
        }

        public int? Id { get; set; }

        public bool Consultar { get; set; }

        public bool Inserir { get; set; }

        public bool Alterar { get; set; }

        public bool Excluir { get; set; }

        public bool Visualizar { get; set; }

        public FuncaoDTO Funcao { get; set; }

        public PerfilDTO Perfil { get; set; }

    }
}
