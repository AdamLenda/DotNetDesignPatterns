namespace App.Patterns;

public interface IMessage
{
  public MessageSeverity Severity { get; }
  public string Content { get; }
}