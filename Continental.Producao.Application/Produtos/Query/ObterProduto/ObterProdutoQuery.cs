using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Continental.Producao.Application.Produtos.Query.ObterProduto
{
    public class ObterProdutoQuery : IRequest<ObterProdutoResult>
    {
        public Guid Id { get; set; }
    }
}
