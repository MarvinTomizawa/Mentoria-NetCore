using Integracao.Models.Entities;
using System.Collections.Generic;

namespace Integracao.Data.Interfaces
{
    public interface IFuncionarioRepository : IEntityRepository<Funcionario>
    {
        IEnumerable<Funcionario> ObterTodosComCargoEEmpresa();
        Funcionario ObterComCargoEEmpresaPorId(int id);
        Funcionario ObterPorCpf(string cpf);
    }
}
