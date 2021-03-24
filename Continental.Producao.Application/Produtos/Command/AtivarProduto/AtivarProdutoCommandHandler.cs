using Continental.Producao.Domain.Produtos;
using Continental.Producao.Infra.Data.UoW;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Continental.Producao.Application.Produtos.Command.AtivarProduto
{
    public class AtivarProdutoCommandHandler : CommandHandler, IRequestHandler<AtivarProdutoCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;

        public AtivarProdutoCommandHandler(IProdutoRepository produtoRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this._produtoRepository = produtoRepository;
        }

        public Task<bool> Handle(AtivarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = _produtoRepository.Obter(request.Id);
            produto.Ativar();

            _produtoRepository.Atualizar(produto);

            Commit();

            return Task.FromResult(true);
        }
    }
}
