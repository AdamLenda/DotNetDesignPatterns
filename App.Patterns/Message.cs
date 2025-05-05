namespace App.Patterns;

public record Message: IMessage
{
  private Message(MessageSeverity severity, string content)
  {
    Severity = severity;
    Content = content;
  }


  public static IMessage Information(string message)
  {
    return new Message(MessageSeverity.Information, message);
  }

  public static IMessage Warning(string message)
  {
    return new Message(MessageSeverity.Warning, message);
  }
  public static IMessage Error(string message)
  {
    return new Message(MessageSeverity.Error, message);
  }

  public MessageSeverity Severity { get; }
  public string Content { get; }
}