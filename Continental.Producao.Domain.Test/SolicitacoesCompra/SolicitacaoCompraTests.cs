using Continental.Producao.Domain.Core;
using Continental.Producao.Domain.Produtos;
using Continental.Producao.Domain.SolicitacoesCompra;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Continental.Producao.Domain.Test.SolicitacoesCompra
{
    public class SolicitacaoCompraTests
    {
        [Fact]
        public void Deve_Definir_Prazo_30_Dias_Ao_Comprar_Mais_50_mil()
        {
            //Dado
            var solicitacao = new SolicitacaoCompra("rodrigoasth", "rodrigoasth");
            var produto = new Produto("Cedro", "Transversal 3/3", Categoria.Madeira.ToString(), 1001);
            solicitacao.AdicionarItem(produto, 50);

            //Quando
            solicitacao.RegistrarCompra();

            //Então
            Assert.Equal(30, solicitacao.CondicaoPagamento.Valor);
        }

        [Fact]
        public void Deve_Notificar_Erro_Quando_Nao_Informar_Itens_Compra()
        {
            //Dado
            var solicitacao = new SolicitacaoCompra("rodrigoasth", "rodrigoasth");

            //Quando 
            var ex = Assert.Throws<BusinessRuleException>(() => solicitacao.RegistrarCompra());

            //Então
            Assert.Equal("A solicitação de compra deve possuir itens!", ex.Message);
        }
    }
}
