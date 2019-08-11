using Integracao.Data.Interfaces;
using Integracao.Dto;
using Integracao.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Integracao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : DefaultController
    {
        private readonly IEmpresaService _empresaService;

        public EmpresasController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<EmpresaDto> ObterTodos()
        {
            var empresa = _empresaService.ObterTodos();
            if (empresa.Count > 0)
            {
                return empresa.Mapear();
            }

            return null;
        }

        [HttpGet]
        [Route("{id:int}")]
        public EmpresaDto Obter(int id)
        {
            var empresa = _empresaService.ObterPorId(id);
            if (empresa != null)
            {
                return empresa.Mapear();
            }

            return null;
        }

        [HttpPost]
        [Route("")]
        public ActionResult Adicionar(EmpresaDto empresaDto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            mensagens = _empresaService.Adicionar(empresaDto);

            return ValidarRequest("Adicionado com sucesso.");
        }

        [HttpPatch]
        [Route("{id:int}")]
        public ActionResult Inativar(int id)
        {
            mensagens = _empresaService.Inativar(id);

            return ValidarRequest("Inativado com sucesso.");
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult Atualizar(EmpresaDto empresaDto, int id)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            mensagens = _empresaService.Atualizar(empresaDto, id);

            return ValidarRequest("Atualizado com sucesso.");
        }
    }
}
