using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public class CreateLocalCommand : IBusinessCommand 
    {
        public bool CanExecute()
        {
            Console.WriteLine("CreateLocalCommand.CanExecute()");
            return true;
        }

        public void Execute()
        {
            Console.WriteLine("CreateLocalCommand.Execute()");
        }
    }
}
