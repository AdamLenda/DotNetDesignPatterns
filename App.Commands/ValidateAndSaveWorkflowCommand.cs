using App.DataAccess.Interfaces;
using App.DataTransportObjects;
using App.Patterns;
using App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace App.Commands;

public class ValidateAndSaveWorkflowCommand
{
  public IServiceProvider ServiceProvider { get; init; }
  public IWorkflowDto WorkflowDto { get; init; }
  public IOutcome? Outcome { get; private set; }
  public IOutcome Execute()
  {
    var transactionOutcome = DataAccessFactory.NewTransaction(out var transaction);
    if (transactionOutcome.IsNotSuccess())
    {
      return Outcome = transactionOutcome;
    }

    using (transaction)
    {
      var validateOutcome = WorkflowService.ValidateWorkflowDto(WorkflowDto);
      if (validateOutcome.IsNotSuccess())
      {
        return Outcome = validateOutcome;
      }

      var saveOutcome = WorkflowService.SaveWorkflowDto(WorkflowDto);
      if (saveOutcome.IsNotSuccess())
      {
        transaction.Abort();
        return Outcome = saveOutcome;
      }

      transaction.Commit();
      return Outcome = saveOutcome;
    }
  }

  private IDataAccessFactory DataAccessFactory => ServiceProvider.GetRequiredService<IServiceFactory>().DataAccessFactory();
  private IWorkflowService WorkflowService => ServiceProvider.GetRequiredService<IServiceFactory>().WorkflowService();
}