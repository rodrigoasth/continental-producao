using Continental.Producao.Domain.Core;
using Continental.Producao.Domain.Produtos;
using Xunit;

namespace Continental.Producao.Domain.Test.Produtos
{
    public class ProdutoTests
    {
        [Fact]
        public void Deve_Atualizar_Preco_De_400_Para_500()
        {
            //Dado
            var produto = new Produto("produto001", "desc", Categoria.Madeira.ToString(), 400);

            //Quando
            produto.AtualizarPreco(500);

            //Então
            Assert.Equal(500, produto.PrecoUnitario.Value);
        }

        [Fact]
        public void Deve_Notificar_Erro_Quando_Produto_Esta_Cancelado()
        {
            //Dado
            var produto = new Produto("produto001", "desc", Categoria.Madeira.ToString(), 400);
            produto.Suspender();

            //Quando
            var ex = Assert.Throws<BusinessRuleException>(() => produto.AtualizarPreco(500));

            //Então
            Assert.Equal("Produto deve estar ativo!", ex.Message);
        }
    }
}
