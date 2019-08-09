using Integracao.Data.Interfaces;
using Integracao.Models.Entities;

namespace Integracao.Data.Repositories
{
    public class CargoRepository : TBaseRepository<Cargo>, ICargoRepository
    {
        public CargoRepository(IntegracaoContext db) : base(db)
        {
        }
    }
}
