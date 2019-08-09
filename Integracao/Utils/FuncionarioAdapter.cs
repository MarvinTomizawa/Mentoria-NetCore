using Integracao.Dto;
using Integracao.Models.Entities;
using Integracao.Models.VOs;
using System.Collections.Generic;
using System.Linq;

namespace Integracao.Utils
{
    public static class FuncionarioAdapter
    {
        public static Funcionario Mapear(FuncionarioDto funcionarioDto, Cargo cargo, Empresa empresa)
        {
            return new Funcionario(funcionarioDto.Nome,
                                   funcionarioDto.EhHomeOffice,
                                   new CPF(funcionarioDto.Cpf),
                                   cargo,
                                   empresa);
        }

        public static Funcionario Mapear(FuncionarioDto funcionarioDto, Cargo cargo, Empresa empresa, int id)
        {
            var funcionario = new Funcionario(funcionarioDto.Nome,
                                   funcionarioDto.EhHomeOffice,
                                   new CPF(funcionarioDto.Cpf),
                                   cargo,
                                   empresa);

            funcionario.Id = id;

            return funcionario;
        }

        public static FuncionarioViewDto Mapear(this Funcionario funcionario)
        {
            return new FuncionarioViewDto
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Cpf = funcionario.Cpf.Numero,
                EhHomeOffice = funcionario.ÉHomeOffice,
                Inativo = funcionario.Inativo,
                Cargo = CargoAdapter.Mapear(funcionario.Cargo),
                Empresa = EmpresaAdapter.Mapear(funcionario.Empresa)
            };
        }

        public static IEnumerable<FuncionarioViewDto> Mapear(this IEnumerable<Funcionario> funcionarios)
        {
            return funcionarios.Select(x => Mapear(x));
        }
    }
}
