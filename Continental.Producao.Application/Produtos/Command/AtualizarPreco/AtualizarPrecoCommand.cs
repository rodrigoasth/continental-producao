using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Continental.Producao.Application.Produtos.Command.AtualizarPreco
{
    public class AtualizarPrecoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public double PrecoUnitario { get; set; }
    }
}
