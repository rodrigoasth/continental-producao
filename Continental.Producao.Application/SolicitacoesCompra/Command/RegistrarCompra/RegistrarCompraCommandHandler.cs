using Continental.Producao.Domain.Produtos;
using Continental.Producao.Domain.SolicitacoesCompra;
using Continental.Producao.Infra.Data.UoW;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Continental.Producao.Application.SolicitacoesCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        public readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;
        private readonly IProdutoRepository _produtoRepository;

        public RegistrarCompraCommandHandler(ISolicitacaoCompraRepository solicitacaoCompraRepository,
                                             IProdutoRepository produtoRepository,
                                             IUnitOfWork uow,
                                             IMediator mediator) : base(uow, mediator)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
            _produtoRepository = produtoRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand command, CancellationToken cancellationToken)
        {
            var solicitacao = new SolicitacaoCompra(command.UsuarioSolicitante, command.NomeFornecedor);

            command.Itens.ToList().ForEach(x =>
            {
                var produto = _produtoRepository.Obter(x.IdProduto);
                solicitacao.AdicionarItem(produto, x.Qtde);
            });
            solicitacao.RegistrarCompra();

            _solicitacaoCompraRepository.RegistrarCompra(solicitacao);

            Commit();
            PublishEvents(solicitacao.Events);

            return Task.FromResult(true);
        }
    }
}
