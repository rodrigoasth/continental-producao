using Continental.Producao.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Continental.Producao.Domain.SolicitacoesCompra.Events
{
    public class CompraRegistradaEvent : Event
    {
        public Guid Id { get; }
        public IEnumerable<Item> Itens { get; }
        public double TotalGeral { get; }

        public CompraRegistradaEvent(Guid id, IEnumerable<Item> itens, double TotalGeral)
        {
            Id = id;
            Itens = itens;
            this.TotalGeral = TotalGeral;
        }
    }
}
