using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Produto.Repository
{
    public interface IProdutoRepository<T>
    {
        T FindByID(Int64 id);

        bool Upsert(T objeto);

        bool Delete(Int64 id);

        List<T> GetAll();

    }
}
