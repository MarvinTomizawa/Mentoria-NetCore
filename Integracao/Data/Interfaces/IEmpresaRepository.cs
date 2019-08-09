using Integracao.Models.Entities;

namespace Integracao.Data.Interfaces
{
    public interface IEmpresaRepository : IEntityRepository<Empresa>
    {
        Empresa ObterPorCnpj(string numero);
    }
}
