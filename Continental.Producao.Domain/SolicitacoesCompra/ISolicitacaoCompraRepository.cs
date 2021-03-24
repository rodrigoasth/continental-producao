using System;
using System.Collections.Generic;
using System.Text;

namespace Continental.Producao.Domain.SolicitacoesCompra
{
    public interface ISolicitacaoCompraRepository
    {
        void RegistrarCompra(SolicitacaoCompra solicitacaoCompra);
    }
}
