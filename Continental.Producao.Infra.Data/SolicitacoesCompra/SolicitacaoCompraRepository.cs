using Continental.Producao.Domain.SolicitacoesCompra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Continental.Producao.Infra.Data.SolicitacoesCompra
{
    public class SolicitacaoCompraRepository : ISolicitacaoCompraRepository
    {
        protected ProducaoContext Context { get; set; }

        public SolicitacaoCompraRepository(ProducaoContext context)
        {
            Context = context;
        }

        public void RegistrarCompra(SolicitacaoCompra solicitacaoCompra)
        {
            Context.Set<SolicitacaoCompra>().Add(solicitacaoCompra);
        }
    }
}
