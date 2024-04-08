using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeExtended.Helpers;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Others
{
    public class Delegates
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("Hello");

        public static void Log(string error)
        {
            logger.LogError(error);
            if (logger is HashLogger hashLogger)
            {
                hashLogger.PrintAllLogMessages();
            }
        }
       
        public static void Log2(string error)
        {
            Console.WriteLine("- DELEGATES -");
            Console.WriteLine($"{error}");
            Console.WriteLine("- DELEGATES -");
        }

        public delegate void ActionOnError(string errorMessage);
    }
}
