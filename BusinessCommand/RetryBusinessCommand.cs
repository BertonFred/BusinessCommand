using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commande.BusinessCommand
{
    public class RetryBusinessCommand : IDecoratorBusinessCommand
    {
        public RetryBusinessCommand(IBusinessCommand _Command, int _RetryCount = DefaultRetryCount, int _WaitBeforeRetry = DefaultWaitBeforeRetry)
        {
            Command = _Command;
            RetryCount = _RetryCount;
            WaitBeforeRetry = _WaitBeforeRetry;
        }

        public bool CanExecute()
        {
            Console.WriteLine("RetryBusinessCommand.CanExecute()");

            bool bResult = false;

            for (int iTryCount = 1; iTryCount <= RetryCount; iTryCount++)
            {
                try
                {
                    bResult = Command.CanExecute();
                    Console.WriteLine($"RetryBusinessCommand.CanExecute(): Success in {iTryCount} try");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"RetryBusinessCommand.CanExecute(): Trap and Retry {iTryCount} {Command.GetType().Name}");
                    if (iTryCount == RetryCount)
                        throw e;
                }
            }

            return bResult;
        }

        public void Execute()
        {
            Console.WriteLine("RetryBusinessCommand.Execute()");

            for (int iTryCount = 1; iTryCount <= RetryCount; iTryCount++)
            {
                try
                {
                    Command.Execute();
                    Console.WriteLine($"RetryBusinessCommand.Execute(): Success in {iTryCount} try");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"RetryBusinessCommand.Execute(): Trap and Retry {iTryCount} {Command.GetType().Name}");
                    if (iTryCount == RetryCount)
                        throw e;
                }
            }
        }

        private IBusinessCommand Command { get; set; }
        public int RetryCount { get; set; }
        public const int DefaultRetryCount = 3;
        public int WaitBeforeRetry { get; set; }
        public const int DefaultWaitBeforeRetry = 3;
        public object CommandRequest { get; set; }
    }
    //public class RetryBusinessCommand<TCOMMAND> : IDecoratorBusinessCommand
    //        where TCOMMAND : IBusinessCommand, new()
    //{
    //    public RetryBusinessCommand(int _RetryCount = DefaultRetryCount, int _WaitBeforeRetry = DefaultWaitBeforeRetry)
    //    {
    //        RetryCount = _RetryCount;
    //        WaitBeforeRetry = _WaitBeforeRetry;
    //        Command = new TCOMMAND();
    //    }

    //    public bool CanExecute()
    //    {
    //        Console.WriteLine("BusinessCommandRetry.CanExecute()");

    //        bool bResult = false;

    //        for (int iTryCount = 1; iTryCount <= RetryCount; iTryCount++)
    //        {
    //            try
    //            {
    //                bResult = Command.CanExecute();
    //                Console.WriteLine($"BusinessCommandRetry.CanExecute(): Success in {iTryCount} try");
    //            }
    //            catch (Exception e)
    //            {
    //                Console.WriteLine($"BusinessCommandRetry.CanExecute(): Trap and Retry {iTryCount} {Command.GetType().Name}");
    //                if (iTryCount == RetryCount)
    //                    throw e;
    //            }
    //        }

    //        return bResult;
    //    }

    //    public void Execute()
    //    {
    //        Console.WriteLine("BusinessCommandRetry.Execute()");

    //        for (int iTryCount = 1; iTryCount <= RetryCount; iTryCount++)
    //        {
    //            try
    //            {
    //                Command.Execute();
    //                Console.WriteLine($"BusinessCommandRetry.Execute(): Success in {iTryCount} try");
    //            }
    //            catch (Exception e)
    //            {
    //                Console.WriteLine($"BusinessCommandRetry.Execute(): Trap and Retry {iTryCount} {Command.GetType().Name}");
    //                if (iTryCount == RetryCount)
    //                    throw e;
    //            }
    //        }
    //    }

    //    private IBusinessCommand Command { get; set; }
    //    public int RetryCount { get; set; }
    //    private const int DefaultRetryCount = 3;
    //    public int WaitBeforeRetry { get; set; }
    //    private const int DefaultWaitBeforeRetry = 3;
    //    object CommandRequest { get; set; }
    //}
}
