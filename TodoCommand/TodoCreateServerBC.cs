using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public class TodoCreateServerBC : IBusinessCommand 
    {
        public TodoCreateServerBC()
        {
            CommandRequest = null;
        }

        public TodoCreateServerBC(TodoCreateRequest _CommandRequest) 
        {
            CommandRequest = _CommandRequest;
        }

        public bool CanExecute()
        {
            Console.WriteLine("TodoCreateServerBC.CanExecute()");
            Console.WriteLine($"{CommandRequest}");
            return true;
        }

        public void Execute()
        {
            Console.WriteLine("TodoTodoCreateServerBCCreateLocalBC.Execute()");
            Console.WriteLine($"{CommandRequest}");
        }

        public object CommandRequest { get; set; }
    }
}
