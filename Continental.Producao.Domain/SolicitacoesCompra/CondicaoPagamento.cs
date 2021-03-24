using Continental.Producao.Domain.Core;
using System.Collections.Generic;

namespace Continental.Producao.Domain.SolicitacoesCompra
{
    public class CondicaoPagamento
    {
        private IList<int> _valoresPossiveis = new List<int>() { 0, 30, 60, 90 };
        public int Valor { get; private set; }

        private CondicaoPagamento() { }

        public CondicaoPagamento(int condicao)
        {
            if (!_valoresPossiveis.Contains(condicao)) throw new BusinessRuleException("Condição de pagamento deve ser " + _valoresPossiveis.ToString());

            Valor = condicao;
        }
    }
}
