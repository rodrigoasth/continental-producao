using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace SisCom.Infra.Data
{
    public interface ISisComReadContext
    {
        IConfiguration Configuration { get; }

        DbConnection GetConnection();
    }
}
