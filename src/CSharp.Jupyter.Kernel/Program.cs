using System;
using System.IO;
using System.Reflection;
using CSharp.Jupyter.Kernel.Sockets.Control;
using CSharp.Jupyter.Kernel.Sockets.Heartbeat;
using CSharp.Jupyter.Kernel.Sockets.IOPub;
using CSharp.Jupyter.Kernel.Sockets.Shell;
using CSharp.Jupyter.Kernel.Sockets.Stdin;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CSharp.Jupyter.Kernel
{
    class Program
    {
        private static readonly log4net.ILog _log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        internal static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure(
                log4net.LogManager.GetRepository(Assembly.GetEntryAssembly()),
                new FileInfo("log4net.config"));

            if(args.Length != 1)
            {
                _log.ErrorFormat("Invalid number of args {0}, {1}", args.Length, string.Join(", ", args));

                Environment.ExitCode = 1;
                return;
            }

            string connectionFilePath = args[0];

            var serviceCollection = SetUpDependencies();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var kernel = serviceProvider.GetRequiredService<Kernel>();

            if(!kernel.Initialize(connectionFilePath))
            {
                _log.Error("Kernel failed to initialized.");
                Environment.ExitCode = 1;
                return;
            }

            _log.Debug("Kernel initialized");
        }

        private static ServiceCollection SetUpDependencies()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IControlSocket, ControlSocket>();
            serviceCollection.AddTransient<IHeartbeatSocket, HeartbeatSocket>();
            serviceCollection.AddTransient<IIOPubSocket, IOPubSocket>();
            serviceCollection.AddTransient<IShellSocket, ShellSocket>();
            serviceCollection.AddTransient<IStdinSocket, StdinSocket>();

            serviceCollection.AddTransient<Kernel>();

            return serviceCollection;
        }
    }
}
