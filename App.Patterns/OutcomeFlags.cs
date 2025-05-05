namespace App.Patterns;

[Flags]
public enum OutcomeFlags
{
  Undefined = 0,
  Success = 1,
  Invalid = 2,
  Error = 4,
  Found = 8,
  NotFound = 16,
}