using MediatR;
using System.Collections.Generic;

namespace SisCom.Application.Produtos.Query.ListarTodos
{
    public class ListarTodosQuery : IRequest<IEnumerable<ListarTodosResult>>
    {
    }
}
