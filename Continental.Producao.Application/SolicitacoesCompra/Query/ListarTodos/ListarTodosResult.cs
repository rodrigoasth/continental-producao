using System;

namespace Continental.Producao.Application.SolicitacoesCompra.Query.ListarTodos
{
    public class ListarTodosResult
    {
        public string Id { get; set; }
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public DateTime Data { get; set; }
        public double TotalGeral { get; set; }
    }
}
