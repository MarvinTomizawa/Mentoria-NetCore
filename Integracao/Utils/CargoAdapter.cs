using Integracao.Dto;
using Integracao.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Integracao.Utils
{
    public static class CargoAdapter
    {
        public static Cargo Mapear(CargoDto cargoDto)
        {
            return new Cargo(cargoDto.Descricao);
        }

        public static Cargo Mapear(CargoDto cargoDto, int cargoId)
        {
            var cargo = new Cargo(cargoDto.Descricao);

            cargo.Id = cargoId;

            return cargo;
        }

        public static CargoDto Mapear(this Cargo cargo)
        {
            return new CargoDto
            {
                Id = cargo.Id,
                Descricao = cargo.Descricao,
                Inativo = cargo.Inativo
            };
        }

        public static IEnumerable<CargoDto> Mapear(this IEnumerable<Cargo> cargos)
        {
            return cargos.Select(x => Mapear(x));
        }
    }
}
