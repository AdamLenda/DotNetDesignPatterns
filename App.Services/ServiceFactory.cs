using App.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace App.Services;

public class ServiceFactory(IServiceProvider serviceProvider) : IServiceFactory
{
  public IServiceProvider ServiceProvider { get; } = serviceProvider;

  private WorkflowService? _workflowService;
  IWorkflowService IServiceFactory.WorkflowService()
  {
    return _workflowService ??= new WorkflowService(this);
  }

  private IDataAccessFactory? _dataAccessFactory;
  public IDataAccessFactory DataAccessFactory()
  {
    return _dataAccessFactory ??= ServiceProvider.GetRequiredService<IDataAccessFactory>();
  }
}