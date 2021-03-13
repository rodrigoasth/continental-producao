using MediatR;
using System.Collections.Generic;

namespace Continental.Producao.Application.Produtos.Query.ListarTodos
{
    public class ListarTodosQuery : IRequest<IEnumerable<ListarTodosResult>>
    {
    }
}
