using System;
using System.IO;
using Newtonsoft.Json;
using CSharp.Jupyter.Kernel.Sockets.Heartbeat;
using CSharp.Jupyter.Kernel.Sockets;

namespace CSharp.Jupyter.Kernel
{
    public class Kernel
    {
        private static readonly log4net.ILog _log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ConnectionFile _connectionFile;
        private HeartbeatSocket _heartbeatSocket;

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

        private bool SetUpSockets()
        {
            _log.Debug("Setting up Sockets");

            _heartbeatSocket = new HeartbeatSocket(_connectionFile.HeartbeatConnectionString());

            return true;
        }
    }
}