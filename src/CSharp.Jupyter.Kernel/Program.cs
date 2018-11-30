using System;
using Newtonsoft.Json;

namespace CSharp.Jupyter.Kernel
{
    class Program
    {
        private static readonly log4net.ILog _log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                _log.ErrorFormat("Invalid number of args {0}, {1}", args.Length, string.Join(", ", args));
                Environment.Exit(1);
            }

            string connectionFilePath = args[0];

            Kernel kernel = new Kernel();

            kernel.Initialize(connectionFilePath);

            _log.Debug("Kernel initialized");
        }
    }
}
