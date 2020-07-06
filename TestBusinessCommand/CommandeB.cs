using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public class CommandB : IBusinessCommand 
    {
        public bool CanExecute()
        {
            Console.WriteLine("CommandB.CanExecute()");
            return true;
        }

        public void Execute()
        {
            Console.WriteLine("CommandB.Execute()");
        }
    }
}
