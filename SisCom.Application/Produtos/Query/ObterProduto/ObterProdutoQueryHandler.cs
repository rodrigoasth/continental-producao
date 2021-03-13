using Dapper;
using MediatR;
using SisCom.Infra.Data;
using System.Threading;
using System.Threading.Tasks;

namespace SisCom.Application.Produtos.Query.ObterProduto
{
    public class ObterProdutoQueryHandler : IRequestHandler<ObterProdutoQuery, ObterProdutoResult>
    {
        private readonly ISisComReadContext _db;

        public ObterProdutoQueryHandler(ISisComReadContext db)
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
