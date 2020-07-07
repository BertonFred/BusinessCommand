using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public class LogBusinessCommand : IBusinessCommand
    {
        public LogBusinessCommand()
        {
            LogTraceIn = false;
            LogTraceOut = false;
            LogMetier = false;
            LogPerformance = false;
        }

        public bool CanExecute()
        {
            WriteLogTraceIn(nameof(Command.CanExecute));
            WriteLogMetier(nameof(Command.CanExecute));
            WriteLogPerformanceStart(nameof(Command.CanExecute));
            bool bResult = Command.CanExecute();
            WriteLogPerformanceStop(nameof(Command.CanExecute));
            WriteLogTraceOut(nameof(Command.CanExecute));

            return bResult;
        }

        public void Execute()
        {
            WriteLogTraceIn(nameof(Command.Execute));
            WriteLogMetier(nameof(Command.Execute));
            WriteLogPerformanceStart(nameof(Command.Execute));
            Command.Execute();
            WriteLogPerformanceStop(nameof(Command.Execute));
            WriteLogTraceOut(nameof(Command.Execute));
        }

        private void WriteLogTraceIn(string sMethode)
        {
            if (LogTraceIn == true)
                Console.WriteLine($"WriteLogTraceIn: {sMethode}");
        }
        private void WriteLogTraceOut(string sMethode)
        {
            if (LogTraceOut == true)
                Console.WriteLine($"WriteLogTraceOut: {sMethode}");
        }
        private void WriteLogMetier(string sMethode)
        {
            if (LogMetier == true)
                Console.WriteLine($"WriteLogMetier: {sMethode}");
        }
        private void WriteLogPerformanceStart(string sMethode)
        {
            if (LogPerformance == true)
                Console.WriteLine($"WriteLogPerformanceStart: {sMethode}");
        }
        private void WriteLogPerformanceStop(string sMethode)
        {
            if (LogPerformance == true)
                Console.WriteLine($"WriteLogPerformanceStart: {sMethode}");
        }

        public IBusinessCommand Command { get; set; }
        public object CommandRequest { get; set; }

        public bool LogTraceIn { get; set; }
        public bool LogTraceOut { get; set; }
        public bool LogMetier { get; set; }
        public bool LogPerformance { get; set; }
    }
}
