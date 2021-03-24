using Continental.Producao.Domain.SolicitacoesCompra;
using System;
using System.Linq;

namespace Continental.Producao.Infra.Data.SolicitacoesCompra
{
    public class SolicitacaoCompraRepository : ISolicitacaoCompraRepository
    {
        protected ProducaoContext _context { get; set; }

        public SolicitacaoCompraRepository(ProducaoContext context)
        {
            _context = context;
        }

        public SolicitacaoCompra Obter(Guid id)
        {
            return _context.SolicitacoesCompra.Single(x => x.Id == id);
        }

        public void RegistrarCompra(SolicitacaoCompra solicitacaoCompra)
        {
            _context.Set<SolicitacaoCompra>().Add(solicitacaoCompra);
        }

        public void ExcluirCompra(SolicitacaoCompra solicitacaoCompra)
        {
            _context.Set<SolicitacaoCompra>().Remove(solicitacaoCompra);
        }
    }
}
