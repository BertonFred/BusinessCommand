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

        public ICommandBuilder WithRetry(int RetryCount = RetryBusinessCommand.DefaultRetryCount, 
                                         int WaitUntilRetry = RetryBusinessCommand.DefaultWaitBeforeRetry)
        {
            if (this.Commande == null)
                throw new ArgumentNullException("Pas de commande. Impossible de l'etendre par un retry");

            var RetryCommand = new RetryBusinessCommand(this.Commande,RetryCount,WaitUntilRetry);
            this.Commande = RetryCommand;
            return this;
        }

        private LogBusinessCommand GetLogCommand()
        {
            if (this.Commande == null)
                throw new ArgumentNullException("Pas de commande. Impossible de l'etendre par un log");

            var LogCommand = this.Commande as LogBusinessCommand;
            if (LogCommand == null)
            {
                LogCommand = new LogBusinessCommand(this.Commande);
                this.Commande = LogCommand;
            }

            return LogCommand;
        }

        public ICommandBuilder WithLogTrace(bool TraceIn = true, bool TraceOut = true) 
        {
            var LogCommand = GetLogCommand();
            LogCommand.LogTraceIn = TraceIn;
            LogCommand.LogTraceOut = TraceOut;
            return this;
        }

        public ICommandBuilder WithLogMetier(bool DumpParameter = false)
        {
            var LogCommand = GetLogCommand();
            LogCommand.LogMetier = true;
            return this;
        }

        public ICommandBuilder WithLogPerformance()
        {
            var LogCommand = GetLogCommand();
            LogCommand.LogPerformance = true;
            return this;
        }

        public ICommandBuilder ForCommand<T>()
            where T : IBusinessCommand, new()
        {
            if (Commande != null)
            {
                var AggregatorCommand = new AggregatorBusinessCommand();
                AggregatorCommand.AddCommand( this.Commande );
                AggregatorCommand.AddCommand( new T() );
                this.Commande = AggregatorCommand;
            }
            else 
            {
                Commande = new T();
            }

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
        
        public ICommandBuilder Register(string CommandName)
        {
            CommandLocator.Register(CommandName,this.Commande);

            return this;
        }

        private IBusinessCommand Commande { get; set; }
        private LogBusinessCommand LogCommand { get; set; }

        private Type CommandeType { get; set; }
    }
}