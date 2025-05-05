using App.DataAccess.Interfaces;
using App.DataTransportObjects;
using App.Patterns;

namespace App.DataAccess.SqlServer;

internal class WorkflowDataAccess(SqlServerDataAccessFactory sqlServerDataAccessFactory) : IWorkflowDataAccess
{
  public IFetchOutcome FetchWorkflowDto(IWorkflowDto workflowDto)
  {
    return FetchOutcome.Error([Message.Error("Not Yet Implemented")]);
  }

  public IOutcome SaveWorkflowDto(IWorkflowDto workflowDto)
  {
    return Outcome.Error([Message.Error("Not Yet Implemented")]);
  }
}