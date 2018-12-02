using System;
using System.IO;
using Newtonsoft.Json;
using CSharp.Jupyter.Kernel.Sockets.Heartbeat;
using CSharp.Jupyter.Kernel.Sockets;
using CSharp.Jupyter.Kernel.Sockets.Control;
using CSharp.Jupyter.Kernel.Sockets.IOPub;
using CSharp.Jupyter.Kernel.Sockets.Shell;
using CSharp.Jupyter.Kernel.Sockets.Stdin;

namespace CSharp.Jupyter.Kernel
{
    public class Kernel
    {
        private static readonly log4net.ILog _log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ConnectionFile _connectionFile;
        private readonly IControlSocket _controlSocket;
        private readonly IHeartbeatSocket _heartbeatSocket;
        private readonly IIOPubSocket _iioPubSocket; 
        private readonly IShellSocket _shellSocket;
        private readonly IStdinSocket _stdinSocket;

        public bool Running { get; set; }

        public Kernel(IControlSocket controlSocket, IHeartbeatSocket heartbeatSocket, IIOPubSocket iioPubSocket, 
        IShellSocket shellSocket, IStdinSocket stdinSocket)
        {
            _controlSocket = controlSocket;
            _heartbeatSocket = heartbeatSocket;
            _iioPubSocket = iioPubSocket; 
            _shellSocket = shellSocket;
            _stdinSocket = stdinSocket;

            Running = true;
        }

        public bool Initialize(string connectionFilePath)
        {
            bool success = ReadConnectionFile(connectionFilePath);

            if(!success)
            {
                return success;
            }

            success = SetUpSockets();

            if(!success)
            {
                return success;
            }

            return success;
        }

        private bool ReadConnectionFile(string connectionFilePath)
        {
            try
            {
                _log.Debug("Reading connection file from " + connectionFilePath);
                string fileContent = File.ReadAllText(connectionFilePath);

                _connectionFile = JsonConvert.DeserializeObject<ConnectionFile>(fileContent);

                return true;
            }
            catch (Exception e)
            {
                _log.Error("Reading connection file failed.", e);
                return false;
            }
        }

        public void Run()
        {
            while(Running)
            {
                _shellSocket.Poll();
            }
        }

        private bool SetUpSockets()
        {
            _log.Debug("Setting up Sockets");

            _controlSocket.Bind(_connectionFile.ControlConnectionString());
            _heartbeatSocket.Bind(_connectionFile.HeartbeatConnectionString());
            _iioPubSocket.Bind(_connectionFile.IOPubConnectionString());
            _shellSocket.Bind(_connectionFile.ShellConnectionString());
            _stdinSocket.Bind(_connectionFile.StdinConnectionString());

            return true;
        }
    }
}