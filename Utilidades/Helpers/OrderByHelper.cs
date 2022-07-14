using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Models;

namespace Utilidades.Helpers
{
    public static class OrderByHelper
    {

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> lista, Filtro filtro)
        {
            if (filtro == null || filtro.ordenacao == null)
                throw new Exception("A ordenação não foi informada. Para utilizá-la, informe os campos ordenacao.coluna e ordenacao.sentido, " +
                    "onde ordenacao.coluna é a coluna que a lista será ordenada e ordenacao.sentido o tipo da ordenação dos registros a serem exibidos.");

            return lista.OrderBy(filtro.ordenacao != null && !string.IsNullOrEmpty(filtro.ordenacao.coluna) ? filtro.ordenacao.coluna : "Id", filtro.ordenacao != null && filtro.ordenacao.sentido ? "" : "DESC");
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName, string sort)
        {
            if (sort.ToUpper().Contains("DESC"))
            {
                return query.OrderByDescending(propertyName);
            }
            else
            {
                return query.OrderBy(propertyName);
            }
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return CallOrderedQueryable(query, "OrderBy", propertyName, comparer);
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return CallOrderedQueryable(query, "OrderByDescending", propertyName, comparer);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return CallOrderedQueryable(query, "ThenBy", propertyName, comparer);
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return CallOrderedQueryable(query, "ThenByDescending", propertyName, comparer);
        }

        /// <summary>
        /// Builds the Queryable functions using a TSource property name.
        /// </summary>
        public static IOrderedQueryable<T> CallOrderedQueryable<T>(this IQueryable<T> query, string methodName, string propertyName,
                IComparer<object> comparer = null)
        {
            var param = Expression.Parameter(typeof(T), "x");

            var body = propertyName.Split('.').Aggregate<string, Expression>(param, Expression.PropertyOrField);

            return comparer != null
                ? (IOrderedQueryable<T>)query.Provider.CreateQuery(
                    Expression.Call(
                        typeof(Queryable),
                        methodName,
                        new[] { typeof(T), body.Type },
                        query.Expression,
                        Expression.Lambda(body, param),
                        Expression.Constant(comparer)
                    )
                )
                : (IOrderedQueryable<T>)query.Provider.CreateQuery(
                    Expression.Call(
                        typeof(Queryable),
                        methodName,
                        new[] { typeof(T), body.Type },
                        query.Expression,
                        Expression.Lambda(body, param)
                    )
                );
        }
    }
}
