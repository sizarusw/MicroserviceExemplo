using Api.Produto.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Produto.Dominio
{
    public class ProdutoDominio : IProdutoRepository<Produto>
    {
        private ISession _session;
        public ProdutoDominio(ISession session) => _session = session;


        /// <summary>
        /// Encontra o registro usando como param o Id (Chave Primaria).
        /// </summary>
        /// <param name="id">Código identificador do registro no banco</param>
        /// <returns>Objeto do Produto</returns>
        public Produto FindByID(Int64 id)
        {
            return _session.Get<Produto>(id);
        }

        /// <summary>
        /// Faz um insert ou update no ORM, caso haja um identificador (Campo Id) preenchido, o sistema identificará como Atualização, caso contrário é considerado Inserção.
        /// </summary>
        /// <param name="item">Objeto preenchido com o Modelo Produto</param>
        /// <returns>Boolean, True = êxito, False = Falha</returns>
        public bool Upsert(Produto item)
        {

            bool retorno = false;

            ITransaction transaction = null;

            //É possível também utilizar o _session.SaveOrUpdate caso tenha identificadores bem definidos.
            // Teste

            try
            {
                transaction = _session.BeginTransaction();

                if (item.Id > 0)
                {
                    _session.Update(item);
                    transaction.Commit();
                }
                else
                {
                    _session.Save(item);
                    transaction.Commit();
                }
                retorno = true;
            }
            catch (Exception ex)
            {
                retorno = false;
                Console.WriteLine(ex.Message);
                transaction.Rollback();

            }
            finally
            {
                transaction.Dispose();
            }

            return retorno;
        }


        /// <summary>
        /// Remove o registro usando como param o Id (Chave Primaria)
        /// </summary>
        /// <param name="id">Código identificador do registro no banco</param>
        /// <returns>Boolean, True = êxito, False = Falha</returns>
        public bool Delete(Int64 id)
        {
            bool retorno = false;

            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var item = _session.Get<Produto>(id);
                _session.Delete(item);
                transaction.Commit();
                retorno = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
                retorno = false;
            }
            finally
            {
                transaction.Dispose();
            }

            return retorno;
        }

        /// <summary>
        /// Busca todos os registros da tabela no ORM
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        public List<Produto> GetAll()
        {
            return _session.Query<Produto>().ToList();
        }

    }
}
