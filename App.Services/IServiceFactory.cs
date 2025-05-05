using App.DataAccess.Interfaces;

namespace App.Services;

public interface IServiceFactory
{
  IWorkflowService WorkflowService();
  IDataAccessFactory DataAccessFactory();
}