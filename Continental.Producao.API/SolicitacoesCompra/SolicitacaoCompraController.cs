using Continental.Producao.Application.SolicitacoesCompra.Command.RegistrarCompra;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Continental.Producao.API.SolicitacoesCompra
{
    [Route("api/solicitacoes-compra")]
    public class SolicitacaoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("registra")]
        public async Task<IActionResult> RegistrarCompra([FromBody]RegistrarCompraCommand registrarCompraCommand)
        {
            await _mediator.Send(registrarCompraCommand);
            return StatusCode(201);
        }
    }
}
