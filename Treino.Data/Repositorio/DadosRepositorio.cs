using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treino.Core.Interfaces;
using Treino.Data;

namespace Treino.Data.Repositorio
{
    public partial class DadosRepository : IDadosRepositorio, IDisposable
    {
        //Atributos
        private readonly DataContexto contexto;
        private IDbContextTransaction transacao;
        private Dictionary<Type, object> repositorios = new Dictionary<Type, object>();

        //Metodos
        public DadosRepository(DataContexto contexto)
        {
            this.contexto = contexto;
        }
        /// <summary>
        ///  Método que instancia um repositório da entidade dinamicamente
        /// </summary>
        /// <typeparam name="T">Entidade</typeparam>        
        /// <returns>Retorna o repositorio de dados da entidade</returns>
        public virtual IBaseRepositorio<T> Repositorio<T>() where T : class
        {
            //Verifica se a entidade é um repositorio de dados
            if (repositorios.Keys.Contains(typeof(T)) == true)
            {
                return repositorios[typeof(T)] as IBaseRepositorio<T>;
            }
            //Instancia o repositorio de dados da entidade
            IBaseRepositorio<T> repositorio = new BaseRepositorio<T>(contexto);
            repositorios.Add(typeof(T), repositorio);
            return repositorio;
        }

        /// <summary>
        /// Método que salva todos os repositorios do contexto por Commit/Rollback
        /// </summary>
        public virtual void SalvaTodos()
        {
            using (transacao = contexto.Database.BeginTransaction())
            {
                try
                {
                    contexto.SaveChanges();
                    transacao.Commit();
                }
                catch (Exception erro)
                {
                    transacao.Rollback();
                    throw new Exception(erro.Message);
                }
                finally
                {
                    contexto.Dispose();
                    transacao.Dispose();
                }
            }
        }

        /// <summary>
        /// Método assincrono que salva todos os repositorios do contexto por Commit/Rollback
        /// </summary>
        public virtual async Task SalvaTodosAsync()
        {
            using (transacao = contexto.Database.BeginTransaction())
            {
                try
                {
                    await contexto.SaveChangesAsync();
                    transacao.Commit();
                }
                catch (Exception erro)
                {
                    transacao.Rollback();
                    throw new Exception(erro.Message);
                }
                finally
                {
                    contexto.Dispose();
                    transacao.Dispose();
                }
            }
        }

        public virtual void Dispose()
        {
            contexto.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
