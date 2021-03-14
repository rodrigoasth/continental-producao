using MediatR;
using Continental.Producao.Domain.Produtos;
using Continental.Producao.Infra.Data.UoW;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Continental.Producao.Application.Produtos.Command.CriarProduto
{
    public class CriarProdutoCommandHandler : IRequestHandler<CriarProdutoCommand, Guid>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _uow;

        public CriarProdutoCommandHandler(IProdutoRepository produtoRepository, IUnitOfWork uow)
        {
            this._produtoRepository = produtoRepository;
            this._uow = uow;
        }

        public async Task<Guid> Handle(CriarProdutoCommand p, CancellationToken cancellationToken)
        {
            var produto = new Produto(p.Nome, p.Descricao, p.Preco);
            await _produtoRepository.Criar(produto);

            _uow.Commit();

            return produto.Id;
        }
    }
}
