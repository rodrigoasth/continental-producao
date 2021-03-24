using Continental.Producao.Domain.SolicitacoesCompra;
using Continental.Producao.Infra.Data.UoW;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Continental.Producao.Application.SolicitacoesCompra.Command.ExcluirCompra
{
    public class ExcluirCompraCommandHandler : CommandHandler, IRequestHandler<ExcluirCompraCommand, bool>
    {
        public readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;

        public ExcluirCompraCommandHandler(ISolicitacaoCompraRepository solicitacaoCompraRepository,
                                             IUnitOfWork uow,
                                             IMediator mediator) : base(uow, mediator)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
        }

        public Task<bool> Handle(ExcluirCompraCommand request, CancellationToken cancellationToken)
        {
            var sol = _solicitacaoCompraRepository.Obter(request.Id);
            _solicitacaoCompraRepository.ExcluirCompra(sol);

            Commit();

            return Task.FromResult(true);
        }
    }
}
