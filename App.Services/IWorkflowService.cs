using App.DataTransportObjects;
using App.Patterns;

namespace App.Services;

public interface IWorkflowService
{
  public IOutcome ValidateWorkflowDto(IWorkflowDto workflowDto);
  public IOutcome SaveWorkflowDto(IWorkflowDto workflowDto);
  public IFetchOutcome PopulateWorkflowDto(IWorkflowDto workflowDto);
}