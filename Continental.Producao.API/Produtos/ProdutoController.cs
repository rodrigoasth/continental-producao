using MediatR;
using Microsoft.AspNetCore.Mvc;
using Continental.Producao.Application.Produtos.Command.CriarProduto;
using Continental.Producao.Application.Produtos.Query.ListarTodos;
using Continental.Producao.Application.Produtos.Query.ObterProduto;
using System;
using System.Threading.Tasks;

namespace Continental.Producao.API.Produtos
{
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet, Route("produto/")]
        public async Task<IActionResult> ObterTodos()
        {
            var produtos = await _mediator.Send(new ListarTodosQuery());

            return Ok(produtos);
        }

        [HttpGet, Route("produto/{id}")]
        public async Task<IActionResult> ObterProduto(Guid id)
        {
            var produtos = await _mediator.Send(new ObterProdutoQuery() { Id = id });
            return Ok(produtos);
        }

        [HttpPost, Route("produto/")]
        public async Task<IActionResult> Criar([FromBody] CriarProdutoCommand criarProdutoCommand)
        {
            await _mediator.Send(criarProdutoCommand);

            return StatusCode(201);
        }
    }
}
