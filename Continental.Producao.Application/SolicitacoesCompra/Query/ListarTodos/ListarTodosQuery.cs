using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Continental.Producao.Application.SolicitacoesCompra.Query.ListarTodos
{
    public class ListarTodosQuery : IRequest<IEnumerable<ListarTodosResult>>
    {
    }
}
