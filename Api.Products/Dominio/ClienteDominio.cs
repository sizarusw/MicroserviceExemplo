using Api.Cliente.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Cliente.Dominio
{
    public class ClienteDominio : IClienteRepository<Cliente>
    {
        private ISession _session;
        public ClienteDominio(ISession session) => _session = session;


        /// <summary>
        /// Encontra o registro usando como param o Id (Chave Primaria)
        /// </summary>
        /// <param name="id">Código identificador do registro no banco</param>
        /// <returns>Objeto do Cliente</returns>
        public Cliente FindByID(Int64 id)
        {
            return _session.Get<Cliente>(id);
        }

        /// <summary>
        /// Faz um insert ou update no ORM, caso haja um identificador (Campo Id) preenchido, o sistema identificará como Atualização, caso contrário é considerado Inserção.
        /// </summary>
        /// <param name="item">Objeto preenchido com o Modelo Cliente</param>
        /// <returns>Boolean, True = êxito, False = Falha</returns>
        public bool Upsert(Cliente item)
        {

            bool retorno = false;

            ITransaction transaction = null;

            //É possível também utilizar o _session.SaveOrUpdate caso tenha identificadores bem definidos.

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
                var item = _session.Get<Cliente>(id);
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
        /// <returns>Lista de Clientes</returns>
        public List<Cliente> GetAll()
        {
            return _session.Query<Cliente>().ToList();
        }

    }
}
