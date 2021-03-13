using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Continental.Producao.Infra.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();

        IDbContextTransaction BeginTransaction();
    }
}
