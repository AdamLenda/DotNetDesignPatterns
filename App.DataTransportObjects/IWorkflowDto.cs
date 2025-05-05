namespace App.DataTransportObjects;

public interface IWorkflowDto
{
  public Guid? ExternalKey { get; set; }
}