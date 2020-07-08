using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public class CommandeEchoueDeuxFois : IBusinessCommand
    {
        public bool CanExecute()
        {
            Console.WriteLine("CommandeEchoueDeuxFois.CanExecute()");
            CallCount++;

            if (CallCount <= 2)
            {
                throw  new ArgumentException("CommandeEchoueDeuxFois.CanExecute(): Plantage forcer");
            }

            CallCount = 0;

            return true;
        }

        public void Execute()
        {
            Console.WriteLine("CommandeEchoueDeuxFois.Execute()");
            CallCount++;

            if (CallCount <= 2)
            {
                throw new ArgumentException("CommandeEchoueDeuxFois.Execute(): Plantage forcer");
            }

            CallCount = 0;
        }

        private int CallCount = 0;
        public object CommandRequest { get; set; }
    }
}
