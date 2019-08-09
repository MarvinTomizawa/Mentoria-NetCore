using Integracao.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Integracao.Data
{
    public class IntegracaoContext : DbContext
    {
        public IntegracaoContext(DbContextOptions<IntegracaoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMapping());
            modelBuilder.ApplyConfiguration(new EmpresaMapping());
            modelBuilder.ApplyConfiguration(new CargoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}