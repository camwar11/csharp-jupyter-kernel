namespace CSharp.Jupyter.Kernel.Sockets
{
    public static class SocketHelpers
    {
        public static string GetConnectionString(string protocol, string address, int port)
        {
            return string.Format("{0}://{1}:{2}", protocol, address, port);
        }

        private static string GetConnectionString(ConnectionFile file, int port)
        {
            return string.Format("{0}://{1}:{2}", file.Transport, file.IP, port);
        }

        public static string ControlConnectionString(this ConnectionFile connectionFile)
        {
            return GetConnectionString(connectionFile, connectionFile.ControlPort);
        }

        public static string HeartbeatConnectionString(this ConnectionFile connectionFile)
        {
            return GetConnectionString(connectionFile, connectionFile.HBPort);
        }

        public static string IOPubConnectionString(this ConnectionFile connectionFile)
        {
            return GetConnectionString(connectionFile, connectionFile.IOPubPort);
        }

        public static string ShellConnectionString(this ConnectionFile connectionFile)
        {
            return GetConnectionString(connectionFile, connectionFile.ShellPort);
        }

        public static string StdinConnectionString(this ConnectionFile connectionFile)
        {
            return GetConnectionString(connectionFile, connectionFile.StdinPort);
        }
    }
}