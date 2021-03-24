using Microsoft.EntityFrameworkCore;
using Continental.Producao.Domain.Core;
using Continental.Producao.Domain.Produtos;
using Continental.Producao.Infra.Data.Produtos;
using Continental.Producao.Domain.SolicitacoesCompra;
using Continental.Producao.Infra.Data.SolicitacoesCompra;

namespace Continental.Producao.Infra.Data
{
    public class ProducaoContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<SolicitacaoCompra> SolicitacoesCompra { get; set; }
        public DbSet<Item> Itens { get; set; }

        public ProducaoContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Money>()
                .Property(e => e.Value)
                .HasConversion<double>();*/            

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitacaoCompraConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
        }
    }
}
