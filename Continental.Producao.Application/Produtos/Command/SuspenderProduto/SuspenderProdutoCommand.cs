using MediatR;
using System;

namespace Continental.Producao.Application.Produtos.Command.SuspenderProduto
{
    public class SuspenderProdutoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
