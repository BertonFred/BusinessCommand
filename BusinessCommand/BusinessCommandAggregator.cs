using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public class BusinessCommandAggregator : IBusinessCommand
    {
        public BusinessCommandAggregator()
        {
            Commandes = new List<IBusinessCommand>();
        }

        public bool CanExecute()
        {
            foreach (IBusinessCommand command in Commandes)
            {
                if (command.CanExecute() == false)
                    return false;
            }

            return true;
        }

        public void Execute()
        {
            foreach (IBusinessCommand command in Commandes)
            {
                command.Execute();
            }
        }

        public void AddCommand(IBusinessCommand command)
        {
            Commandes.Add(command);
        }

        private List<IBusinessCommand> Commandes { get; set; }
    }
}
