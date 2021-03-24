using Continental.Producao.Domain.Core;
using System;

namespace Continental.Producao.Domain.SolicitacoesCompra
{
    public class NomeFornecedor
    {
        public string Nome { get; }

        private NomeFornecedor() { }

        public NomeFornecedor(string nome)
        {
            if (String.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
            if (nome.Length < 10) throw new BusinessRuleException("Nome de fornecedor deve ter pelo menos 10 caracteres.");

            Nome = nome;
        }
    }
}
