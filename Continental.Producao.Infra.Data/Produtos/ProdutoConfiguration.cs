using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Continental.Producao.Domain.Produtos;

namespace Continental.Producao.Infra.Data.Produtos
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.OwnsOne(x => x.PrecoUnitario, n => n.Property("Value")
                                                        .HasColumnName("PrecoUnitario"));
        }
    }
}
