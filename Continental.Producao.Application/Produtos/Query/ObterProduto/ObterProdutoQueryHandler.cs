using Dapper;
using MediatR;
using Continental.Producao.Infra.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Continental.Producao.Application.Produtos.Query.ObterProduto
{
    public class ObterProdutoQueryHandler : IRequestHandler<ObterProdutoQuery, ObterProdutoResult>
    {
        private readonly IProducaoReadContext _db;

        public ObterProdutoQueryHandler(IProducaoReadContext db)
        {
            this._db = db;
        }

        public async Task<ObterProdutoResult> Handle(ObterProdutoQuery request, CancellationToken cancellationToken)
        {
            using (var conn = _db.GetConnection())
            {
                var result = conn.QuerySingleAsync<ObterProdutoResult>("SELECT * FROM PRODUTO WHERE ID = @Id", request);
                return await result;
            }
        }
    }
}
