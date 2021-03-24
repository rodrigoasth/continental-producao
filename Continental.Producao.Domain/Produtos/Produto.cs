using Continental.Producao.Domain.Core;
using Continental.Producao.Domain.Produtos.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Continental.Producao.Domain.Produtos
{
    public class Produto : Entity<Guid>, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Categoria Categoria { get; private set; }

        public Situacao? Situacao { get; private set; }
        public Money PrecoUnitario { get; private set; }

        private Produto() { }

        public Produto(string nome, string descricao, string categoria, double preco)
        {
            Id = Guid.NewGuid();

            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            PrecoUnitario = new Money(preco);
            Categoria = (Categoria)Enum.Parse(typeof(Categoria), categoria);

            Situacao = Produtos.Situacao.Ativo;
        }

        public Produto(string nome, string descricao, double preco)
        {
            Id = Guid.NewGuid();

            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            PrecoUnitario = new Money(preco);

            Situacao = Produtos.Situacao.Ativo;
        }

        public void Ativar()
        {
            Situacao = Produtos.Situacao.Ativo;
        }

        public void Suspender()
        {
            Situacao = Produtos.Situacao.Suspenso;
        }

        public void AtualizarPreco(double preco)
        {
            if (Situacao != Produtos.Situacao.Ativo) throw new BusinessRuleException("Produto deve estar ativo!");

            PrecoUnitario = new Money(preco);

            AddEvent(new PrecoAtualizadoEvent(Id, PrecoUnitario.Value));
        }
    }
}
