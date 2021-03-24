using Continental.Producao.Domain.SolicitacoesCompra.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Continental.Producao.Application.SolicitacoesCompra.Command.RegistrarCompra
{
    public class CompraRegistradaEventHandler : INotificationHandler<CompraRegistradaEvent>
    {
        public Task Handle(CompraRegistradaEvent notification, CancellationToken cancellationToken)
        {
            return null;//SignalIrTodo
        }
    }
}
