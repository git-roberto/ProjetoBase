using Microsoft.AspNetCore.Mvc;
using ProjetoBase.Model;
using ProjetoBase.Service;
using ProjetoBase.Transport;
using Utilidades.Base;
using Utilidades.Helpers;
using Utilidades.Models;

namespace ProjetoBase.Api.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Listar()
        {
            using ClienteService service = new();
            var retorno = service.Listar().OrderBy("Nome", "DESC").Select(x => x.ToDTO<Cliente, ClienteDTO>()).ToList();

            return Sucesso(retorno);
        }

        [HttpGet]
        public IActionResult Pesquisar(Filtro filtro, ClienteDTO pesquisa)
        {
            using ClienteService service = new();
            var retorno = service.Listar().OrderBy(filtro)
                                          .Paginar(filtro)
                                          .Select(x => x.ToDTO<Cliente, ClienteDTO>()).ToList();

            return Sucesso(retorno);

        }

        [HttpGet]
        public IActionResult Buscar(int id)
        {
            using ClienteService service = new();
            var retorno = service.Buscar(x => x.Id == id)?.ToDTO<Cliente, ClienteDTO>();

            return Sucesso(retorno);

        }
    }
}
