using Integracao.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integracao.Data.Mappings
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.OwnsOne(e => e.Cnpj,
                c =>
                {
                    c.Property(cnpj => cnpj.Numero)
                            .HasColumnName("CNPJ")
                            .HasMaxLength(14)
                            .IsRequired()
                            .IsFixedLength();
                });

            builder.HasMany(e => e.Funcionarios)
                .WithOne(f => f.Empresa)
                .IsRequired();
        }
    }
}
