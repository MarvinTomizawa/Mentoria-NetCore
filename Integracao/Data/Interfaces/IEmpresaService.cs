using Integracao.Dto;
using Integracao.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao.Data.Interfaces
{
    public interface IEmpresaService: IEntityService<Empresa,EmpresaDto>
    {
    }
}
