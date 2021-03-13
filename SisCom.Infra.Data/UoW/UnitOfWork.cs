using Microsoft.EntityFrameworkCore.Storage;

namespace Continental.Producao.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProducaoContext _db;

        public UnitOfWork(ProducaoContext db)
        {
            this._db = db;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _db.Database.BeginTransaction();
        }

        public bool Commit()
        {
            return _db.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
