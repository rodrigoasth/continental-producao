using MediatR;
using System;

namespace Continental.Producao.Application.SolicitacoesCompra.Command.ExcluirCompra
{
    public class ExcluirCompraCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
