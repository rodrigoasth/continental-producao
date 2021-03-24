using MediatR;
using System;
using System.Collections.Generic;

namespace Continental.Producao.Application.SolicitacoesCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public IList<Item> Itens { get; set; }
    }

    public class Item
    {
        public Guid IdProduto { get; set; }
        public int Qtde { get; set; }
    }
}
