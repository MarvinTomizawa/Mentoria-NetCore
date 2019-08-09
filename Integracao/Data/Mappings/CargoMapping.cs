using Integracao.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integracao.Data.Mappings
{
    public class CargoMapping : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany((System.Linq.Expressions.Expression<System.Func<Cargo, System.Collections.Generic.IEnumerable<Funcionario>>>)(e => (System.Collections.Generic.IEnumerable<Funcionario>)e.Funcionarios))
                .WithOne(f => f.Cargo)
                .IsRequired();
        }
    }
}
