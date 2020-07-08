using Commande.BusinessCommand;
using System;
using System.Data;

namespace Commande
{
    public interface ICommandBuilder
    {
        ICommandBuilder ForCommand<T>()
            where T : IBusinessCommand, new();

        ICommandBuilder AggregateCommand<T1, T2>()
            where T1 : IBusinessCommand, new()
            where T2 : IBusinessCommand, new();

        ICommandBuilder WithLogTrace(bool TraceIn = true, bool TraceOut= true);

        ICommandBuilder WithLogMetier(bool DumpParameter=false);

        ICommandBuilder WithLogPerformance();

        ICommandBuilder WithRetry(int RetryCount=RetryBusinessCommand.DefaultRetryCount, int WaitUntilRetry=RetryBusinessCommand.DefaultWaitBeforeRetry);

        ICommandBuilder Register(string CommandName);
    }
}