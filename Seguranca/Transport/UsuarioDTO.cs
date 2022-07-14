using Seguranca.Config.Helpers;
using Seguranca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades;
using Utilidades.Base;
using Utilidades.ORM;

namespace Seguranca.Transport
{
    public class UsuarioDTO : BaseDTO<Usuario, UsuarioDTO>
    {

        public UsuarioDTO()
        {
            Perfil = new List<PerfilUsuarioDTO>();
        }

        public UsuarioDTO(Usuario model)
        {
            Id = model.Id;
            Login = model.Login;
            Nome = model.Nome;
            Senha = model.Senha;
            DataSenha = model.DataSenha;
            Bloqueado = model.Bloqueado;
            Situacao = model.Situacao;

            Perfil = model.Perfil.Select(x => x.ToDTO<PerfilUsuario, PerfilUsuarioDTO>()).ToList();
        }

        public override Usuario Modelo(IDbContext contexto)
        {
            Usuario model = new Usuario();
            if (Id.HasValue)
            {
                model = contexto.Conexao.Set<Usuario>().Find(Id);
            }

            if (Senha != null && Senha != "" && Senha != model.Senha)
            {
                model.Senha = Criptografia.CriptografarSHA256(Senha);
            }

            model.Login = Login;
            model.Nome = Nome;
            model.DataSenha = DataSenha;
            model.Bloqueado = Bloqueado;
            model.Situacao = Situacao;

            return model;
        }

        public int? Id { get; set; }

        public string Login { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public DateTime DataSenha { get; set; }

        public bool Bloqueado { get; set; }

        public bool Situacao { get; set; }

        public List<PerfilUsuarioDTO> Perfil { get; set; }
    }
}
