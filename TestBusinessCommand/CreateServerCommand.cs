using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public class CreateServerCommand : IBusinessCommand 
    {
        public bool CanExecute()
        {
            Console.WriteLine("CreateServerCommand.CanExecute()");
            return true;
        }

        public void Execute()
        {
            Console.WriteLine("CreateServerCommand.Execute()");
        }
    }
}
