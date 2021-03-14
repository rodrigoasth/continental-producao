using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Continental.Producao.Application.Produtos.Command.CriarProduto
{
    public class CriarProdutoCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}
