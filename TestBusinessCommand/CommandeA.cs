using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public class CommandA : IBusinessCommand 
    {
        public bool CanExecute()
        {
            Console.WriteLine("CommandA.CanExecute()");
            return true;
        }

        public void Execute()
        {
            Console.WriteLine("CommandA.Execute()");
        }
    }
}
