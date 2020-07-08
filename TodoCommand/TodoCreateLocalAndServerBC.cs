using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public class TodoCreateLocalAndServerBC : AggregatorBusinessCommand 
    {
        public TodoCreateLocalAndServerBC()
        {
            AddCommand( new TodoCreateLocalBC() );
            AddCommand( new RetryBusinessCommand(new TodoCreateServerBC()) );
        }
    }
}
