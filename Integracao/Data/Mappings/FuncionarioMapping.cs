using Integracao.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integracao.Data.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.OwnsOne(e => e.Cpf,
                c =>
                {
                    c.Property(cpf => cpf.Numero)
                            .HasColumnName("CPF")
                            .HasMaxLength(11)
                            .IsRequired()
                            .IsFixedLength();
                });

            builder.HasOne(f => f.Cargo)
                .WithMany(c => c.Funcionarios)
                .HasForeignKey("CargoId");
        }
    }
}
