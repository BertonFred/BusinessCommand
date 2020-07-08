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

            new CommandBuilder()
                   .ForCommand<TodoCreateLocalBC>()
                   .WithLogMetier()
                   .Register("TodoCreateLocalBC");

            var todoCreateLocalBC = CommandLocator.Resolve("TodoCreateLocalBC");
            todoCreateLocalBC.Execute();

            new CommandBuilder()
                   .ForCommand<TodoCreateServerBC>()
                   .WithLogMetier()
                   .WithLogPerformance()
                   .Register("TodoCreateServerBC");

            var todoCreateServerBC = CommandLocator.Resolve("TodoCreateServerBC");
            todoCreateServerBC.Execute();

            new CommandBuilder()
                   .ForCommand<TodoCreateLocalBC>()
                   .WithLogMetier()
                   .WithLogPerformance()
                   .ForCommand<TodoCreateServerBC>()
                   .WithLogMetier()
                   .WithLogPerformance()
                   .Register("TodoCreateBC");

            var todoCreateBC = CommandLocator.Resolve("TodoCreateBC");
            todoCreateBC.Execute();

            Console.WriteLine("Appuyer sur une touche");
            Console.ReadKey();
        }
    }
}
