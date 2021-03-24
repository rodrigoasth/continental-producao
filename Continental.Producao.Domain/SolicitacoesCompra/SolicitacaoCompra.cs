using Continental.Producao.Domain.Core;
using Continental.Producao.Domain.Produtos;
using Continental.Producao.Domain.SolicitacoesCompra.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Continental.Producao.Domain.SolicitacoesCompra
{
    public class SolicitacaoCompra : Entity<Guid>
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Itens = new List<Item>();

            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            CondicaoPagamento = new CondicaoPagamento(0);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new Item(produto, qtde));
        }

        public void RegistrarCompra()
        {
            if (!Itens.Any()) throw new BusinessRuleException("A solicitação de compra deve possuir itens!");

            TotalGeral = new Money(Itens.ToList().Sum(x => x.Subtotal.Value));

            if (TotalGeral.Value > 50000) CondicaoPagamento = new CondicaoPagamento(30);

            AddEvent(new CompraRegistradaEvent(Id, Itens, TotalGeral.Value));
        }
    }
}
