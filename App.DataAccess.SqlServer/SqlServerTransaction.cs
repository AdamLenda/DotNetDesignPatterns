using App.DataAccess.Interfaces;
using App.Patterns;

namespace App.DataAccess.SqlServer;

internal record SqlServerTransaction : ITransaction
{
  private readonly SqlServerDataAccessFactory _sqlServerDataAccessFactory;

  public SqlServerTransaction(SqlServerDataAccessFactory sqlServerDataAccessFactory)
  {
    _sqlServerDataAccessFactory = sqlServerDataAccessFactory;
  }

  ~SqlServerTransaction()
  {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    // release unmanaged memory
    if (disposing) {
      // release other disposable / managed objects
    }
  }

  public IOutcome Commit()
  {
    throw new NotImplementedException();
  }

  public IOutcome Abort()
  {
    throw new NotImplementedException();
  }
}