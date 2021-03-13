using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace SisCom.Infra.Data
{
    public class SisComReadContext : ISisComReadContext
    {
        public IConfiguration Configuration { get; }

        public SisComReadContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbConnection GetConnection()
        {
            return new SqliteConnection(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
