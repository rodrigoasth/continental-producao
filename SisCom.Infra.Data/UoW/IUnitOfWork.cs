using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace SisCom.Infra.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();

        IDbContextTransaction BeginTransaction();
    }
}
