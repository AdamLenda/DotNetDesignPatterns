namespace App.Patterns;

public record Outcome : IOutcome
{
  protected Outcome(OutcomeFlags outcomeFlags, IEnumerable<IMessage> messages)
  {
    OutcomeFlags = outcomeFlags;
    Messages = messages;
  }

  public IEnumerable<IMessage> Messages { get; init; }

  public OutcomeFlags OutcomeFlags { get; }

  public static IOutcome Success()
  {
    return new Outcome(OutcomeFlags.Success, []);
  }

  public static IOutcome Success(IEnumerable<IMessage> messages)
  {
    return new Outcome(OutcomeFlags.Success, messages);
  }

  public static IOutcome Invalid(IEnumerable<IMessage> messages)
  {
    return new Outcome(OutcomeFlags.Invalid, messages);
  }
  
  public static IOutcome Error(IEnumerable<IMessage> messages)
  {
    return new Outcome(OutcomeFlags.Error, messages);
  }
}