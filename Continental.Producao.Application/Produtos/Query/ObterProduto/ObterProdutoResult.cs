namespace Continental.Producao.Application.Produtos.Query.ObterProduto
{
    public class ObterProdutoResult
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Situacao { get; set; }
    }
}
