using App.Patterns;

namespace App.DataAccess.Interfaces;

public interface IDataAccessFactory
{
  public IOutcome NewTransaction(out ITransaction transaction);
  public IWorkflowDataAccess WorkflowDataAccess();
}