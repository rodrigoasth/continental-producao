using System;
using System.Threading.Tasks;

namespace SisCom.Domain.Produtos
{
    public interface IProdutoRepository
    {
        Produto Obter(Guid id);
        Task Criar(Produto produto);
    }
}
