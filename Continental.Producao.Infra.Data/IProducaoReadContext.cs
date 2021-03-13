using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace Continental.Producao.Infra.Data
{
    public interface IProducaoReadContext
    {
        IConfiguration Configuration { get; }

        DbConnection GetConnection();
    }
}
