using Integracao.Data.Interfaces;
using Integracao.Dto;
using Integracao.Models.Entities;
using Integracao.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integracao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : DefaultController
    {
        private IFuncionarioService _funcionarioService;

        public FuncionariosController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<FuncionarioViewDto> ObterTodos()
        {
            var funcionario = _funcionarioService.ObterTodos();
            if (funcionario.Count > 0)
            {
                return funcionario.Mapear();
            }

            return null;
        }

        [HttpGet]
        [Route("{id:int}")]
        public FuncionarioViewDto ObterPorId(int id)
        {
            var funcionario = _funcionarioService.ObterPorId(id);
            if (funcionario != null)
            {
                return funcionario.Mapear();
            }

            return null;
        }

        [HttpPost]
        [Route("")]
        public ActionResult Adicionar(FuncionarioDto funcionarioDto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            mensagens = _funcionarioService.Adicionar(funcionarioDto);

            return ValidarRequest("Funcionario adicionado com sucesso.");
        }

        [HttpPatch]
        [Route("{id:int}")]
        public ActionResult Inativar(int id)
        {
            mensagens = _funcionarioService.Inativar(id);

            return ValidarRequest("Funcionario inativado com sucesso.");
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult Atualizar(FuncionarioDto funcionarioDto, int id)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            mensagens = _funcionarioService.Atualizar(funcionarioDto, id);

            return ValidarRequest("Funcionario atualizado com sucesso.");
        }

        private ActionResult ValidarRequest(string mensagemDeSucesso)
        {
            if (mensagens.Count != 0)
            {
                return BadRequest();
            }

            return Ok(new { Sucess = true, Message = mensagemDeSucesso });
        }

    }
}
