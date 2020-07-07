using Commande.BusinessCommand;
using System;
using System.Data;

namespace Commande
{
    public class CommandBuilder : ICommandBuilder
    {
        public CommandBuilder()
        {
            Commande = null;
            CommandeType = null;
        }

        public ICommandBuilder WithLogTrace(bool TraceIn = true, bool TraceOut = true) 
        {
            if (LogCommand == null)
                LogCommand = new LogBusinessCommand();

            LogCommand.LogTraceIn = TraceIn;
            LogCommand.LogTraceOut = TraceOut;

            return this;
        }

        public ICommandBuilder WithLogMetier(bool DumpParameter = false)
        {
            if (LogCommand == null)
                LogCommand = new LogBusinessCommand();

            LogCommand.LogMetier = true;

            return this;
        }

        public ICommandBuilder WithLogPerformance()
        {
            if (LogCommand == null)
                LogCommand = new LogBusinessCommand();

            LogCommand.LogPerformance = true;

            return this;
        }

        public ICommandBuilder ForCommand<T>()
            where T : IBusinessCommand, new()
        {
            CommandeType = typeof(T);
            Commande = null;
            return this;
        }

        public ICommandBuilder AggregateCommand<T1,T2>()
            where T1 : IBusinessCommand, new()
            where T2 : IBusinessCommand, new()
        {
            var cde = new AggregatorBusinessCommand();
            Commande = cde;
            cde.AddCommand(new T1());
            cde.AddCommand(new T2());

            return this;
        }
        
        public ICommandBuilder Register()
        {
            if (CommandeType != null)
                CommandLocator.Register(CommandeType);

            return this;
        }

        private IBusinessCommand Commande { get; set; }
        private LogBusinessCommand LogCommand { get; set; }

        private Type CommandeType { get; set; }
    }

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

        ICommandBuilder WithRetry(int RetryCount=3, int WaitUntilRetry=3000);

        ICommandBuilder Register();
    }
}