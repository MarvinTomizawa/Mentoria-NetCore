using Integracao.Models.Entities;
using System.Collections.Generic;

namespace Integracao.Data.Interfaces
{
    public interface IEntityRepository<T> where T : BaseEntity<T>
    {
        IEnumerable<T> ObterTodos();
        IEnumerable<T> ObterTodosAtivos();
        IEnumerable<T> ObterTodosPaginados(int s, int t);
        T ObterPorId(int id);
        void Inativar(int id);
        void Adicionar(T obj);
        void Atualizar(T obj);
        void Salvar();
    }
}
