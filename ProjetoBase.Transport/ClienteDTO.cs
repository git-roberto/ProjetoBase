using ProjetoBase.Config.Infra;
using ProjetoBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Base;
using Utilidades.ORM;

namespace ProjetoBase.Transport
{
    public class ClienteDTO : BaseDTO<Cliente, ClienteDTO>
    {
        public ClienteDTO()
        {

        }

        public ClienteDTO(Cliente model)
        {
            Id = model.Id;
            Nome = model.Nome;
            Email = model.Email;
        }

        public override Cliente Modelo(IDbContext contexto)
        {
            Cliente model = new();
            if (Id.HasValue)
            {
                model = contexto.Conexao.Set<Cliente>().Find(Id);
            }

            model.Nome = Nome;
            model.Email = Email;

            return model;
        }
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
