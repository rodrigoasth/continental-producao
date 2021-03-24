using Continental.Producao.Application.Produtos.Query.ListarTodos;
using Continental.Producao.Infra.Data;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Continental.Producao.Application.SolicitacoesCompra.Query.ListarTodos
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
                var result = conn.QueryAsync<ListarTodosResult>("Select * from SolicitacaoCompra;");
                return await result;
            }
        }
    }
}
