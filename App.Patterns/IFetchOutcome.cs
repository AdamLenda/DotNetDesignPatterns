namespace App.Patterns;

public interface IFetchOutcome: IOutcome
{
  public bool IsFound()
  {
    return OutcomeFlags.Found == (OutcomeFlags & Patterns.OutcomeFlags.Found);
  }

  public bool IsNotFound()
  {
    return OutcomeFlags.NotFound == (OutcomeFlags & Patterns.OutcomeFlags.NotFound);
  }
}

public record FetchOutcome: IFetchOutcome
{
  protected FetchOutcome(OutcomeFlags outcomeFlags, IEnumerable<IMessage> messages)
  {
    OutcomeFlags = outcomeFlags;
    Messages = messages;
  }

  public OutcomeFlags OutcomeFlags { get; init; }
  public IEnumerable<IMessage> Messages { get; init; }

  public static IFetchOutcome Found(IEnumerable<IMessage> messages)
  {
    return new FetchOutcome(
      OutcomeFlags.Success | OutcomeFlags.Found, messages);
  }

  public static IFetchOutcome NotFound(IEnumerable<IMessage> messages)
  {
    return new FetchOutcome(
      OutcomeFlags.Success | OutcomeFlags.NotFound, messages);
  }

  public static IFetchOutcome Invalid(IEnumerable<IMessage> messages)
  {
    return new FetchOutcome(OutcomeFlags.Invalid, messages);
  }

  public static IFetchOutcome Error(IEnumerable<IMessage> messages)
  {
    return new FetchOutcome(OutcomeFlags.Error, messages);
  }
}