﻿using MediatR;
using SisCom.Domain.Produtos;
using SisCom.Infra.Data.UoW;
using System.Threading;
using System.Threading.Tasks;

namespace SisCom.Application.Produtos.Command.CriarProduto
{
    public class CriarProdutoCommandHandler : IRequestHandler<CriarProdutoCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _uow;

        public CriarProdutoCommandHandler(IProdutoRepository produtoRepository, IUnitOfWork uow)
        {
            this._produtoRepository = produtoRepository;
            this._uow = uow;
        }

        public async Task<bool> Handle(CriarProdutoCommand p, CancellationToken cancellationToken)
        {
            var produto = new Produto(p.Nome, p.Descricao, p.Preco);
            await _produtoRepository.Criar(produto);

            _uow.Commit();

            return true;
        }
    }
}
