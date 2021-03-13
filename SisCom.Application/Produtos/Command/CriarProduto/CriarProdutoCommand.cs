using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SisCom.Application.Produtos.Command.CriarProduto
{
    public class CriarProdutoCommand : IRequest<bool>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}
