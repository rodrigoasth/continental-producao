using Continental.Producao.Domain.Produtos.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Continental.Producao.Application.Produtos.Command.AtualizarPreco
{
    public class PrecoAtualizadoEventHandler : INotificationHandler<PrecoAtualizadoEvent>
    {
        public Task Handle(PrecoAtualizadoEvent notification, CancellationToken cancellationToken)
        {
            return null;//SignalIR Todo
        }
    }
}
