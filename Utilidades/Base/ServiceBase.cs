using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utilidades.ORM;

namespace Utilidades.Base
{
    public class ServiceBase<T> : IDisposable where T : class
    {
        public IDbContext Contexto { get; set; }

        public ServiceBase(IDbContext _context)
        {
            //Abre a conexão com o BD
            Contexto = _context;
        }

        /// <summary>
        /// Lista todos os registros
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> Listar()
        {
            var lst = Contexto.Conexao.Set<T>().AsQueryable();

            return lst;
        }

        /// <summary>
        /// Lista os registros de acordo com o filtro (LAMBDA)
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> Listar(Expression<Func<T, bool>> filtro)
        {
            var lst = Contexto.Conexao.Set<T>().Where(filtro).AsQueryable();

            return lst;
        }

        /// <summary>
        /// Busca um registro pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Buscar(int id)
        {
            var registro = Contexto.Conexao.Set<T>().Find(id);

            return registro;
        }

        /// <summary>
        /// Busca um registro pelo filtro
        /// </summary>
        /// <returns></returns>
        public virtual T Buscar(Expression<Func<T, bool>> filtro)
        {
            var registro = Contexto.Conexao.Set<T>().FirstOrDefault(filtro);

            return registro;
        }

        /// <summary>
        /// Insere um registro
        /// </summary>
        /// <param name="registro"></param>
        /// <returns></returns>
        public virtual T Inserir(T registro)
        {

            var retorno = Contexto.Conexao.Set<T>().Add(registro).Entity;
            Contexto.Conexao.SaveChanges();

            return retorno;
        }

        /// <summary>
        /// ALtera um registro
        /// </summary>
        /// <param name="registro"></param>
        public virtual void Alterar(T registro)
        {

            Contexto.Conexao.Entry(registro).State = EntityState.Modified;
            Contexto.Conexao.SaveChanges();
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="registro"></param>
        public virtual void Excluir(T registro)
        {
            Contexto.Conexao.Set<T>().Remove(registro);
            Contexto.Conexao.SaveChanges();
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="id"></param>
        public virtual void Excluir(int id)
        {
            var registro = Buscar(id);

            Excluir(registro);
        }

        public IDbContextTransaction BeginTransaction()
        {
            var retorno = Contexto.Conexao.Database.BeginTransaction();

            return retorno;
        }

        public void Commit(IDbContextTransaction transaction)
        {
            transaction.Commit();
        }

        public void RollBack(IDbContextTransaction transaction)
        {
            transaction.Rollback();
        }

        public void Dispose()
        {
            //Fecha a conexão com o BD
            if (Contexto != null)
            {
                Contexto.Dispose();
                Contexto = null;
            }
        }
    }
}
