using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Json;

namespace Utilidades.Base
{
    [Route("[controller]/[action]")]
    public class BaseController: ControllerBase
    {
        protected OkObjectResult Sucesso<T>(RetornoJson<T> retorno)
        {
            return Ok(retorno);
        }

        protected OkObjectResult Sucesso(string mensagem)
        {
            RetornoJson<bool> retorno = new RetornoJson<bool>
            {
                mensagem = mensagem,
            };

            return Ok(retorno);
        }

        protected OkObjectResult Sucesso(bool valor)
        {
            RetornoJson<bool> retorno = new RetornoJson<bool>
            {
                resultado = valor,
            };

            return Ok(retorno);
        }

        protected OkObjectResult Sucesso(object valor)
        {
            RetornoJson<object> retorno = new RetornoJson<object>
            {
                resultado = valor,
            };
            return Ok(retorno);
        }

        protected OkObjectResult Sucesso(object valor, string mensagem)
        {

            RetornoJson<object> retorno = new RetornoJson<object>
            {
                resultado = valor,
                mensagem = mensagem
            };
            return Ok(retorno);
        }
    }
}
