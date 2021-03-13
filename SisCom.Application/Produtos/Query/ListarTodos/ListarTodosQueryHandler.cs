using Dapper;
using MediatR;
using Continental.Producao.Infra.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Continental.Producao.Application.Produtos.Query.ListarTodos
{
    public class ListarTodosQueryHandler : IRequestHandler<ListarTodosQuery, IEnumerable<ListarTodosResult>>
    {
        private readonly IProducaoReadContext _db;

        public ListarTodosQueryHandler(IProducaoReadContext db)
        {
            this._db = db;
        }

        public async Task<IEnumerable<ListarTodosResult>> Handle(ListarTodosQuery request, CancellationToken cancellationToken)
        {
            using (var conn = _db.GetConnection())
            {
                var result = conn.QueryAsync<ListarTodosResult>("Select * from Produto;");
                return await result;
            }            
        }
    }
}
