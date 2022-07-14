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
    public class PerfilUsuarioDTO : BaseDTO<PerfilUsuario, PerfilUsuarioDTO>
    {

        public PerfilUsuarioDTO()
        {

        }

        public PerfilUsuarioDTO(PerfilUsuario model)
        {
            IdPerfil = model.IdPerfil;
            IdUsuario = model.IdUsuario;

            Perfil = model.Perfil?.ToDTO<Perfil, PerfilDTO>();
        }

        public override PerfilUsuario Modelo(IDbContext contexto)
        {
            PerfilUsuario model = contexto.Conexao.Set<PerfilUsuario>().FirstOrDefault(x => x.IdPerfil == IdPerfil && x.IdUsuario == IdUsuario);

            model.IdUsuario = IdUsuario;

            model.Perfil = Perfil != null && Perfil.Id.HasValue ? contexto.Conexao.Set<Perfil>().FirstOrDefault(x => x.Id == Perfil.Id.Value) : null;
            model.IdPerfil = IdPerfil;

            return model;
        }

        public int IdPerfil { get; set; }

        public int IdUsuario { get; set; }

        public PerfilDTO Perfil { get; set; }
    }
}
