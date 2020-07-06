using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commande.BusinessCommand;

namespace Commande
{
    class Program
    {
        static void Main(string[] args)
        {
            //IBusinessCommand cde = new CommandA();
            //if( cde.CanExecute() == true)
            //    cde.Execute();

            //IBusinessCommand CdeWithRetry = new BusinessCommandRetry<CommandeEchoueDeuxFois>(3,500);
            //if (CdeWithRetry.CanExecute() == true)
            //    CdeWithRetry.Execute();

            var builder = new CommandBuilder();
            builder .ForCommand<CreateServerCommand>()
                    .WithRetry()
                    .WithLogTrace(TraceIn: true, TraceOut: true)
                    .WithLogMetier(DumpParameter: true)
                    .WithLogPerformance()
                    .WithCircuitBreakerCommand(CreateLocalCommand)
                    .WithRetry(RetryCount: 3, WaitUntilRetry: 3000)
                    .Register();

            builder.AggregateCommand<CreateArticleOnServerCommand,CreateArticleLocalCommand>("CreateArticle")
                    .WithLogTrace(TraceIn: true, TraceOut: true)
                    .WithLogMetier(DumpParameter: true)
                    .WithLogPerformance()
                    .WithRetry(RetryCount: 3, WaitUntilRetry: 3000)
                    .Register();

            builder .ForCommand<CommandA>()
                    .WithLogTrace(TraceIn: true, TraceOut: true)
                    .WithLogMetier(DumpParameter: true)
                    .WithLogPerformance()
                    .WithRetry(RetryCount: 3, WaitUntilRetry: 3000)
                    .Register();

            IBusinessCommand cde =  CommandLocator.Resolve<CommandA>();
            CommandA cdea = CommandLocator.Resolve<CommandA>();



            IBusinessCommand CdeCase = new CommandeCase();
            if (CdeCase.CanExecute() == true)
                CdeCase.Execute();

            Console.WriteLine("Appuyer sur une touche");
            Console.ReadKey();
        }
    }
}
