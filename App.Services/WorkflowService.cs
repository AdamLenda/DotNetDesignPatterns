using App.DataAccess.Interfaces;
using App.DataTransportObjects;
using App.Patterns;

namespace App.Services;


internal class WorkflowService(IServiceFactory serviceFactory): IWorkflowService
{
  public IOutcome ValidateWorkflowDto(IWorkflowDto workflowDto)
  {
    return Outcome.Error([Message.Error("Not Yet Defined")]);
  }

  public IOutcome SaveWorkflowDto(IWorkflowDto workflowDto)
  {
    var saveOutcome = WorkflowDataAccess.SaveWorkflowDto(workflowDto);
    if (saveOutcome.IsSuccess())
    {
      return Outcome.Error([Message.Information("Workflow Saved")]);
    }

    return Outcome.Error([Message.Error("Not Yet Defined")]);
  }

  public IFetchOutcome PopulateWorkflowDto(IWorkflowDto workflowDto)
  {
    return WorkflowDataAccess.FetchWorkflowDto(workflowDto);
  }

  private IWorkflowDataAccess WorkflowDataAccess { get => serviceFactory.DataAccessFactory().WorkflowDataAccess(); }
}