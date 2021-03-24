using MediatR;
using Microsoft.AspNetCore.Mvc;
using Continental.Producao.Application.Produtos.Command.CriarProduto;
using Continental.Producao.Application.Produtos.Query.ListarTodos;
using Continental.Producao.Application.Produtos.Query.ObterProduto;
using System;
using System.Threading.Tasks;
using Continental.Producao.Application.Produtos.Command.AtualizarPreco;

namespace Continental.Producao.API.Produtos
{
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodosAsync()
        {
            var produtos = await _mediator.Send(new ListarTodosQuery());
            return Ok(produtos);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> ObterProdutoAsync(Guid id)
        {
            var produto = await _mediator.Send(new ObterProdutoQuery() { Id = id });
            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarProdutoCommand criarProdutoCommand)
        {
            await _mediator.Send(criarProdutoCommand);

            return StatusCode(201);
        }

        [HttpPatch]
        public async Task<IActionResult> AtualizarPrecoAsync([FromBody] AtualizarPrecoCommand atualizarPrecoCommand)
        {
            await _mediator.Send(atualizarPrecoCommand);
            return Ok();
        }
    }
}
