using Continental.Producao.Domain.Core;
using Continental.Producao.Domain.Produtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Continental.Producao.Domain.SolicitacoesCompra
{
    public class Item : Entity<Guid>
    {
        public Produto Produto { get; set; }
        public int Qtde { get; set; }

        public Money Subtotal => ObterSubtotal();

        public Item(Produto produto, int qtde)
        {
            Produto = produto ?? throw new ArgumentNullException(nameof(produto));
            Qtde = qtde;
        }

        private Money ObterSubtotal()
        {
            return new Money(Produto.PrecoUnitario.Value * Qtde);
        }

        private Item() { }

    }
}
