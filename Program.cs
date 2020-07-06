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

            IBusinessCommand CdeCase = new CommandeCase();
            if (CdeCase.CanExecute() == true)
                CdeCase.Execute();

            Console.WriteLine("Appuyer sur une touche");
            Console.ReadKey();
        }
    }
}
