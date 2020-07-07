using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public class TodoCreateLocalBC : IBusinessCommand 
    {
        public TodoCreateLocalBC()
        {
            CommandRequest = null;
        }

        public TodoCreateLocalBC(TodoCreateRequest _CommandRequest) 
        {
            CommandRequest = _CommandRequest;
        }

        public bool CanExecute()
        {
            Console.WriteLine("TodoCreateLocalBC.CanExecute()");
            Console.WriteLine($"{CommandRequest}");
            return true;
        }

        public void Execute()
        {
            Console.WriteLine("TodoCreateLocalBC.Execute()");
            Console.WriteLine($"{CommandRequest}");
        }

        public object CommandRequest { get; set; }
    }
}
