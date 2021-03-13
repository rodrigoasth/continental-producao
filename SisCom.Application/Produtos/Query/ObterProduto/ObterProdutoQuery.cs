using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SisCom.Application.Produtos.Query.ObterProduto
{
    public class ObterProdutoQuery : IRequest<ObterProdutoResult>
    {
        public Guid Id { get; set; }
    }
}
