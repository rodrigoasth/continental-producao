using Continental.Producao.Domain.Produtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Continental.Producao.Infra.Data.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProducaoContext _context;

        public ProdutoRepository(ProducaoContext context)
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
