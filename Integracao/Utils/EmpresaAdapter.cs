using Integracao.Dto;
using Integracao.Models.Entities;
using Integracao.Models.VOs;
using System.Collections.Generic;
using System.Linq;

namespace Integracao.Utils
{
    public static class EmpresaAdapter
    {
        public static Empresa Mapear(EmpresaDto empresaDto)
        {
            return new Empresa(empresaDto.Nome,
                               new CNPJ(empresaDto.CNPJ));
        }

        public static Empresa Mapear(EmpresaDto empresaDto, int empresaId)
        {
            var empresa = new Empresa(empresaDto.Nome,
                             new CNPJ(empresaDto.CNPJ));

            empresa.Id = empresaId;

            return empresa;
        }

        public static EmpresaDto Mapear(this Empresa empresa)
        {
            return new EmpresaDto
            {
                Id = empresa.Id,
                Nome = empresa.Nome,
                CNPJ = empresa.Cnpj.Numero,
                Inativo = empresa.Inativo
            };
        }

        public static IEnumerable<EmpresaDto> Mapear(this IEnumerable<Empresa> empresas)
        {
            return empresas.Select(x => Mapear(x));
        }
    }
}
