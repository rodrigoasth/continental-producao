using Continental.Producao.Application.SolicitacoesCompra.Command.ExcluirCompra;
using Continental.Producao.Application.SolicitacoesCompra.Command.RegistrarCompra;
using Continental.Producao.Application.SolicitacoesCompra.Query.ListarTodos;
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

        [HttpGet]
        public async Task<IActionResult> ListarTodosAsync()
        {
            var solicitacoes = await _mediator.Send(new ListarTodosQuery());
            return Ok(solicitacoes);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCompra([FromBody]RegistrarCompraCommand registrarCompraCommand)
        {
            await _mediator.Send(registrarCompraCommand);
            return StatusCode(201);
        }
    }
}
