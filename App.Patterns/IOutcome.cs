namespace App.Patterns;

public interface IOutcome
{
  public OutcomeFlags OutcomeFlags { get; }
  IEnumerable<IMessage> Messages { get; init; }

  public bool IsSuccess()
  {
    return OutcomeFlags.Success == (OutcomeFlags & Patterns.OutcomeFlags.Success);
  }

  public bool IsNotSuccess()
  {
    return OutcomeFlags.Success != Patterns.OutcomeFlags.Success;
  }

  public bool IsInvalid()
  {
    return OutcomeFlags == Patterns.OutcomeFlags.Invalid;
  }

  public bool IsError()
  {
    return OutcomeFlags == Patterns.OutcomeFlags.Error;
  }
}