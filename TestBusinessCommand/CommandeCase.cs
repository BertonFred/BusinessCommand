using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public class CommandeCase : AggregatorBusinessCommand 
    {
        public CommandeCase()
        {
            AddCommand( new CommandA() );
            AddCommand( new RetryBusinessCommand<CommandeEchoueDeuxFois>() );
        }
    }
}
