using Continental.Producao.Domain.Produtos;
using Continental.Producao.Infra.Data.UoW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Continental.Producao.Application.Produtos.Command.AtualizarPreco
{
    public class AtualizarPrecoCommandHandler : CommandHandler, IRequestHandler<AtualizarPrecoCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;

        public AtualizarPrecoCommandHandler(IProdutoRepository produtoRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this._produtoRepository = produtoRepository;
        }
        public Task<bool> Handle(AtualizarPrecoCommand request, CancellationToken cancellationToken)
        {
            var produto = _produtoRepository.Obter(request.Id);
            produto.AtualizarPreco(request.PrecoUnitario);
            _produtoRepository.Atualizar(produto);

            Commit();
            PublishEvents(produto.Events);

            return Task.FromResult(true);
        }
    }
}
