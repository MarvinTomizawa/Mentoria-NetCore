using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Integracao.Controllers
{
    public class DefaultController : ControllerBase
    {
        protected IList<string> mensagens;
        protected ActionResult ValidarRequest(string mensagemDeSucesso)
        {
            if (mensagens.Count != 0)
            {
                return BadRequest();
            }

            return Ok(new { Success = true, Messagem = mensagemDeSucesso });
        }
    }
}