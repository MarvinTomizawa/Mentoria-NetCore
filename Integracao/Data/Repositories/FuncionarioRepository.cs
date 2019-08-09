using System.Collections.Generic;
using System.Linq;
using Integracao.Data.Interfaces;
using Integracao.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Integracao.Data.Repositories
{
    public class FuncionarioRepository : TBaseRepository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(IntegracaoContext db) : base(db) {}

        public Funcionario ObterComCargoEEmpresaPorId(int id)
        {
            return DbSet.Include(x => x.Cargo)
                        .Include(x => x.Empresa)
                        .FirstOrDefault(x => x.Id == id);
        }

        public Funcionario ObterPorCpf(string cpf)
        {
            return DbSet.FirstOrDefault(x => x.Cpf.Numero.Equals(cpf));
        }

        public IEnumerable<Funcionario> ObterTodosComCargoEEmpresa()
        {
            return DbSet.Include(x => x.Cargo)
                        .Include(x => x.Empresa);
        }
    }
}
