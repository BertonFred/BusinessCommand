using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public sealed class TodoCreateRequest
    {
        public string Title {get;set;}
        public bool Check { get; set; }

        public override string ToString()
        {
            return $"TodoCreateRequest: {Title} {Check}";
        }
    }
}
