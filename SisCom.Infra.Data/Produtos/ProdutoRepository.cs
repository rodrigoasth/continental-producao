using SisCom.Domain.Produtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisCom.Infra.Data.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SisComContext _context;

        public ProdutoRepository(SisComContext context)
        {
            this._context = context;
        }

        public async Task Criar(Produto produto)
        {
            await _context.Set<Produto>().AddAsync(produto);
        }

        public Produto Obter(Guid id)
        {
            return _context.Produtos.Single(x => x.Id == id);
        }
    }
}
