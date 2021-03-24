using MediatR;
using System;

namespace Continental.Producao.Application.Produtos.Command.AtivarProduto
{
    public class AtivarProdutoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
