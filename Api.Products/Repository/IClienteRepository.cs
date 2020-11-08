using System;
using System.Collections.Generic;

namespace Api.Cliente.Repository
{
    public interface IClienteRepository<T>
    {
        T FindByID(Int64 id);

        bool Upsert(T objeto);

        bool Delete(Int64 id);

        List<T> GetAll();

    }
}
