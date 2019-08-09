using Integracao.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao.Data.Interfaces
{
    public interface IEntityService<T,Y> where T: BaseEntity<T>
    {
        IList<T> ObterTodos();
        T ObterPorId(int id);
        IList<string> Adicionar(Y obj);
        IList<string> Inativar(int id);
        IList<string> Atualizar(Y obj, int id);

    }
}
