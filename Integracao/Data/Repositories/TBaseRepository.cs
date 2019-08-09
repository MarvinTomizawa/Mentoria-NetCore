using Integracao.Data.Interfaces;
using Integracao.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Integracao.Data.Repositories
{
    public abstract class TBaseRepository<T> : IEntityRepository<T> where T : BaseEntity<T>
    {
        protected IntegracaoContext _db;
        protected DbSet<T> DbSet;

        public TBaseRepository(IntegracaoContext db)
        {
            this._db = db;
            this.DbSet = _db.Set<T>();
        }

        public void Adicionar(T entidade)
        {
            DbSet.Add(entidade);
            Salvar();
        }

        public void Atualizar(T entidade)
        {
            DbSet.Update(entidade);
            Salvar();
        }

        public void Inativar(int id)
        {
            var entidade = DbSet.Find(id);
            entidade.Inativar();
            Atualizar(entidade);
        }

        public T ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return DbSet.ToList();
        }

        public IEnumerable<T> ObterTodosAtivos()
        {
            return DbSet.Where(x => !x.Inativo);
        }

        public IEnumerable<T> ObterTodosPaginados(int s, int t)
        {
            return DbSet.Take(t).Skip(s);
        }

        public void Salvar()
        {
            _db.SaveChanges();
        }
    }
}
