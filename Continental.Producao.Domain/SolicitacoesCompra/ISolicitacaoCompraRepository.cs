using System;
using System.Collections.Generic;
using System.Text;

namespace Continental.Producao.Domain.SolicitacoesCompra
{
    public interface ISolicitacaoCompraRepository
    {
        void ExcluirCompra(SolicitacaoCompra solicitacaoCompra);
        SolicitacaoCompra Obter(Guid id);
        void RegistrarCompra(SolicitacaoCompra solicitacaoCompra);
    }
}
