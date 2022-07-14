using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Models;

namespace Utilidades.Helpers
{
    public static class PaginacaoHelper
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> lista, Filtro filtro)
        {
            if (filtro == null || filtro.paginacao == null)
                throw new Exception("A paginação não foi informada. Para utilizá-la, informe os campos filtro.paginacao.inicio e paginacao.qtdRegistros, " +
                    "onde paginacao.inicio é o ID do registro que inicia a página e paginacao.qtdRegistros a quantidade de registros a serem exibidos.");

            return lista.Skip(filtro.paginacao.inicio).Take(filtro.paginacao.qtdRegistros);
        }
    }
}
