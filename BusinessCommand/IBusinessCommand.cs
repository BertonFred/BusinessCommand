﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public interface IBusinessCommand
    {
        bool CanExecute();

        void Execute();

        object CommandRequest { get; set; }
    }
}
