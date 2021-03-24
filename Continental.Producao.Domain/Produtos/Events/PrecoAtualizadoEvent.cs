using Continental.Producao.Domain.Core;
using System;

namespace Continental.Producao.Domain.Produtos.Events
{
    public class PrecoAtualizadoEvent : Event
    {
        public Guid Id { get; }
        public double Preco { get; }

        public PrecoAtualizadoEvent(Guid id, double preco)
        {
            Id = id;
            Preco = preco;
        }
    }
}
