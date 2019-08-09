using Integracao.Data.Interfaces;
using Integracao.Models.Entities;
using System.Linq;

namespace Integracao.Data.Repositories
{
    public class EmpresaRepository : TBaseRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(IntegracaoContext db) : base(db)
        {
        }

        public Empresa ObterPorCnpj(string numero)
        {
            return DbSet.FirstOrDefault(x => x.Cnpj.Numero.Equals(numero));
        }
    }
}
