using Integracao.Data.Interfaces;
using Integracao.Dto;
using Integracao.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Integracao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : DefaultController
    {
        private readonly ICargoService _cargoService;

        public CargosController
        (
            ICargoService cargoService
        )
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<CargoDto> ObterTodos()
        {
            var cargo = _cargoService.ObterTodos();
            if (cargo.Count > 0)
            {
                return cargo.Mapear();
            }

            return null;
        }

        [HttpGet]
        [Route("{id:int}")]
        public CargoDto Obter(int id)
        {
            var cargo = _cargoService.ObterPorId(id);
            if (cargo != null)
            {
                return cargo.Mapear();
            }

            return null;
        }

        [HttpPost]
        [Route("")]
        public ActionResult Adicionar(CargoDto cargoDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            mensagens = _cargoService.Adicionar(cargoDto);

            return ValidarRequest("Adicionado com sucesso!");
        }

        [HttpPatch]
        [Route("{id:int}")]
        public ActionResult Inativar(int id)
        {
            mensagens = _cargoService.Inativar(id);

            return ValidarRequest("Inativado com sucesso!");
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult Atualizar(CargoDto cargoDto, int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            mensagens = _cargoService.Atualizar(cargoDto, id);

            return ValidarRequest("Atualizado com sucesso!");
        }
    }
}
