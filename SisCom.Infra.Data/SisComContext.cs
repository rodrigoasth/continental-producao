using Microsoft.EntityFrameworkCore;
using SisCom.Domain.Core;
using SisCom.Domain.Produtos;
using SisCom.Infra.Data.Produtos;

namespace SisCom.Infra.Data
{
    public class SisComContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public SisComContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Money>()
                .Property(e => e.Value)
                .HasConversion<double>();*/            

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

            /*modelBuilder.Entity<Produto>().HasData(
                new Produto("Produto 01", "desc 01", 100),
                new Produto("Produto 02", "desc 02", 100),
                new Produto("Produto 03", "desc 03", 100)
            );*/
        }
    }
}
