namespace App.DataTransportObjects;

public record WorkflowDto: IWorkflowDto
{
  public Guid? ExternalKey { get; set; }
}