using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace Continental.Producao.Infra.Data
{
    public class ProducaoReadContext : IProducaoReadContext
    {
        public IConfiguration Configuration { get; }

        public ProducaoReadContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbConnection GetConnection()
        {
            return new SqliteConnection(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
