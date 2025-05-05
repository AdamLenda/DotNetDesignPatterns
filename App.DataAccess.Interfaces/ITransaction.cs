using App.Patterns;

namespace App.DataAccess.Interfaces;

public interface ITransaction: IDisposable
{
  public IOutcome Commit();

  public IOutcome Abort();
}