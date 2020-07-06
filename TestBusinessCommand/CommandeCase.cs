using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public class CommandeCase : BusinessCommandAggregator 
    {
        public CommandeCase()
        {
            AddCommand( new CommandA() );
            AddCommand( new BusinessCommandRetry<CommandeEchoueDeuxFois>() );
        }
    }
}
