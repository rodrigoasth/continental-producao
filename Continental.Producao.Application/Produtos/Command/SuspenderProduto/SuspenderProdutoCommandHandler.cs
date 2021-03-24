using Continental.Producao.Domain.Produtos;
using Continental.Producao.Infra.Data.UoW;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Continental.Producao.Application.Produtos.Command.SuspenderProduto
{
    public class SuspenderProdutoCommandHandler : CommandHandler, IRequestHandler<SuspenderProdutoCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;

        public SuspenderProdutoCommandHandler(IProdutoRepository produtoRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this._produtoRepository = produtoRepository;
        }

        public Task<bool> Handle(SuspenderProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = _produtoRepository.Obter(request.Id);
            produto.Suspender();

            _produtoRepository.Atualizar(produto);

            Commit();

            return Task.FromResult(true);
        }
    }
}
