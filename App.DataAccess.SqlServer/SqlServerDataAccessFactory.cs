using App.DataAccess.Interfaces;
using App.Patterns;

namespace App.DataAccess.SqlServer;

public class SqlServerDataAccessFactory(IServiceProvider serviceProvider) : IDataAccessFactory
{
    public IOutcome NewTransaction(out ITransaction transaction)
    {
        transaction = new SqlServerTransaction(this);
        return Outcome.Error([Message.Error("Not Yet Implemented")]);
    }

    public IWorkflowDataAccess WorkflowDataAccess()
    {
        return new WorkflowDataAccess(this);
    }
}