using Dapper;
using MediatR;
using SisCom.Infra.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SisCom.Application.Produtos.Query.ListarTodos
{
    public class ListarTodosQueryHandler : IRequestHandler<ListarTodosQuery, IEnumerable<ListarTodosResult>>
    {
        private readonly ISisComReadContext _db;

        public ListarTodosQueryHandler(ISisComReadContext db)
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
