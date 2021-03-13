using SisCom.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SisCom.Domain.Produtos
{
    public class Produto : Entity<Guid>, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Situacao? Situacao { get; private set; }
        public Money PrecoUnitario { get; private set; }

        private Produto() { }

        public Produto(string nome, string descricao, double preco)
        {
            Id = Guid.NewGuid();

            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            PrecoUnitario = new Money(preco);

            Situacao = Produtos.Situacao.Ativo;
        }
    }
}
