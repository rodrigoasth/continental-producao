using Continental.Producao.Domain.SolicitacoesCompra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Continental.Producao.Infra.Data.SolicitacoesCompra
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");

            builder.OwnsOne(c => c.NomeFornecedor, b => {
                b.Property("Nome")
                .HasColumnName("NomeFornecedor");
            });

            builder.OwnsOne(c => c.UsuarioSolicitante, b => {
                b.Property("Nome")
                .HasColumnName("UsuarioSolicitante");
            });

            builder.OwnsOne(c => c.TotalGeral, b => {
                b.Property("Value")
                .HasColumnName("TotalGeral");
            });

            builder.OwnsOne(c => c.CondicaoPagamento, b => {
                b.Property("Valor")
                .HasColumnName("CondicaoPagamento");
            });
        }
    }
}
