using App.DataTransportObjects;
using App.Patterns;

namespace App.DataAccess.Interfaces;

public interface IWorkflowDataAccess
{
  IFetchOutcome FetchWorkflowDto(IWorkflowDto workflowDto);
  IOutcome SaveWorkflowDto(IWorkflowDto workflowDto);
}